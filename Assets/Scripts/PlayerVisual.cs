using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;
using Random = UnityEngine.Random;

public class PlayerVisual : MonoBehaviour
{
    private Entity targetEntity;

    private void LateUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            targetEntity = GetRandomEntity();
        }

        if (targetEntity == Entity.Null) return;

        float3 follow = World.DefaultGameObjectInjectionWorld.EntityManager
            .GetComponentData<LocalToWorldTransform>(targetEntity)
            .Value.Position;
        transform.position = follow;
    }

    private Entity GetRandomEntity()
    {
        EntityQuery playerTags =
            World.DefaultGameObjectInjectionWorld.EntityManager.CreateEntityQuery(typeof(PlayerTag));
        NativeArray<Entity> playerEntities = playerTags.ToEntityArray(Allocator.Temp);

        return playerEntities.Length > 0 ? playerEntities[Random.Range(0, playerEntities.Length)] : Entity.Null;
    }
}