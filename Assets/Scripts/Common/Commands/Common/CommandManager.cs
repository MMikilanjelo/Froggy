using System;
using System.Collections.Generic;
using UnityEngine;

namespace Entities.Commands
{
    public class CommandManager
    {
        public Entity entity;
        public ICommand singleCommand;
        public List<ICommand> commands = new List<ICommand>();
        readonly CommandInvoker commandInvoker = new();

        // void Start(){
        //     entity = GetComponent<Entity>();
        //     singleCommand = HeroCommand.Create<MoveCommand>(entity);
            
        // }
        public void Test(){
            commands = new List<ICommand>{
                HeroCommand.Create<MoveCommand>(entity),
                HeroCommand.Create<AttackCommand>(entity),
            };
            singleCommand = HeroCommand.Create<MoveCommand>(entity);

        }
        private void ExecuteCommands(List<ICommand> commands){
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
