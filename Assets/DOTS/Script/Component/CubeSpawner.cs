using Unity.Entities;
using UnityEngine;

public struct CubeSpawner : IComponentData
{
    public Entity Prefab;
    public int Count;
    public float Spacing;
}
