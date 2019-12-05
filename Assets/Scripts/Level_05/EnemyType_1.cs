using UnityEngine;


public class EnemyType_1 : MonoBehaviour
{
    private float moveSpeed = 1f;
    private static float originPosX, originPosLeft, originPosRight;
    private Rigidbody2D enenmyType1Rigi2d;
    private float lastTime, moveTime;
    private bool isDestroy = false;

    void Start()
    {
        enenmyType1Rigi2d = gameObject.GetComponent<Rigidbody2D>();
        originPosX = transform.position.x;
        originPosLeft = originPosX - 2f;
        originPosRight = originPosX + 2f;
        lastTime = Time.time;
        moveTime = 3f;



    }
    void Update()
    {
        if(!isDestroy)
        {
            enenmyType1Rigi2d.velocity = new Vector2(moveSpeed, 0);
            if(Time.time - lastTime > moveTime)
            {
                lastTime = Time.time;
                moveSpeed = -moveSpeed;
            }

        }
        else
        {
            enenmyType1Rigi2d.velocity = new Vector2(0, 0);
        }
        //Mathf.PingPong Methon
        //transform.position = new Vector3((Mathf.PingPong(Time.time, 4f) + originPosX), transform.position.y, transform.position.z);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            isDestroy = true;
            gameObject.GetComponent<Animator>().SetBool("_BeingHit", true);
        }
    }
}
