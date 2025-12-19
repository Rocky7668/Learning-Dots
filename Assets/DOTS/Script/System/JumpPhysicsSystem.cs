using Unity.Entities;
using Unity.Physics;
using UnityEngine;

public partial struct JumpPhysicsSystem : ISystem
{
    public void OnUpdate(ref SystemState state)
    {
        foreach(var (velocity , jumpInput, jumpData) in SystemAPI.Query<RefRW<PhysicsVelocity>, RefRW<JumpInput>, RefRW<JumpData>>())
        {
            if (jumpInput.ValueRO.Pressed && jumpData.ValueRO.IsGrounded)
            {
                velocity.ValueRW.Linear.y = jumpData.ValueRO.JumpForce;

                jumpInput.ValueRW.Pressed = false;
                jumpData.ValueRW.IsGrounded = false;
            }
        }
    }
}
