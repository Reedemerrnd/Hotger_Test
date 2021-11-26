namespace BallGame.Game.Level
{
    internal interface ILevelView : IMovingView, IObjectView
    {
        void Construct(float XToDespawn, float XToSpawn);
        public (float YTop, float YBottom) GetCorridorBounds();
    }
}
