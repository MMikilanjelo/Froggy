using System;
using System.Collections;
using System.Collections.Generic;
using Entities;
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
        }
        public Tile GetTileAtPosition(Vector2 position){
            if(_tilesInGrid.TryGetValue(position, out var tile)) return tile;
            return null;
        }

    }
}

