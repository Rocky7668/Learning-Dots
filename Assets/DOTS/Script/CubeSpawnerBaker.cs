using Unity.Entities;
using Unity.Transforms;
using Unity.Mathematics;

public class CubeSpawnerBaker : Baker<CubeSpawnerAuthoring>
{
    public override void Bake(CubeSpawnerAuthoring authoring)
    {
        Entity spawnerEntity = GetEntity(TransformUsageFlags.None);

        Entity prefabEntity = GetEntity(authoring.cubePrefab, TransformUsageFlags.Dynamic);

        AddComponent(spawnerEntity, new CubeSpawner
        {
            Prefab = prefabEntity,
            Count = authoring.count,
            Spacing = authoring.spacing
        });
    }
}
