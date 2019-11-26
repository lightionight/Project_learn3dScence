using UnityEngine;

public class WaysPoints : MonoBehaviour
{
    static readonly int points = 10;
    Vector3[] pointList = new Vector3[points];
    Collider[] enemysCount = new Collider[points];
    static readonly float speed = 0.05f;
    int pointChange = 0;

    // Start is called before the first frame update
    void Start()
    {
        float parentPositionX = this.transform.position.x;
        float parentPositionZ = this.transform.position.z;
        float moveRange = 6;
        
        for (int i = 0; i < points; i++)
        {
            pointList[i].Set(UnityEngine.Random.Range(parentPositionX - moveRange, parentPositionX + moveRange), 0, UnityEngine.Random.Range(parentPositionZ - moveRange, parentPositionZ + moveRange));

        }
    }

    // Update is called once per frame
    void Update()
    {
         if (GetComponentInChildren<Collider>().enabled == true)
        {
            enemysCount[0] = GetComponentInChildren<Collider>().gameObject.GetComponent<Collider>();
        }
        
        if(enemysCount.Length != 0)
        {
            float t = (1 / (enemysCount[0].transform.position - pointList[pointChange]).magnitude) * speed;
            enemysCount[0].gameObject.transform.position = Vector3.Lerp(enemysCount[0].gameObject.transform.localPosition, pointList[pointChange], t);
            if((enemysCount[0].gameObject.transform.position - pointList[pointChange]).magnitude < 0.2f)
            {
                pointChange++;
            }
            if(pointChange == points)
            {
                pointChange = 0;
            }
            
            


        }
    }
}
