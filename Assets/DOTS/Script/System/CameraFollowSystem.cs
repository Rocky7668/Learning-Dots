using Unity.Entities;
using Unity.Transforms;
using UnityEngine;

[UpdateInGroup(typeof(PresentationSystemGroup))]
public partial class CameraFollowSystem : SystemBase
{
    protected override void OnUpdate()
    {
        float deltaTime = SystemAPI.Time.DeltaTime;

        CameraFollowAuthoring cam = Object.FindFirstObjectByType<CameraFollowAuthoring>();
        if(cam == null) return;

        foreach (var transform in SystemAPI.Query<RefRW<LocalTransform>>().WithAll<PlayerTag>())
        {
            Vector3 targetPosition = transform.ValueRW.Position + new Unity.Mathematics.float3(cam.offset.x, cam.offset.y, cam.offset.z);

            Camera.main.transform.position = Vector3.Lerp(Camera.main.transform.position, targetPosition, cam.smoothSpeed * deltaTime);

            break; // Only follow the first player found
        }
    }
}
