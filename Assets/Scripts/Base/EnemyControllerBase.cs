using UnityEngine;

public class EnemyControllerBase
{
    /*******Enemy_type_02********/
    private Animator enemyType02_Animator;
    private Rigidbody2D enemyType02_Rigidbody2D;
    private float lastTime = Time.time;
    private float moveTime = 5f;
    private float moveSpeed = 1f;
    private bool flipX = false;

    /*********Enemy_type_03********/
    
    //Enemy Type 02
    public void Enemy_type_02(GameObject gameObject,string rigi2dStatu, string hitStatu)
    {
        enemyType02_Animator = gameObject.GetComponent<Animator>();
        enemyType02_Rigidbody2D = gameObject.GetComponent<Rigidbody2D>();
        //行走判断
        if(rigi2dStatu == "OnGround")
        {
            enemyType02_Rigidbody2D.velocity = new Vector2(-moveSpeed, 0);
            if(Time.time - lastTime > moveTime)
            {
                lastTime = Time.time;
                moveSpeed = -moveSpeed;
                //Vector3 theScale = gameObject.transform.localScale;
                //theScale.x *= -1;
                //gameObject.transform.localScale = theScale;
                flipX = !flipX;
                gameObject.GetComponent<SpriteRenderer>().flipX = flipX;
                if(hitStatu == "hitBullet")
                {
                    enemyType02_Animator.SetBool("_IsBullet", true);
                }
            }

        }
    }

    public void Enemy_type_03(GameObject gameObject, string position)
    {

    }
}
