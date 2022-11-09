using JetBrains.Annotations;
using Unity.Entities;
using UnityEngine;
using Random = Unity.Mathematics.Random;

public class RandomAuthoring : MonoBehaviour
{
}
[UsedImplicitly]
public class RandomBaker : Baker<RandomAuthoring>
{
    public override void Bake(RandomAuthoring authoring)
    {
        AddComponent(new RandomData()
        {
            Random = new Random(1)
        });
    }
}