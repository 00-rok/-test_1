using UnityEngine;

public class test_1 : MonoBehaviour
{
    public GameObject tri;
    public Vector2 inputVec;//(x,y)
    float speed = 10f;
    public Rigidbody2D rigid;
    public Transform trs;
    public Vector2 nextVecccccccccc;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    void Update()
    {
        
        
        inputVec.x = Input.GetAxisRaw("Horizontal");
        inputVec.y = Input.GetAxisRaw("Vertical");

        nextVecccccccccc = inputVec.normalized * speed * Time.fixedDeltaTime;
        Vector2 nextVec = inputVec.normalized * speed * Time.fixedDeltaTime;
    }






}
