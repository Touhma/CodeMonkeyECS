using JetBrains.Annotations;
using Unity.Burst;
using Unity.Entities;
using Unity.Jobs;

[UsedImplicitly]
[BurstCompile]
public partial struct MovingISystem : ISystem
{
    [BurstCompile]
    public void OnCreate(ref SystemState state)
    {
    }

    [BurstCompile]
    public void OnDestroy(ref SystemState state)
    {
    }

    [BurstCompile]
    public void OnUpdate(ref SystemState state)
    {
        RefRW<RandomData> random = SystemAPI.GetSingletonRW<RandomData>();

        float deltaTime = SystemAPI.Time.DeltaTime;
        JobHandle moveHandle = new MoveJob
        {
            DeltaTime = deltaTime
        }.ScheduleParallel(state.Dependency);
        
        moveHandle.Complete();
        
        new ReachTargetTestJob
        {
            RandomField = random
        }.Run();
    }
}