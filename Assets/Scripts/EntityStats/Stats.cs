
namespace Entities.Stats
{
    public struct Stats : IStat
    {
        private int _movmentDistance;
        public int MovmentDistance => _movmentDistance;
        public Stats(int movmentDistance)
        {
            _movmentDistance = movmentDistance;
        }
    }
}

