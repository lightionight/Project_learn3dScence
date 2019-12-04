using UnityEngine;
using System.Collections;

public class EnemyType_1 : MonoBehaviour
{
    private bool isGround = false;
    private float speed = 1f;

    void Start()
    {
    }
    void Update()
    {
        if (isGround)
        {
            speed = -speed;
        }
        transform.position = Vector3.Lerp()
        
        Debug.Log(isGround);
        
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "CollinderBoxBlock")
        {
            isGround = true;
        }
    }
}
