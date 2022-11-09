using JetBrains.Annotations;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

public class TargetPositionAuthoring : MonoBehaviour
{
    public float3 value;
}
    
[UsedImplicitly]
public class TargetPositionBaker : Baker<TargetPositionAuthoring>
{
    public override void Bake(TargetPositionAuthoring authoring)
    {
        AddComponent(new TargetPositionData()
        {
            Value = authoring.value
        });
    }
}