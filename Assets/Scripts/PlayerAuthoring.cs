using JetBrains.Annotations;
using Unity.Entities;
using UnityEngine;

public class PlayerAuthoring : MonoBehaviour
{
}

[UsedImplicitly]
public class PlayerBaker : Baker<PlayerAuthoring>
{
    public override void Bake(PlayerAuthoring authoring)
    {
        AddComponent(new PlayerTag());
    }
}