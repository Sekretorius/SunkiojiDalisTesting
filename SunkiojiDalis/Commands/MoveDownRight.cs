using SignalRWebPack.Hubs;

namespace SignalRWebPack
{
    public class MoveRightCommand : ICommand
    {
        private int frame;
        private Player player;
        public MoveRightCommand(Player player)
        {
            this.player = player;
            frame = player.frameY;
        }

        public void Execute()
        {
            player.x += player.speed;
            player.frameY = 2;
        }

        public void Undo()
        {
            player.x -= player.speed;
            player.frameY = frame;
        }

    }
}