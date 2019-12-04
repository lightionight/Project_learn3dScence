using UnityEngine;


public class EnemyType_1 : MonoBehaviour
{
    private bool isBoxBlock = false;
    private float speed = 1f;
    private Rigidbody2D enemytype_1Rigi2D;

    void Start()
    {
        enemytype_1Rigi2D = gameObject.GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        enemytype_1Rigi2D.velocity = Vector2.left * speed;
        if (isBoxBlock)
        {
            speed = -speed;
            isBoxBlock = false;
        }
        Debug.Log(speed.ToString());
        
        
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "CollinderBoxBlock")
        {
            isBoxBlock = true;
        }
            
    }
}
