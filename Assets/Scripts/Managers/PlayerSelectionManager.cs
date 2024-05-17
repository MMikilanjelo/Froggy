using System;
using System.Collections;
using System.Collections.Generic;
using Entities;
using GridManagement.Tiles;
using Unity.VisualScripting;
using UnityEngine;

namespace Managers{
    public class PlayerSelectionManager : MonoBehaviour
    {
        public static PlayerSelectionManager Instance {get; private set;}
        public Tile SelectedTile{get;private set;}
        public Hero SelectedHero{get;private set;}
        private void Awake(){
            Instance = this;
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
