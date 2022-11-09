using Unity.Entities;

public partial class PlayerSpawnerSystem : SystemBase
{
    protected override void OnUpdate()
    {
        EntityQuery query = EntityManager.CreateEntityQuery(typeof(PlayerTag));
        
        PlayerSpawnerData player = SystemAPI.GetSingleton<PlayerSpawnerData>();
        RefRW<RandomData> random = SystemAPI.GetSingletonRW<RandomData>();
        
        const int spawnAmount = 20;

        EntityCommandBuffer ecb = SystemAPI.GetSingleton<BeginSimulationEntityCommandBufferSystem.Singleton>()
            .CreateCommandBuffer(World.Unmanaged);
        
        if (query.CalculateEntityCount() < spawnAmount)
        {
            Entity entity = ecb.Instantiate(player.PlayerPrefab);
            ecb.SetComponent(entity,new SpeedData
            {
                Value = random.ValueRW.Random.NextFloat(1f,3f)
            });
        }
    }
}