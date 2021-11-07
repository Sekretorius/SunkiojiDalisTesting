using SignalRWebPack.Hubs;

namespace SignalRWebPack
{
    public class MoveUpCommand : ICommand
    {
        private int frame;
        private Player player;
        public MoveUpCommand(Player player)
        {
            this.player = player;
            frame = player.frameY;
        }

        public void Execute()
        {
            player.y -= player.speed;
            player.frameY = 3;
        }

        public void Undo()
        {
            player.y += player.speed;
            player.frameY = frame;
        }

    }
}