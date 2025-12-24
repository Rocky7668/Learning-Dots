using System.ComponentModel;
using Unity.Entities;
using UnityEngine;

public struct FloatAnimation : IComponentData
{
    public float Amplitude;
    public float Speed;
    public float StartY;
}
