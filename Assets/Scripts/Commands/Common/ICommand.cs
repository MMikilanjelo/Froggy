using System;

namespace Game.Entities.Commands {
    public interface ICommand {
        void Execute();
        bool IsExecuting { get;}
				void Cancel();
    }
}

