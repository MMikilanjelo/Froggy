
namespace Game.GridManagement.Tiles
{
    public class GroundTile : Tile , ITileVisitable
    {
        public override bool IsWalkable() => OccupiedEntity == null;
        public void Accept(ITileVisitor tileVisitor) => tileVisitor.Visit(this);
    }
}

