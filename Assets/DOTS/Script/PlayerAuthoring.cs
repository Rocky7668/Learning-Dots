using Unity.Entities;
using Unity.Physics;
using UnityEngine;

public class PlayerAuthoring : MonoBehaviour
{
    public float speed = 5f;
    public float JumpForce = 7f;


    class Baker : Baker<PlayerAuthoring>
    {
        public override void Bake(PlayerAuthoring authoring)
        {
            Entity entity = GetEntity(
                TransformUsageFlags.Dynamic | TransformUsageFlags.Renderable
            );

            AddComponent(entity, new Speed {
                Value = authoring.speed
            });
            AddComponent(entity, new JumpData {
                JumpForce = authoring.JumpForce,
                IsGrounded = true
            });

            AddComponent<MoveInput>(entity);
            AddComponent<PlayerTag>();
            AddComponent<JumpInput>();

            // physics Components

            AddComponent<PhysicsVelocity>(entity);
            AddComponent<PhysicsMass>(entity);
            AddComponent<PhysicsCollider>(entity);
            AddComponent<PhysicsGravityFactor>(entity);


        }
    }

}
