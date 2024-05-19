using UnityEngine;
using Game.Systems;
using Game.GridManagement.Tiles;
using Game.Managers;
namespace Game.Entities
{

	public class EntityFactory
	{
		public Hero SpawnHero(HeroTypes heroType, Transform transform, Tile tile)
		{
			if (ResourceSystem.Instance.TryGetHeroData(heroType, out HeroData heroData))
			{
				var heroInstance = EntitySpawnerManager.Instantiate(heroData.Prefab, transform.position , Quaternion.identity);
				InitializeHero(heroData, heroInstance, tile);
				return heroInstance;
			}
			return null;
		}
		private void InitializeHero(HeroData heroData, Hero heroInstance, Tile tile)
		{
			heroInstance.InitializeAbilities(heroData.AbilitiesDefinitions);
			heroInstance.SetOccupiedTile(tile);
			tile.SetOccupiedEntity(heroInstance);
		}
	}
}

