using SignalRWebPack.Hubs;

namespace SignalRWebPack
{
    public class MoveDownCommand : ICommand
    {
        private int frame;
        private Player player;
        public MoveDownCommand(Player player)
        {
            this.player = player;
            frame = player.frameY;
        }

        public void Execute()
        {
            player.y += player.speed;
            player.frameY = 0;
        }

        public void Undo()
        {
            player.y -= player.speed;
            player.frameY = frame;
        }
    }
}