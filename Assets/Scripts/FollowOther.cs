using UnityEngine;

public class FollowOther : MonoBehaviour
{
    GameObject leader;
    GameObject follower;
    float t;
    float t2;
    static readonly float speed = 0.1f;
    static readonly int pointNum = 5;
    Vector3[] pointList = new Vector3[pointNum];
    int selectPointIndex = 0;
    float moveRange = 15f;

    // Use this for initialization
    void Start()
    {
        //找到目标对象
        leader = GameObject.Find("TeamA_Sphere");
        follower = GameObject.Find("TeamB_Sphere");
        pointList = CreatList(leader);



    }

    // Update is called once per frame
    void Update()
    {
        
            
        t2 = (1 / (follower.transform.position - pointList[selectPointIndex]).magnitude) * speed;
        Debug.Log(t2);
        leader.transform.position = Vector3.Lerp(leader.transform.position, pointList[selectPointIndex], t2);
        if ((leader.transform.position - pointList[selectPointIndex]).magnitude > 1f)
        {

            selectPointIndex++;
        }
            //Debug.Log($"I'm Moving to the Leader {(follower.transform.position).ToString()}");
            //if ((follower.transform.position - leader.transform.position).magnitude > 1.5f)
            //{
            //    t = (1 / (follower.transform.position - leader.transform.position).magnitude) * speed;
            //    follower.transform.position = Vector3.Lerp(follower.transform.position, leader.transform.position, t);
            //}
        if(selectPointIndex == 5)
        {
            selectPointIndex = 0;
        }

    }
    Vector3[] CreatList(GameObject gameObject)
    {
        Vector3[] pointList_inside = new Vector3[pointNum];
        float x = gameObject.transform.position.x;
        float y = gameObject.transform.position.y;
        float z = gameObject.transform.position.z;
        for(int i = 0; i < pointNum; i++)
        {
            pointList_inside[i].Set(Random.Range(x - moveRange, x + moveRange), y, Random.Range(z - moveRange, z + moveRange)); 
        }
        foreach (Vector3 item in pointList_inside)
        {
            Debug.Log($"This is {item.ToString()}");
        }
        return pointList_inside;
    }
}
