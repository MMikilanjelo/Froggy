
using GridManagement.Tiles;

namespace Entity
{   
    public interface IEntity
    {
        Tile OccupiedTile{get;}
        void SetOccupiedTile(Tile tile);
    }
}

