using Game.Entities.Commands;

namespace Game.Architecture.AbilitySystem
{
    public class Ability 
    {
        private ICommand command_;
        public AbilityData Data{get;private set;}
        public Ability(ICommand command , AbilityData data){
            command_ = command;
            Data = data;
        }
        public ICommand GetAbilityCommand(){
            return command_;
        }
    }
}
