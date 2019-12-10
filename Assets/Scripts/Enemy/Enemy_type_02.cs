using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(Animator))]
public class Enemy_type_02 : MonoBehaviour
{
    private EnemyController enemyController;
    //碰撞体的状态
    private string rigi2dStatu = null; 
    //被攻击的状态
    private string hitStatu    = null;    
    void Start()
    {
        enemyController = new EnemyController();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(rigi2dStatu);
        enemyController.Enemy_type_02(gameObject, rigi2dStatu, hitStatu);
        rigi2dStatu = hitStatu = null;
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
            rigi2dStatu = "OnGround";
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
            hitStatu = "hitBullet";       
    }

}
