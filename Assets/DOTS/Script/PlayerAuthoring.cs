using Unity.Entities;
using UnityEngine;

public class PlayerAuthoring : MonoBehaviour
{
    public float speed = 5f;

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
            AddComponent<MoveInput>(entity);
            AddComponent<PlayerTag>();

            Debug.Log("BAKER RAN – Entity created with Speed");
        }
    }

}
