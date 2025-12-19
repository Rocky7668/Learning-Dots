using Unity.Entities;
using UnityEngine;

public struct JumpData : IComponentData
{
    public float JumpForce;
    public bool IsGrounded;
}
