using SignalRWebPack.Hubs;
using System.Collections.Generic;

namespace SignalRWebPack
{
    public class PlayerControl
    {
        private List<ICommand> commands;

        private Player player;
        public PlayerControl(Player player)
        {
            commands = new List<ICommand>();
            this.player = player;
        }
        public void MoveLeft()
        {
            ICommand command = new MoveLeftCommand(player);
            command.Execute();
            commands.Add(command);
        }
        public void MoveRight()
        {
            ICommand command = new MoveRightCommand(player);
            command.Execute();
            commands.Add(command);
        }
        public void MoveUp()
        {
            ICommand command = new MoveUpCommand(player);
            command.Execute();
            commands.Add(command);
        }
        public void MoveDown()
        {
            ICommand command = new MoveDownCommand(player);
            command.Execute();
            commands.Add(command);
        }

        public void Undo()
        {
            if (commands.Count > 0)
            {
                ICommand command = commands[commands.Count-1];
                command.Undo();
                commands.Remove(command);
            }
        }
    }
}