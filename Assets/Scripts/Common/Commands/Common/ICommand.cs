using System;

namespace Entities.Commands {
    public interface ICommand {
        void Execute();
        bool IsExecuting { get;}
    }
}

