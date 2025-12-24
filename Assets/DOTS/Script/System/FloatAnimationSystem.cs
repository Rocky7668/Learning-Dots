using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

public partial struct FloatAnimationSystem : ISystem
{
    public void OnUpdate(ref SystemState state)
    {
        float time = (float)SystemAPI.Time.ElapsedTime;

        foreach (var (animation, transform) in
                 SystemAPI.Query<RefRO<FloatAnimation>, RefRW<LocalTransform>>())
        {
            float newY = animation.ValueRO.StartY + Mathf.Sin(time * animation.ValueRO.Speed) * animation.ValueRO.Amplitude;
            
            float3 pos = transform.ValueRO.Position;
            pos.y = newY;
            transform.ValueRW.Position = pos;
        }
    }
}
