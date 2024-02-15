using GridManagement.Tiles;

public interface ITileVisitor 
{
    void Visit(ISelectable selectableTile);
}
