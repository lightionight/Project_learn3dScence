using UnityEngine;

public class Enemy_type_02 : MonoBehaviour
{
    private EnemyControllerBase enemyControllerBase;
    private string rigi2dStatu = null; //碰撞体的状态
    private string hitStatu = null;    //被攻击的状态
    void Start()
    {
        enemyControllerBase = new EnemyControllerBase();
    }

    // Update is called once per frame
    void Update()
    {
        enemyControllerBase.Enemy_type_02(gameObject, rigi2dStatu, hitStatu);
        rigi2dStatu = hitStatu = null;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
            rigi2dStatu = "OnGround";
        if (collision.gameObject.tag == "Bullet")
            hitStatu = "hitBullet";
    }

}
