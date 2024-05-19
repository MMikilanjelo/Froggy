using System.Collections.Generic;
using Game.Entities;
using Game.Entities.Commands;
using Game.Managers;
using Game.Helpers;
using UnityEngine;
namespace Game.Architecture.AbilitySystem {
	public class AbilityController {

		private readonly AbilityModel model_;
		private readonly AbilityView view_;
		private Hero hero_;
		private AbilityController(AbilityView abilityView, AbilityModel abilityModel) {
			view_ = abilityView;
			model_ = abilityModel;

			ConnectView();
			ConnectModel();
		}
		private void ConnectModel() {
			EventBinding<HeroSelectedEvent> heroSelectedEventBinding = new EventBinding<HeroSelectedEvent>(OnHeroSelected);
			EventBus<HeroSelectedEvent>.Register(heroSelectedEventBinding);
		}
		private void OnHeroSelected(HeroSelectedEvent heroSelectedEvent) {
			hero_ = heroSelectedEvent.hero;

			UpdateButtons();
		}
		private void ConnectView() {
			for (int i = 0; i < view_.buttons.Length; i++) {
				view_.buttons[i].RegisterListener(OnAbilityButtonPressed);
			}
			GameManager.AfterGameStateChanged += () => {
				view_.SetButtonsInteractable(GameHelpers.IsPlayerTurn() && hero_.CanPerformActions());
			};
		
		}
		private void UpdateButtons() {
			if (model_.abilities_.TryGetValue(hero_, out ObservableList<Ability> abilities)) {
				view_.UpdateButtonSprites(abilities);
				view_.SetButtonsInteractable(hero_.CanPerformActions() && GameHelpers.IsPlayerTurn());
			}
		}
		private void OnAbilityButtonPressed(int index) {
			if (model_.abilities_.TryGetValue(hero_, out ObservableList<Ability> abilities)) {
				if (abilities[index] == null) {
					return;
				}
				var command = abilities[index].GetAbilityCommand();
				command.Execute();
				UpdateButtons();
			}
		}

		public class Builder {
			readonly AbilityModel model_ = new AbilityModel();

			public Builder WithModel() {
				model_.Initialize();
				return this;
			}
			public AbilityController Build(AbilityView view) {
				return new AbilityController(view, model_);
			}
		}
	}
}

