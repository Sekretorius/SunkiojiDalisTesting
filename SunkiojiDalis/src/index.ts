import * as signalR from "@microsoft/signalr";
import { ClientObjects, ClientObjectCount, Interpolate } from "./Managers/ClientEngine"

(<HTMLInputElement> document.getElementById("canvas")).disabled = true;
const canvas = <HTMLCanvasElement> document.getElementById('canvas');
const context = canvas.getContext('2d');
canvas.width = 800;
canvas.height = 500;

const keys = [];
let otherPlayers = [];
let items = [];

const player = {
  id: -1,
  x: 200,
  y: 200,
  width: 32,
  height: 48,
  frameX: 0,
  frameY: 0,
  speed: 5,
  worldX: 3,
  worldY: 3,
  moving: false,
  sprite: "resources/characters/player-red.png"
};

function joinGame() {
  connection.invoke("JoinGame", JSON.stringify(player)).catch(function (err) {
    return console.error(err.toString());
  });
}

function getItems() {
  connection.invoke("SendItemsListToPlayers").catch(function (err) {
    return console.error(err.toString());
  });
}

export var connection = new signalR.HubConnectionBuilder().withUrl("/chatHub").withAutomaticReconnect().build();

connection.on("RecieveInfoAboutOtherPlayers", function (newPlayersList) {
    otherPlayers = JSON.parse(newPlayersList);
  //to do: check coordinates with current player - take server coordinates
  for(const element of otherPlayers) {
    if(element.id == player.id)
    {
      player.id = element.id;
      player.x = element.x;
      player.y = element.y;
      player.worldX = element.worldX;
      player.worldY = element.worldY;
      break;
    }
  }
});

connection.on("RecieveItemInfo", function (newItems) {
  items = JSON.parse(newItems);
});

connection.on("RecieveId", function (id) {
    player.id = id;
    console.log(player.id);
});

connection.start().then(function () {
  joinGame();
  
  (<HTMLInputElement> document.getElementById("canvas")).disabled = false;
  startAnimating(30);
}).catch(function (err) {
  //to do: add notification for user 
  return console.error(err.toString());
});

const background = new Image();
background.src = "resources/backgrounds/grass_background.png";

function drawSprite(img, sX, sY, sW, sH, dX, dY, dW, dH) {
  const playerSprite = new Image();
  playerSprite.src = img;
  context.drawImage(playerSprite, sX, sY, sW, sH, dX, dY, dW, dH);
}

window.addEventListener("keydown", function(e) {
  keys[e.key] = true;
  player.moving = true;
});

window.addEventListener("keyup", function(e) {
  delete keys[e.key];
  player.moving = false;
});

function movePlayer() {
  if(keys["ArrowUp"] && player.y > 0) {
    player.y -= player.speed;
    player.frameY = 3;
    player.moving = true;
  }
  if(keys["ArrowLeft"] && player.x > 0) {
    player.x -= player.speed;
    player.frameY = 1;
    player.moving = true;
  }
  if(keys["ArrowDown"] && player.y < canvas.height - player.height) {
    player.y += player.speed;
    player.frameY = 0;
    player.moving = true;
  }
  if(keys["ArrowRight"] && player.x < canvas.width - player.width) {
    player.x += player.speed;
    player.frameY = 2;
    player.moving = true;
  }
}

function handlePlayerFrame() {
  if(player.frameX < 3 && player.moving) player.frameX++;
  else player.frameX = 0;
}

let fps, fpsInterval, startTime, now, then, elapsed;

function startAnimating(fps) {
  fpsInterval = 1000 / fps;
  then = Date.now();
  startTime = then;
  animate();
}

function sendPlayerInfoToServer() {
  connection.invoke("UpdatePlayerInfo", JSON.stringify(player)).catch(function (err) {
    return console.error(err.toString());
  });
}
let timeThen = 0;
function animate() {
  timeThen = now;
  requestAnimationFrame(animate);
  now = Date.now();
  elapsed = now - then;
  if(elapsed > fpsInterval) {
    then = now - (elapsed % fpsInterval);
    context.clearRect(0, 0, canvas.width, canvas.height)
    context.drawImage(background, 0, 0, canvas.width, canvas.height);

    if (otherPlayers.length > 0) {
      for(const el of otherPlayers) {
        if(el == null) continue;
        drawSprite(
          el.sprite,
          el.width * el.frameX,
          el.height * el.frameY,
          el.width,
          el.height,
          el.x,
          el.y,
          el.width,
          el.height);
      }
    }

    if (ClientObjectCount > 0) {
      for(const objectKey in ClientObjects) {
        let el = ClientObjects[objectKey];
        if(el == undefined) continue;

        el.position = Interpolate(el.position, el.targetPosition, el.speed, (now - timeThen) / 1000);
        drawSprite(
          el.sprite,
          el.width * el.frameX,
          el.height * el.frameY,
          el.width,
          el.height,
          el.position.x,
          el.position.y,
          el.width,
          el.height);
      }
    }

    if (items.length > 0) {
      for(const el of items) {
        const img = new Image();
        img.src = el.Sprite;
        context.drawImage(
          img,
          el.X,
          el.Y)
      }
    }


    movePlayer();
    handlePlayerFrame();
    
    //to do: send/update player info to server when it is needed
    if (player.id !== -1){
      sendPlayerInfoToServer();
      getItems();
    }
    requestAnimationFrame(animate);
  }
}
