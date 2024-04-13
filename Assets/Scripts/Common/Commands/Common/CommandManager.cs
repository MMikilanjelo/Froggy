using System;
using System.Collections.Generic;
using UnityEngine;

namespace Entities.Commands
{
    public class CommandManager
    {
        public Entity entity;
        public ICommand singleCommand;
        private List<ICommand> commands = new List<ICommand>();
        readonly CommandInvoker commandInvoker = new();
        public CommandManager (Entity entity){
            this.entity = entity;
        }
        public void SetUpCommands(){
            commands = new List<ICommand>{
                HeroCommand.Create<MoveCommand>(entity),
                HeroCommand.Create<AttackCommand>(entity),
            };
        }
        public void AddCommand(ICommand command){
            commands.Add(command);
        }
        private void ExecuteCommands(List<ICommand> commands){
            foreach(var command in commands){
                if (command.IsExecuting){
                    return;
                }
            }
            commandInvoker.ExecuteCommands(commands);
        }
        public void Test2(){
            ExecuteCommands(commands);
        }

    }
    public class CommandInvoker
    {
        public void ExecuteCommands(List<ICommand> commands)
        {
            foreach (ICommand command in commands)
            {
                command.Execute();
            }
        }
    }
}
