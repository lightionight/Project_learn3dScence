using UnityEngine;

class EnemyController
{
    /*******Enemy_type_02********/
    private float lastTime = Time.time;
    private float moveTime = 5f;
    private float moveSpeed = 1f;
    private bool EnemyType02_flipX = false;

    /*********Enemy_type_03********/
    
    //Enemy Type 02
    public void Enemy_type_02(GameObject gameObject,string rigi2dStatu, string hitStatu)
    {
        Animator enemyType02_Animator       = gameObject.GetComponent<Animator>();
        Rigidbody2D enemyType02_Rigidbody2D = gameObject.GetComponent<Rigidbody2D>();
        
        if(rigi2dStatu == "OnGround")
        {
            enemyType02_Rigidbody2D.velocity = new Vector2(-moveSpeed, 0);
            if(Time.time - lastTime > moveTime)
            {
                lastTime = Time.time;
                moveSpeed = -moveSpeed;
                EnemyType02_flipX = !EnemyType02_flipX;
                gameObject.GetComponent<SpriteRenderer>().flipX = EnemyType02_flipX;
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
