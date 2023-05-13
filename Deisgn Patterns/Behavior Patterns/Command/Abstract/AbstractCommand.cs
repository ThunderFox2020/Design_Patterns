using System;
using System.Collections.Generic;

namespace Design_Patterns.Behavior_Patterns.Command.Abstract
{
    public class Tester
    {
        public void Test()
        {
            Receiver1 receiver1 = new Receiver1();
            Receiver2 receiver2 = new Receiver2();

            Command1ForReceiver1 command11 = new Command1ForReceiver1(receiver1);
            Command2ForReceiver1 command21 = new Command2ForReceiver1(receiver1);
            Command1ForReceiver2 command12 = new Command1ForReceiver2(receiver2);
            Command2ForReceiver2 command22 = new Command2ForReceiver2(receiver2);
            MacroCommand macroCommand = new MacroCommand(command11, command21, command12, command22);

            Invoker invoker = new Invoker(command11);
            invoker.Action();
            invoker.Undo();
            invoker.Redo();
            invoker.Command = command21;
            invoker.Action();
            invoker.Undo();
            invoker.Redo();
            invoker.Command = command12;
            invoker.Action();
            invoker.Undo();
            invoker.Redo();
            invoker.Command = command22;
            invoker.Action();
            invoker.Undo();
            invoker.Redo();

            Console.WriteLine();

            invoker.Command = macroCommand;
            invoker.Action();
            invoker.Undo();
            invoker.Redo();
        }
    }

    public class Receiver1
    {
        public void Action1() => Console.WriteLine("Action 1 on receiver 1");
        public void Action2() => Console.WriteLine("Action 2 on receiver 1");
    }
    public class Receiver2
    {
        public void Action1() => Console.WriteLine("Action 1 on receiver 2");
        public void Action2() => Console.WriteLine("Action 2 on receiver 2");
    }

    public interface ICommand
    {
        public void Action();
        public void Undo();
        public void Redo();
    }
    public class Command1ForReceiver1 : ICommand
    {
        public Command1ForReceiver1(Receiver1 receiver) => Receiver1 = receiver;

        public Receiver1 Receiver1 { private get; set; }

        public void Action() => Receiver1.Action1();
        public void Undo() { /* Логика отмены действия */ }
        public void Redo() { /* Логика повтора действия */ }
    }
    public class Command2ForReceiver1 : ICommand
    {
        public Command2ForReceiver1(Receiver1 receiver) => Receiver1 = receiver;

        public Receiver1 Receiver1 { private get; set; }

        public void Action() => Receiver1.Action2();
        public void Undo() { /* Логика отмены действия */ }
        public void Redo() { /* Логика повтора действия */ }
    }
    public class Command1ForReceiver2 : ICommand
    {
        public Command1ForReceiver2(Receiver2 receiver) => Receiver2 = receiver;

        public Receiver2 Receiver2 { private get; set; }

        public void Action() => Receiver2.Action1();
        public void Undo() { /* Логика отмены действия */ }
        public void Redo() { /* Логика повтора действия */ }
    }
    public class Command2ForReceiver2 : ICommand
    {
        public Command2ForReceiver2(Receiver2 receiver) => Receiver2 = receiver;

        public Receiver2 Receiver2 { private get; set; }

        public void Action() => Receiver2.Action2();
        public void Undo() { /* Логика отмены действия */ }
        public void Redo() { /* Логика повтора действия */ }
    }
    public class MacroCommand : ICommand
    {
        public MacroCommand(params ICommand[] commands) => Commands = new List<ICommand>(commands);

        public List<ICommand> Commands { private get; set; }

        public void Action()
        {
            foreach (ICommand command in Commands)
                command.Action();
        }
        public void Undo()
        {
            foreach (ICommand command in Commands) { /* Логика отмены действия */ }
        }
        public void Redo()
        {
            foreach (ICommand command in Commands) { /* Логика повтора действия */ }
        }
    }

    public class Invoker
    {
        public Invoker(ICommand command) => Command = command;

        private Stack<ICommand> actionCommands = new Stack<ICommand>();
        private Stack<ICommand> undoCommands = new Stack<ICommand>();

        public ICommand Command { private get; set; }

        public void Action()
        {
            actionCommands.Push(Command);
            Command.Action();
        }
        public void Undo()
        {
            if (actionCommands.Count > 0)
            {
                ICommand command = actionCommands.Pop();
                undoCommands.Push(command);
                command.Undo();
            }
        }
        public void Redo()
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