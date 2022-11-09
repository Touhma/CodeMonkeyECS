using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;

public readonly partial struct MoveToPositionAspect : IAspect
{
    private readonly Entity _entity;

    private readonly TransformAspect _transformAspect;
    private readonly RefRO<SpeedData> _speedData;
    private readonly RefRW<TargetPositionData> _target;

    public void Move(float deltaTime)
    {
        float3 dir = math.normalize(_target.ValueRW.Value - _transformAspect.Position);
        _transformAspect.Position += dir * deltaTime * _speedData.ValueRO.Value;
    }

    public void TestReachedTarget(RefRW<RandomData> random)
    {
        const float targetDistance = .5f;
        if (math.distance(_transformAspect.Position, _target.ValueRW.Value) < targetDistance)
        {
            _target.ValueRW.Value = GetRandomPosition(random);
        }
    }

    private float3 GetRandomPosition(RefRW<RandomData> random)
    {
        return new float3(random.ValueRW.Random.NextFloat(0f, 15f), 1, random.ValueRW.Random.NextFloat(0f, 15f));
    }
}