using UnityEngine;
namespace Entities.Commands{
    public abstract  class HeroCommand : ICommand
    {
        protected Entity hero;
        public void SetParent(Entity entity){
            hero = entity;
        }
        public abstract void Execute();
        public static T Create<T>(Entity hero) where T : HeroCommand , new (){
            T newCommand = new T();
            newCommand.SetParent(hero);
            return newCommand;
        }
    }
    public class MoveCommand : HeroCommand
    {
        public override void Execute() {  
            Debug.Log("Moving");
        }
    }
    
    public class AttackCommand : HeroCommand
    {
        public override void Execute() {  
            Debug.Log("Attacking");
        }
    }
}

