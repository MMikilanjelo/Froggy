using Game.Entities;
using Game.GridManagement.Tiles;
using Game.Utilities.Singletons;
namespace Game.Managers{
    public class PlayerSelectionManager : Singleton<PlayerSelectionManager>
    {
        public Tile SelectedTile{get;private set;}
        public Hero SelectedHero{get;private set;}
        protected override void Awake(){
        }
        private void OnEnable(){
            Tile.OnClickTile += SetSelectedTile;
            Tile.OnClickTile += SetSelectedHero;
        }
        private void OnDisable(){
            Tile.OnClickTile -= SetSelectedTile;    
            Tile.OnClickTile -= SetSelectedHero;
        }
        public void SetSelectedTile(Tile tile) => SelectedTile = tile;
        public void SetSelectedHero(Tile tile){
            if(tile.OccupiedEntity is Hero){
                var hero =  tile.OccupiedEntity as Hero;
                UpdateSelectedHero(hero);
            }
        }
        public void UpdateSelectedHero(Hero hero) {
            SelectedHero = hero;
            EventBus<HeroSelectedEvent>.Raise(new HeroSelectedEvent {
                hero = SelectedHero
            });
        } 
            
    }
    public struct HeroSelectedEvent : IEvent{
        public Hero hero;
    }
}
