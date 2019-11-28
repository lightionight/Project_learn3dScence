using UnityEngine;
using System.Collections;
using Unity;

public class BirdFly : MonoBehaviour
{
    /*********静态变量************/
    private static readonly int pointNum = 4;
    private static readonly float speed = 0.01f;
    /*********变量************/
    private float randomDistance = 3f;
    private int pointIndex = 0;
    Vector3[] randomPointList;
    private GameObject bird;
    private float t;
    // Use this for initialization
    void Start()
    {
        bird = gameObject;
        randomPointList = RandomPoint(bird.transform.position);//获取鸟当前的vec3位置,并生成新的目的地列表;


    }

    // Update is called once per frame
    void Update()
    {
        t = (1 / ((bird.transform.position - randomPointList[pointIndex]).magnitude)) * speed;
        bird.transform.position = Vector3.Lerp(bird.transform.position, randomPointList[pointIndex], t);
        
        if((bird.transform.position - randomPointList[pointIndex]).magnitude < 0.2f)
        {
            pointIndex++;
            bird.transform.Rotate(xAngle:0, yAngle: 180, zAngle:0);
            if(pointIndex > pointNum - 1)
            {
                pointIndex = 0;

            }
            //bird.GetComponent<SpriteRenderer>().color = 
        }
        
    }
    Vector3[] RandomPoint(Vector3 vector3)
    {
        Vector3[] randomPointList = new Vector3[pointNum];
        for(int i = 0; i < pointNum; i++)
        {
            float randomX = Random.Range(vector3.x - randomDistance, vector3.x + randomDistance);
            float randomY = Random.Range(vector3.y - randomDistance, vector3.y + randomDistance);
            //float randomZ = Random.Range(vector3.z - randomDistance, vector3.z + randomDistance);
            randomPointList[i].Set(randomX, randomY, 0);
        }
        return randomPointList;
    }

    private void OnDrawGizmos()
    {
        foreach (var item in randomPointList)
        {
            Gizmos.DrawCube(item, new Vector3(1f, 1f, 1f));
        }
    }
}
