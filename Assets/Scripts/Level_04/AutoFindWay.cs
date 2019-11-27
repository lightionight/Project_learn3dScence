using UnityEngine;
using UnityEngine.AI;

public class AutoFindWay : MonoBehaviour
{
    GameObject player;
    //float t;
    //static readonly float speed = 0.1f;
    static readonly int pointNum = 5;
    Vector3[] pointList = new Vector3[pointNum];
    int selectPointIndex = 0;
    float moveRange = 15f;
    private NavMeshAgent nav;

    // Use this for initialization
    void Start()
    {
        //找到目标对象
        player = gameObject;
        pointList = CreatList(player);
        nav = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        //t = (1 / (player.transform.position - pointList[selectPointIndex]).magnitude) * speed;
        //player.transform.position = Vector3.Lerp(player.transform.position, pointList[selectPointIndex], t);
        nav.SetDestination(pointList[selectPointIndex]);
        if ((player.transform.position - pointList[selectPointIndex]).magnitude < 0.5f)
        {
            selectPointIndex++;

        }
        //Debug.Log($"I'm Moving to the player {(follower.transform.position).ToString()}");
        if (selectPointIndex == 5)
        {
            selectPointIndex = 0;
        }

    }

    //生成玩家附近的点的方法
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
        //foreach (Vector3 item in pointList_inside)
        //{
        //    Debug.Log($"This is {item.ToString()}");
        //}
        return pointList_inside;
    }
    void OnDrawGizmos()
    {
        foreach (var item in pointList)
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(item, 1f);

        }
        // Draw a yellow sphere at the transform's position
    }

}
