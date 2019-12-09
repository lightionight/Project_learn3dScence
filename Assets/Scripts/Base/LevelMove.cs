using UnityEngine;
using System.Collections;

public class LevelMove : MonoBehaviour
{
    private float scroll;
    private Vector3 followPosition,currentPosition;
    // Use this for initialization


    // Update is called once per frame
    void Update()
    {
        scroll = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>().position.x;
        currentPosition = gameObject.GetComponent<Transform>().position;
        followPosition = new Vector3(scroll, currentPosition.y, currentPosition.z);
        if (Mathf.Abs(followPosition.x - currentPosition.x) > 5)
            gameObject.transform.position = Vector3.Lerp(currentPosition, followPosition, Time.deltaTime);
    }
}
