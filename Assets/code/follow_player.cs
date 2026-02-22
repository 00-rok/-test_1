using UnityEngine;
using System.Collections.Generic;

public class FollowNPC : MonoBehaviour
{
    public Player player;         // 추적할 플레이어 스크립트
    public GameManager manager;
    public int delayFrames = 10;
    //public float delayTime = 0.2f; // 지연 시간 (0.2초)

    public Sprite upSprite;
    public Sprite downSprite;
    public Sprite leftSprite;
    public Sprite rightSprite;

    // 플레이어의 과거 데이터를 담을 저장소
    Queue<Player_Data> logQueue = new Queue<Player_Data>();

    //Queue<(Vector2 position,Vector2 input)> abc = new Queue<(Vector2, Vector2)>();//원래방식



    Rigidbody2D rigid;

    SpriteRenderer spriter;

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        spriter = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        


    }

    void FixedUpdate()
    {
        if (manager.isTalk == false)
        {
            if (player.inputVec.magnitude != 0)
            {
                // 1. 매 프레임 플레이어의 데이터를 큐에 저장
                //logQueue.Enqueue(new Player_Data(player.transform.position, player.inputVec));

                logQueue.Enqueue(new Player_Data { position = player.transform.position, input = player.inputVec });
                //abc.Enqueue((player.transform.position, player.inputVec));원래 방식


            }


            if (player.inputVec.magnitude != 0 && logQueue.Count > delayFrames)
            {
                // 3. 마지막 데이터 꺼내기
                Player_Data data = logQueue.Dequeue();

                // 4. 위치 재현
                rigid.MovePosition(data.position);

                // 5. 방향(스프라이트) 재현
                if (data.input.x != 0 || data.input.y != 0)
                {
                    // 1. 좌우 이동 판단 (가장 높은 절대값을 가진 방향으로 판단)
                    if (Mathf.Abs(data.input.x) > Mathf.Abs(data.input.y))
                    {
                        if (data.input.x > 0)
                        {
                            spriter.sprite = rightSprite; // 오른쪽 스프라이트 사용
                        }
                        else
                        {
                            spriter.sprite = leftSprite; // 왼쪽 스프라이트 사용
                        }
                    }
                    // 2. 상하 이동 판단
                    else
                    {
                        if (data.input.y > 0)
                        {
                            spriter.sprite = upSprite; // 위쪽 스프라이트 사용
                        }
                        else
                        {
                            spriter.sprite = downSprite; // 아래쪽 스프라이트 사용
                        }
                    }
                }
            }
        }
    }
}