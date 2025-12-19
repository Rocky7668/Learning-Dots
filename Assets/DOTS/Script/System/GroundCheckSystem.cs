using Unity.Entities;
using Unity.Physics;
using Unity.Transforms;


public partial struct GroundCheckSystem : ISystem
{
    public void OnUpdate(ref SystemState state)
    {
        var physicsWorld = SystemAPI.GetSingleton<PhysicsWorldSingleton>();

        foreach(var (transform , jumpdata) in SystemAPI.Query<RefRO<LocalTransform>, RefRW<JumpData>>())
        {
            var rayStart = transform.ValueRO.Position;
            var rayEnd = transform.ValueRO.Position + new Unity.Mathematics.float3(0, -0.2f, 0);

            RaycastInput ray = new RaycastInput
            {
                Start = rayStart,
                End = rayEnd,
                Filter = CollisionFilter.Default
            };
             
            jumpdata.ValueRW.IsGrounded = physicsWorld.CastRay(ray);
        }
    }
}
