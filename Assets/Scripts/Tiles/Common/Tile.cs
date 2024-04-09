using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using System;
using Entities;
namespace GridManagement.Tiles
{
    public abstract class Tile : MonoBehaviour
    { 
        public abstract TileType GetTileType();
        public ICoords Coords;
        public List<Tile> Neighbors { get; protected set; }
        public static event Action<Tile> OnClickTile;
        public virtual void Initialize( ICoords coords){
            Coords = coords;
            transform.position = Coords.Pos;
        }
        public virtual void CacheNeighbors()=>
            Neighbors = GridManager.Instance._tilesInGrid.Where(t => Coords.GetDistance(t.Value.Coords) == 1).Select(t=>t.Value).ToList();
        
        protected virtual void OnMouseDown() => OnClickTile?.Invoke(this);
        public abstract bool IsWalkable();
        public Entity OccupiedEntity{get;protected set;}
        public void SetOccupiedEntity(Entity entity) => OccupiedEntity = entity;
       
       
        #region  PathFinding
        public Tile Connection { get; private set; }
        public float G { get; private set; }
        public float H { get; private set; }
        public float F => G + H;
        public void SetConnection(Tile nodeBase) => Connection = nodeBase;
        public void SetG(float g) => G = g;
        public float GetDistance(Tile other) => Coords.GetDistance(other.Coords);
        public void SetH(float h) =>  H = h;


        #endregion
    }
    
    
    public interface ICoords {
        public float GetDistance(ICoords other);
        public Vector2 Pos { get; set; }
    }
    public struct HexCoords : ICoords {
        private readonly int _q;
        private readonly int _r;

        public HexCoords(int q, int r) {
            _q = q;
            _r = r;
            Pos = _q * new Vector2(Sqrt3, 0) + _r * new Vector2(Sqrt3 / 2, 1.5f);
        }

        public float GetDistance(ICoords other) => (this - (HexCoords)other).AxialLength();

        private static readonly float Sqrt3 = Mathf.Sqrt(3);

        public Vector2 Pos { get; set; }

        private int AxialLength() {
            if (_q == 0 && _r == 0) return 0;
            if (_q > 0 && _r >= 0) return _q + _r;
            if (_q <= 0 && _r > 0) return -_q < _r ? _r : -_q;
            if (_q < 0) return -_q - _r;
            return -_r > _q ? -_r : _q;
        }

        public static HexCoords operator -(HexCoords a, HexCoords b) {
            return new HexCoords(a._q - b._q, a._r - b._r);
        }
    }
}
