using System;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Entities.Commands
{
    public class CommandManager
    {
        public Entity entity;
        readonly CommandInvoker commandInvoker = new();
        public CommandManager (Entity entity){
            this.entity = entity;
        }
        public void ExecuteCommands(List<ICommand> commands){
            foreach(var command in commands){
                if (command.IsExecuting){
                    continue;
                }
                commandInvoker.ExecuteSingleCommand(command);
            }
        }

        public void ExecuteSingleCommand(ICommand command){
            if(command.IsExecuting){
                return;
            }
            commandInvoker.ExecuteSingleCommand(command);
        }

    }
    public class CommandInvoker
    {
        public void ExecuteSingleCommand(ICommand command){
            command.Execute();
        }
    }
}
