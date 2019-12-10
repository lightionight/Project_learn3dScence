using UnityEngine;
using System.Collections;

public class Enemy_SixStar : MonoBehaviour
{
    private float yMin;
    private float yMax;
    private float speed = 5f;

    // Use this for initialization
    void Start()
    {
        yMin = transform.position.y - 5f;
        yMax = transform.position.y + 5f;
    }

    // Update is called once per frame
    void Update()
    {
        AutoMove(gameObject);
    }
    void AutoMove(GameObject enemy)
    {
        enemy.transform.position += Vector3.up * Time.deltaTime * speed;
        if (enemy.transform.position.y >= yMax)
        {
            
            speed = -speed;
        }
        else if(enemy.transform.position.y <= yMin)
        {
            speed = -speed;
        }
        

    }
}
