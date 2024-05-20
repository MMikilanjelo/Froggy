using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using System;
using Game.Entities;
namespace Game.GridManagement.Tiles
{
    public abstract class Tile : MonoBehaviour
    { 

        #region  Coordinates Initialization and Events
        public ICoords Coords;
        public List<Tile> Neighbors { get; protected set; }
        public static event Action<Tile> OnClickTile;
        public virtual void Initialize( ICoords coords){
            Coords = coords;
            transform.position = Coords.Pos;
        }
        public virtual void CacheNeighbors()=>
            Neighbors = GridManager.Instance.TilesInGrid
                .Where(t => Coords.GetDistance(t.Value.Coords) == 1)
                .Select(t=>t.Value).ToList();
        protected virtual void OnMouseDown() => OnClickTile?.Invoke(this);
        #endregion
        #region  Tile Data
        public abstract bool IsWalkable();
        public Entity OccupiedEntity{get;protected set;}
        public void SetOccupiedEntity(Entity entity) => OccupiedEntity = entity;
        #endregion
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
        private readonly int q_;
        private readonly int r_;

        public HexCoords(int q, int r) {
            q_ = q;
            r_ = r;
            Pos = q_ * new Vector2(Sqrt3, 0) + r_ * new Vector2(Sqrt3 / 2, 1.5f);
        }

        public float GetDistance(ICoords other) => (this - (HexCoords)other).AxialLength();

        private static readonly float Sqrt3 = Mathf.Sqrt(3);

        public Vector2 Pos { get; set; }

        private int AxialLength() {
            if (q_ == 0 && r_ == 0) return 0;
            if (q_ > 0 && r_ >= 0) return q_ + r_;
            if (q_ <= 0 && r_ > 0) return -q_ < r_ ? r_ : -q_;
            if (q_ < 0) return -q_ - r_;
            return -r_ > q_ ? -r_ : q_;
        }

        public static HexCoords operator -(HexCoords a, HexCoords b) {
            return new HexCoords(a.q_ - b.q_, a.r_ - b.r_);
        }
    }
}
