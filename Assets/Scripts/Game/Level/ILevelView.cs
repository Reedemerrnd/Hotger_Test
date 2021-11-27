using UnityEngine.Tilemaps;

namespace BallGame.Game.Level
{
    internal interface ILevelView : IMovingView
    {
        void Construct(float XToDespawn, float XToSpawn);
        (float YTop, float YBottom) GetCorridorBounds();
        Tilemap GetTilemap();
    }
}
