using UnityEngine;
using System.Collections;
using Unity;

public class BirdFlyV2 : MonoBehaviour
{
    /*********静态变量************/
    private static readonly float speed = 0.1f;
    /*********变量************/
    private GameObject bird;
    private float t;
    public Vector3 movePoint;
    public Vector2 mousePoint;
    RectTransform parentRectTransform;
    RectTransform birdRectTransform;
    // Use this for initialization
    void Start()
    {
        birdRectTransform = gameObject.GetComponent<RectTransform>();
        parentRectTransform = this.GetComponentInParent<RectTransform>();
        


    }

    // Update is called once per frame
    void Update()
    {
        //movePoint = mousePoint;//vec2转换为vec3
        t = (1 / ((birdRectTransform.anchoredPosition - mousePoint).magnitude)) * speed;       
        mousePoint = CurrentMousePosition(parentRectTransform);
        birdRectTransform.anchoredPosition = Vector2.Lerp(bird.GetComponent<RectTransform>().position, mousePoint, t);
        
        
        
    }
    Vector2 CurrentMousePosition(RectTransform transform)
    {
        Vector2 currentMousePosition;
        RectTransform parentRecTransform = transform.parent.GetComponent<RectTransform>();
        RectTransformUtility.ScreenPointToLocalPointInRectangle(parentRecTransform, Input.mousePosition, GameObject.FindWithTag("MainCamera").GetComponent<Camera>(), out currentMousePosition);
        return currentMousePosition;
    }
}
