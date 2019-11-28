using UnityEngine;

public class BirdFlyV2 : MonoBehaviour
{
    /*********静态变量************/
    private static readonly float speed = 0.001f;
    /*********变量************/
    private float t;
    public Vector2 mousePoint;
    RectTransform birdRectTransform;
    RectTransform parentRectTransform;
    // Use this for initialization
    void Start()
    {
        birdRectTransform = GetComponent<RectTransform>();
        parentRectTransform = GameObject.Find("Canvas").GetComponent<RectTransform>();
        


    }

    // Update is called once per frame
    void Update()
    {
        //movePoint = mousePoint;//vec2转换为vec3
        t = (1 / ((birdRectTransform.anchoredPosition - mousePoint).magnitude)) * speed;       
        mousePoint = CurrentMousePosition(parentRectTransform);
        birdRectTransform.anchoredPosition = Vector2.Lerp(birdRectTransform.anchoredPosition, mousePoint, t);
        
        
        
    }
    Vector2 CurrentMousePosition(RectTransform rectTransform)
    {
        Vector2 currentMousePosition;
        RectTransform parentRectTransform = rectTransform;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(parentRectTransform, Input.mousePosition, GameObject.FindWithTag("MainCamera").GetComponent<Camera>(), out currentMousePosition);
        return currentMousePosition;
    }
}
