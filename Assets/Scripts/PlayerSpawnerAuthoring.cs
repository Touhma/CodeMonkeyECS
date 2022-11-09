using JetBrains.Annotations;
using Unity.Entities;
using UnityEngine;

public class PlayerSpawnerAuthoring : MonoBehaviour
{
    public GameObject playerPrefab;
}

[UsedImplicitly]
public class PlayerSpawnerBaker : Baker<PlayerSpawnerAuthoring>
{
    public override void Bake(PlayerSpawnerAuthoring authoring)
    {
        AddComponent(new PlayerSpawnerData()
        {
            PlayerPrefab = GetEntity(authoring.playerPrefab)
        });
    }
}