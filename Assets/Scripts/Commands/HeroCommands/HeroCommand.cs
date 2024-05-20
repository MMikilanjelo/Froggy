
using UnityEngine;
namespace Game.Entities.Commands {
	public abstract class HeroCommand : ICommand {
		protected Entity entity_;

		public bool IsExecuting { get => isExecuting_; }
		protected bool isExecuting_;

		protected HeroCommand(Entity entity) {
			entity_ = entity;
		}

		public abstract void Execute();
		public static T Create<T>(Entity entity_) where T : HeroCommand {
			var constructor = typeof(T).GetConstructor(new[] { typeof(Entity) });

			if (constructor != null) {
				return (T)constructor.Invoke(new object[] { entity_ });
			}
			else {
				Debug.LogError($"No constructor found in {typeof(T)} that accepts an Entity parameter.");
				return null;
			}
		}
	}

	public class AttackCommand : HeroCommand {
		public AttackCommand(Entity entity_) : base(entity_) {
		}

		public override void Execute() {
		}
	}
}

