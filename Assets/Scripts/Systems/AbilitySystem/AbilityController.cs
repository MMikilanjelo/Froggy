using System.Collections.Generic;
using Entities;
using Entities.Commands;
using Managers;
namespace Architecture.AbilitySystem
{
    public class AbilityController
    {

        private readonly AbilityModel model_;
        private readonly AbilityView view_;
        private readonly Queue<ICommand> abilityQueue = new Queue<ICommand>();
        private Hero hero => PlayerSelectionManager.Instance.SelectedHero;
        private AbilityController (AbilityView abilityView , AbilityModel abilityModel){
            view_ = abilityView;
            model_ = abilityModel;
            
            ConnectView();
            ConnectModel();
        }   
        private void ConnectModel(){
            EventBinding<HeroSelectedEvent> heroSelectedEventBinding = new EventBinding<HeroSelectedEvent>(OnHeroSelected);
            EventBus<HeroSelectedEvent>.Register(heroSelectedEventBinding);
        }
        private void OnHeroSelected(HeroSelectedEvent heroSelectedEvent){
            UpdateButtons();
        }
        private void ConnectView(){
            for (int i = 0; i < view_.buttons.Length; i++) {
                view_.buttons[i].RegisterListener(OnAbilityButtonPressed);
            }
        }
        private void UpdateButtons(){
            if(model_.abilities_.TryGetValue(hero , out ObservableList<Ability> abilities)){
                view_.UpdateButtonSprites(abilities);
            }
        }
        private void OnAbilityButtonPressed(int index){
            if(model_.abilities_.TryGetValue(hero , out ObservableList<Ability> abilities)){
                if (abilities[index] != null) {
                    abilityQueue.Enqueue(abilities[index].GetAbilityCommand());
                    var command = abilities[index].GetAbilityCommand();
                    command.Execute();
                }
            }
        }
        public class Builder {
            readonly AbilityModel model = new AbilityModel();
            
            public Builder WithModel() {
                model.Initialize();
                return this;
            }
            public AbilityController Build(AbilityView view) {
                return new AbilityController(view, model);
            }
        }
    }
}

