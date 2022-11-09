using Unity.Entities;

public partial class MovingSystemBase : SystemBase
{
    protected override void OnUpdate()
    {
        /*
        RefRW<RandomData> random = SystemAPI.GetSingletonRW<RandomData>();
        //Idiomatic Foreach
        foreach (MoveToPositionAspect mtpAspect in SystemAPI.Query<MoveToPositionAspect>())
        {
            mtpAspect.Move(SystemAPI.Time.DeltaTime, random);
        }
        */
    }
}