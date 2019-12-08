using UnityEngine;

public class Enemy_type_02 : MonoBehaviour
{
    private EnemyControllerBase enemyControllerBase;
    private string rigi2dStatu = "default";
    private string hitStatu = "default";
    void Start()
    {
        enemyControllerBase = new EnemyControllerBase();
    }

    // Update is called once per frame
    void Update()
    {
        enemyControllerBase.Enemy_type_02(gameObject, rigi2dStatu, hitStatu);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //switch (collision.gameObject.tag)
        //{
        //    case "Ground":
        //        rigi2dStatu = "OnGround";
        //        break;
        //    case "Bullet":
        //        hitStatu = "hitBullet";
        //        break;

                
        //}
        if (collision.gameObject.tag == "Ground")
            rigi2dStatu = "OnGround";
        if (collision.gameObject.tag == "Bullet")
            hitStatu = "hitBullet";
    }

}
