using Unity.Entities;
using UnityEngine;

public partial struct JumpInputSystem : ISystem
{
    public void OnUpdate(ref SystemState state)
    {
        bool pressed = Input.GetKeyDown(KeyCode.Space);

        foreach (var jump in SystemAPI.Query<RefRW<JumpInput>>())
        {
            jump.ValueRW.Pressed = pressed;
        }
    }
}
