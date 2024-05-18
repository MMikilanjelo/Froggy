
using UnityEngine;
namespace Game.Entities.Commands
{
    public abstract class HeroCommand : ICommand
    {
        protected Entity hero;

        public bool IsExecuting { get => isExecuting_;}
        protected bool isExecuting_;

        protected HeroCommand(Entity entity) {
            hero = entity;
        }

        public abstract void Execute();
        public static T Create<T>(Entity hero) where T : HeroCommand {
            var constructor = typeof(T).GetConstructor(new[] { typeof(Entity) });

            if (constructor != null){
                return (T)constructor.Invoke(new object[] { hero });
            }
            else{
                Debug.LogError($"No constructor found in {typeof(T)} that accepts an Entity parameter.");
                return null;
            }
        }
    }

    public class AttackCommand : HeroCommand
    {
        public AttackCommand(Entity entity) : base(entity)
        {
        }

        public override void Execute() { 
        }
    }
}

