using JetBrains.Annotations;
using Unity.Entities;
using UnityEngine;

public class SpeedAuthoring : MonoBehaviour
{
    public float value;
}
    
[UsedImplicitly]
public class SpeedBaker : Baker<SpeedAuthoring>
{
    public override void Bake(SpeedAuthoring authoring)
    {
        AddComponent(new SpeedData()
        {
            Value = authoring.value
        });
    }
}