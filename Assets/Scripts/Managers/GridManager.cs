using System;
using System.Collections;
using System.Collections.Generic;
using Entity;
using GridManagement.Tiles;
using Managers;
using TMPro;
using Unity.VisualScripting;
using UnityEditor.PackageManager;
using UnityEngine;

namespace GridManagement
{   
    public class GridManager : MonoBehaviour
    {
        public static GridManager Instance;
        [SerializeField] private TileFactory _tileFactory;
        [SerializeField] private TileCollection _tileCollection;
        [SerializeField] private ScriptableGrid _scriptableGrid;
        public  IReadOnlyDictionary<Vector2 , Tile> _tilesInGrid;
        private void Awake(){
            Instance = this;
            _tileFactory.Initialize(_tileCollection);
            _scriptableGrid.Initialize(_tileFactory);
        }
        public void GenerateGrid()
        {
            _tilesInGrid = _scriptableGrid.GenerateGrid();
            foreach (var tile in _tilesInGrid.Values) tile.CacheNeighbors();
            EntitySpawnerManager.Instance.SpawnHero(GetTileAtPosition(new Vector2(0 , 0)), EntityTypes.Heroes.Fish);
        }
        public Tile GetTileAtPosition(Vector2 position){
            if(_tilesInGrid.TryGetValue(position, out var tile)) return tile;
            return null;
        }

    }
}

