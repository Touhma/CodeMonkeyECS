using Unity.Burst;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Entities;

[BurstCompile]
public partial struct ReachTargetTestJob : IJobEntity
{
    [NativeDisableUnsafePtrRestriction] public RefRW<RandomData> RandomField;

    public void Execute(MoveToPositionAspect aspect)
    {
        aspect.TestReachedTarget(RandomField);
    }
}