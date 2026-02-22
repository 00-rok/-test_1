using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameManager manager;
    public GameObject scanObject;
    BoxCollider2D boxCollider;

    public Vector2 inputVec;
    public Vector3 dirVec;

    Rigidbody2D rigid;
    SpriteRenderer spriter;
    Animator anim;
    public float speed;

    public Sprite upSprite;
    public Sprite downSprite;
    public Sprite leftSprite;
    public Sprite rightSprite;
    public LayerMask ignorePlayerLayer;

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        spriter = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();
        speed = 20f;


    }


    // Update is called once per frame
    void Update()
    {
        if (manager.isTalk == false)
        {
            // 1. 입력 받기
            inputVec.x = Input.GetAxisRaw("Horizontal");
            inputVec.y = Input.GetAxisRaw("Vertical");

            // 2. 방향 전환 (시각적 처리)
            //if (inputVec.x != 0) spriter.flipX = inputVec.x < 0;
        }
        //GetAxisRaw 딱딱 끊김
        //GetAxis   부드러움


        //rigid.MovePosition(rigid.position + nextVec);//위치이동으로 바꿔야함

        if (inputVec.x != 0 || inputVec.y != 0)
        {
            // 정규화(Normalize)를 해야 대각선 방향도 길이가 1인 벡터가 되어 정확합니다.
            dirVec = inputVec.normalized;
        }


        if (inputVec.x != 0 || inputVec.y != 0)
        {
            // 1. 좌우 이동 판단 (가장 높은 절대값을 가진 방향으로 판단)
            if (Mathf.Abs(inputVec.x) > Mathf.Abs(inputVec.y))
            {
                if (inputVec.x > 0)
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
                if (inputVec.y > 0)
                {
                    spriter.sprite = upSprite; // 위쪽 스프라이트 사용
                }
                else
                {
                    spriter.sprite = downSprite; // 아래쪽 스프라이트 사용
                }
            }
        }
        if (Input.GetKeyDown(KeyCode.Space) && scanObject != null)//스페이스를 누르면 상호작용
        {
            Debug.Log("This is :" + scanObject.name);
            manager.Action(scanObject);
        }
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (manager.isTalk == false)
            {
                manager.Call_inventory();
            }
            else
            {
                manager.Off_Call_inventory();
            }
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (manager.isTalk == false)
            {
                manager.Call_Menu();
            }
            else
            {
                manager.Off_Call_Menu();
            }
        }
    } 



 /*   void action(Vector3 nextVec)
    {
        rigid.MovePosition(nextVec);
        //move만 넣어보자
    }*/
    void FixedUpdate()
    {
        Vector2 raycastOrigin = rigid.position;
        raycastOrigin.y -= 3f;

        if (manager.isTalk == false)
        {
                // 비트 반전(~)을 사용하여 해당 레이어를 제외!
            
            Vector2 nextVec = inputVec.normalized * speed * Time.fixedDeltaTime;
            rigid.MovePosition(rigid.position + nextVec);

            Debug.DrawRay(raycastOrigin, dirVec * 3f, new Color(0, 1, 0));//초록색 광선을 쏴서 Raycast가 어디로 가는지 보여줌
            RaycastHit2D rayHit = Physics2D.Raycast(raycastOrigin, dirVec, 3f, ~ignorePlayerLayer);
            //RaycastHit2D rayHit = Physics2D.Raycast(raycastOrigin, dirVec,3f);//실제 어떤 오브젝트와 닿아있는지 판가름되는 광선을 3f까지 쏨

            if (rayHit.collider != null)
            {
                scanObject = rayHit.collider.gameObject;//Raycast에 닿은 물체를 scanObject로 정보를 담음
            }
            else
            {
                scanObject = null;
            }
        }

    }   

}
