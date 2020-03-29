using System;
using System.Collections;
using System.Collections.Generic;
using Autofac;

namespace Adapter
{
    public interface ICommand
    {
        void Execute();
    }

    class SaveCommand : ICommand
    {
        public void Execute()
        {
            Console.Write("Saving a file");
        }
    }
    
    class OpenCommand : ICommand
    {
        public void Execute()
        {
            Console.Write("Saving a file");
        }
    }

    public class Button
    {
        private ICommand command;

        public Button(ICommand command)
        {
            if (command == null)
            {
                throw new ArgumentNullException(paramName: nameof(command));
            }
            this.command = command;
        }

        public void Click()
        {
            command.Execute();
        }
    }

    public class Editor
    {
        private IEnumerable<Button> buttons;

        public Editor(IEnumerable<Button> buttons)
        {
            this.buttons = buttons ?? throw new ArgumentNullException(nameof(buttons));
        }

        public void ClickAll()
        {
            foreach (var btn in buttons)
            {
                btn.Click();
            }
        }
    }
}