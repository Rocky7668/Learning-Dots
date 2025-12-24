using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

public partial struct CubeSpawnSystem : ISystem
{
    public void OnUpdate(ref SystemState state)
    {
        var ecb = new EntityCommandBuffer(Unity.Collections.Allocator.Temp);

        foreach (var spawner in SystemAPI.Query<RefRO<CubeSpawner>>())
        {
            for (int i = 0; i < spawner.ValueRO.Count; i++)
            {
                Entity cubeEntity = ecb.Instantiate(spawner.ValueRO.Prefab);
                float3 pos = new float3((i % 20) * spawner.ValueRO.Spacing, 1, (i / 20 * spawner.ValueRO.Spacing));

                ecb.SetComponent(cubeEntity, LocalTransform.FromPosition(pos));

                ecb.AddComponent(cubeEntity, new FloatAnimation {
                    Amplitude = 0.5f,
                    Speed = 2f + (i * 0.01f),
                    StartY = 1f
                });

            }
            ecb.RemoveComponent<CubeSpawner>(SystemAPI.GetSingletonEntity<CubeSpawner>());
        }
        ecb.Playback(state.EntityManager);
        ecb.Dispose();
    }
}
