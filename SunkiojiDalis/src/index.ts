import * as signalR from "@microsoft/signalr";
import { ClientObjects, ClientObjectCount, Interpolate } from "./Managers/ClientEngine"
import { Obstacle } from "./Obstacles/Obstacle"
import { Item } from "./Items/Item"
import { connect } from "net";
import { KeyObject } from "crypto";
import EventEmitter = require("events");
import NetworkManager = require("./Managers/NetworkManager");

(<HTMLInputElement> document.getElementById("canvas")).disabled = true;
const canvas = <HTMLCanvasElement> document.getElementById('canvas');
const context = canvas.getContext('2d');
canvas.width = 800;
canvas.height = 500;
let connectionID = "";

const keys = [];
let otherPlayers = [];
let items = [];

export const indexWindow = window;

const controls = {
    id: -1,
    up: false,
    down: false,
    left: false,
    right: false,
    moving: false,
    undo: false,
};

const notification = {
    text: ""
}

function resetControls() {
    controls.up = false;
    controls.left = false;
    controls.down = false;
    controls.right = false;
    controls.undo = false;
}

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
  background: "resources/backgrounds/grass_background.png",
  moving: false,
  sprite: "resources/characters/player-red.png"
};

function joinGame() {
    console.log("join game");
    connection.invoke("JoinGame", JSON.stringify(player)).catch(function (err) {
    return console.error(err.toString());
  });
}

function getItems() {
  connection.invoke("SendItemsListToPlayers").catch(function (err) {
    return console.error(err.toString());
  });
}

export var connection;

window.onload = function () {

    connection = new signalR.HubConnectionBuilder().withUrl("/chatHub").build();

    connection.start().then(function () {

        if (connectionID != "") {
            return;
        }
        connectionID = connection.connectionId;

        console.log(connection.state);

        joinGame();
        (<HTMLInputElement>document.getElementById("canvas")).disabled = false;
        startAnimating(30);
    }).catch(function (err) {
        //to do: add notification for user 
        return console.error(err.toString());
    });

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
          player.background = element.background;
          break;
		}
	  }
	});

    connection.on("RecieveItemInfo", function (newItems) {
        items = JSON.parse(newItems);
    });

    connection.on("RecieveNotification", function (message) {
        notification.text = JSON.parse(message);
        console.log(notification.text);
    });

    connection.on("RecieveId", function (id) {
        player.id = id;
        controls.id = id;
        console.log(player.id);
    });

    connection.on("ClientRequestHandler", function (requests) {
        let requestValues = JSON.parse(requests);
        if (requestValues.length > 0) {
            NetworkManager.ProccessServerRequests(requestValues);
        }
    });

}



const background = new Image();
background.src = player.background;

function drawSprite(img, sX, sY, sW, sH, dX, dY, dW, dH) {
  const playerSprite = new Image();
  playerSprite.src = img;
  context.drawImage(playerSprite, sX, sY, sW, sH, dX, dY, dW, dH);
}

window.addEventListener("keydown", function(e) {
  keys[e.key] = true;
});

window.addEventListener("keyup", function(e) {
  delete keys[e.key];
});

function movePlayer() {

    if (keys["ArrowUp"]) {
        controls.up = true;
    }
    if (keys["ArrowLeft"]) {
        controls.left = true;
    }
    if (keys["ArrowDown"]) {
        controls.down = true;
    }
    if (keys["ArrowRight"]) {
        controls.right = true;
    }
    if (keys["z"]) {
        controls.undo = true;
    }
}

//function handlePlayerFrame() {
//  if(player.frameX < 3 && player.moving) player.frameX++;
//  else player.frameX = 0;
//}

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
function sendPlayerControlsToServer() {
    if (controls.up || controls.left || controls.down || controls.right || controls.undo)
        connection.invoke("UpdatePlayerMovement", JSON.stringify(controls)).catch(function (err) {
            return console.error(err.toString());
        });
    resetControls();
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
    background.src = player.background;
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
        if(el instanceof Obstacle || el instanceof Item) {
          const img = new Image();
          img.src = el.Sprite;
          context.drawImage(
            img,
            el.X,
            el.Y)
        } else {
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



    //handlePlayerFrame();
    
    //to do: send/update player info to server when it is needed
    if (player.id !== -1) {
      movePlayer();
      //sendPlayerInfoToServer();
      sendPlayerControlsToServer();
      getItems();
    }
    requestAnimationFrame(animate);
  }
}
