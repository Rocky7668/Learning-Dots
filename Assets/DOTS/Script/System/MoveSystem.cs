using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using Debug = UnityEngine.Debug;

public partial struct MoveSystem : ISystem
{
    public void OnUpdate(ref SystemState state)
    {
        float deltaTime = SystemAPI.Time.DeltaTime;

        foreach (var (transform,input, speed) in SystemAPI.Query<RefRW<LocalTransform>,RefRO<MoveInput>, RefRO<Speed>>())
        {
            float3 direction = new float3(input.ValueRO.Value.x, 0, input.ValueRO.Value.y);

            transform.ValueRW.Position += direction * speed.ValueRO.Value * deltaTime;
        }
    }
}
