using Unity.Entities;
using UnityEngine;
using Unity.Mathematics;
public partial struct PlayerInputSystem : ISystem
{
    public void OnUpdate(ref SystemState state)
    {
        float x = 0f;
        float y = 0f;

        if (Input.GetKey(KeyCode.A)) x -= 1f;
        if (Input.GetKey(KeyCode.D)) x += 1f;
        if (Input.GetKey(KeyCode.W)) y += 1f;
        if (Input.GetKey(KeyCode.S)) y -= 1f;

        foreach (var input in SystemAPI.Query<RefRW<MoveInput>>())
        {
            input.ValueRW.Value = new float2(x, y);
        }
    }
}