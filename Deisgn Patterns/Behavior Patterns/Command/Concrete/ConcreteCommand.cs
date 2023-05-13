using System;
using System.Collections.Generic;

namespace Design_Patterns.Behavior_Patterns.Command.Concrete
{
    public class Tester
    {
        public void Test()
        {
            Computer computer = new Computer();
            PlayStation playStation = new PlayStation();

            ComputerControl computerControl = new ComputerControl(computer, "Visual Studio");
            PlayStationControl playStationControl = new PlayStationControl(playStation, "Marvel's Spider-Man");
            ControlMultipleDevices controlMultipleDevices = new ControlMultipleDevices(computerControl, playStationControl);

            User user = new User(computerControl);
            user.UseDevice();
            user.UnuseDevice();
            user.ReuseDevice();
            user.Command = playStationControl;
            user.UseDevice();
            user.UnuseDevice();
            user.ReuseDevice();

            Console.WriteLine();

            user.Command = controlMultipleDevices;
            user.UseDevice();
            user.UnuseDevice();
            user.ReuseDevice();
        }
    }

    public class Computer
    {
        public void OpenProgram(string program) => Console.WriteLine($"{program} is running");
        public void CloseProgram(string program) => Console.WriteLine($"{program} is stopped");
    }
    public class PlayStation
    {
        public void StartGame(string game) => Console.WriteLine($"{game} is running");
        public void StopGame(string game) => Console.WriteLine($"{game} is stopped");
    }

    public interface ICommand
    {
        public void Action();
        public void Undo();
        public void Redo();
    }
    public class ComputerControl : ICommand
    {
        public ComputerControl(Computer computer, string program)
        {
            Computer = computer;
            Program = program;
        }

        public Computer Computer { private get; set; }
        public string Program { private get; set; }

        public void Action() => Computer.OpenProgram(Program);
        public void Undo() => Computer.CloseProgram(Program);
        public void Redo() => Computer.OpenProgram(Program);
    }
    public class PlayStationControl : ICommand
    {
        public PlayStationControl(PlayStation playStation, string game)
        {
            PlayStation = playStation;
            Game = game;
        }

        public PlayStation PlayStation { private get; set; }
        public string Game { private get; set; }

        public void Action() => PlayStation.StartGame(Game);
        public void Undo() => PlayStation.StopGame(Game);
        public void Redo() => PlayStation.StartGame(Game);
    }
    public class ControlMultipleDevices : ICommand
    {
        public ControlMultipleDevices(params ICommand[] commands) => Commands = new List<ICommand>(commands);

        public List<ICommand> Commands { private get; set; }

        public void Action()
        {
            foreach (ICommand command in Commands)
                command.Action();
        }
        public void Undo()
        {
            foreach (ICommand command in Commands)
                command.Undo();
        }
        public void Redo()
        {
            foreach (ICommand command in Commands)
                command.Action();
        }
    }

    public class User
    {
        public User(ICommand command) => Command = command;

        private Stack<ICommand> actionCommands = new Stack<ICommand>();
        private Stack<ICommand> undoCommands = new Stack<ICommand>();

        public ICommand Command { private get; set; }

        public void UseDevice()
        {
            actionCommands.Push(Command);
            Command.Action();
        }
        public void UnuseDevice()
        {
            if (actionCommands.Count > 0)
            {
                ICommand command = actionCommands.Pop();
                undoCommands.Push(command);
                command.Undo();
            }
        }
        public void ReuseDevice()
        {
            if (undoCommands.Count > 0)
            {
                ICommand command = undoCommands.Pop();
                actionCommands.Push(command);
                command.Redo();
            }
        }
    }
}