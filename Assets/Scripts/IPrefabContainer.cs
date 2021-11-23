using UnityEngine;

namespace Game
{
    internal interface IPrefabContainer
    {
        GameObject BallPrefab { get; }
        GameObject LevelPrefab { get; }
        Vector3 BallSpawnPosition { get; }
    }
}