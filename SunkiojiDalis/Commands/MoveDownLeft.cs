using SignalRWebPack.Hubs;

namespace SignalRWebPack
{
    public class MoveLeftCommand : ICommand
    {
        private int frame;
        private Player player;
        public MoveLeftCommand(Player player)
        {
            this.player = player;
            frame = player.frameY;
        }

        public void Execute()
        {
            player.x -= player.speed;
            player.frameY = 1;
        }

        public void Undo()
        {
            player.x += player.speed;
            player.frameY = frame;
        }
    }
}