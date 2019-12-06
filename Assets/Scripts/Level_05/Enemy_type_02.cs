using UnityEngine;

public class Enemy_type_02 : MonoBehaviour
{
    private EnemyControllerBase enemyControllerBase;
    private string rigi2dStatu = "default";
    void Start()
    {
        enemyControllerBase = gameObject.AddComponent<EnemyControllerBase>();
    }

    // Update is called once per frame
    void Update()
    {
        enemyControllerBase.Enemy_type_02(gameObject, rigi2dStatu);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Ground":
                rigi2dStatu = "OnGround";
                break;
        }
    }

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    switch (collision.gameObject.tag)
    //    {
    //        case "Ground":
    //            rigi2dStatu = "OnGround";
    //            break;
    //    }
    //}
}
