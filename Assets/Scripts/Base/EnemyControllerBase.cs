using UnityEngine;

public class EnemyControllerBase : MonoBehaviour
{
    /*******Enemy_type_02********/
    private Animator enemyType02_Animator;
    private Rigidbody2D enemyType02_Rigidbody2D;
    private float lastTime, moveTime,  moveSpeed;


    private void Start()
    {
        lastTime = Time.time;
        moveSpeed = 1f;
        moveTime = 5f;
    }
    //Enemy Type 02
    public void Enemy_type_02(GameObject gameObject,string rigi2dStatu)
    {
        enemyType02_Animator = gameObject.GetComponent<Animator>();
        enemyType02_Rigidbody2D = gameObject.GetComponent<Rigidbody2D>();
        AnimationEvent 
        Debug.Log(rigi2dStatu);
        if(rigi2dStatu == "OnGround")
        {
            enemyType02_Rigidbody2D.velocity = new Vector2(moveSpeed, 0);
            if(Time.time - lastTime > moveTime)
            {
                enemyType02_Animator.
                lastTime = Time.time;
                moveSpeed = -moveSpeed;
            }

        }
    }
}
