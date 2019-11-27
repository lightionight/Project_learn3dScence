using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Button_ChangeBallMovePoint : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
        Button btn = gameObject.GetComponent<Button>();
        btn.onClick.AddListener(OnClick);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnClick()
    {
        Debug.Log("Its Work!");
        if (GameObject.Find("Main Camera").GetComponent<FollowOther>().selectPointIndex > 3)
        {
            GameObject.Find("Main Camera").GetComponent<FollowOther>().selectPointIndex = 0;
        }
        else
        {
            GameObject.Find("Main Camera").GetComponent<FollowOther>().selectPointIndex++;

        }
        Debug.Log(GameObject.Find("Main Camera").GetComponent<FollowOther>().selectPointIndex);
    }
}
