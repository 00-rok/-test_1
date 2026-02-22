using UnityEngine;

public struct Player_Data
{
    public Vector2 position; // 당시 위치
    public Vector2 input;    // 당시 입력값 (스프라이트 방향용)
    

    public Player_Data(Vector2 pos, Vector2 ins)
    {
        position = pos;
        input = ins;
    }
}
