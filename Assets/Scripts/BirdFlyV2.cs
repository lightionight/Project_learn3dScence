using UnityEngine;

public class BirdFlyV2 : MonoBehaviour
{
    /*********静态变量************/
    private static readonly float speed =10f;
    /*********变量************/
    private float t;
    private Vector2 mousePoint;
    private RectTransform birdRectTransform;
    private RectTransform parentRectTransform;
    // Use this for initialization
    void Start()
    {
        birdRectTransform = GetComponent<RectTransform>();
        birdRectTransform.SetAsLastSibling();
        parentRectTransform = GameObject.Find("Canvas").GetComponent<RectTransform>();
        


    }

    // Update is called once per frame
    void Update()
    {
        
        if(Input.GetMouseButtonDown(0))
        {
            mousePoint = CurrentMousePosition(parentRectTransform);
            t = (1 / ((birdRectTransform.anchoredPosition - mousePoint).magnitude)) * speed;


        }
        birdRectTransform.anchoredPosition = Vector2.LerpUnclamped(birdRectTransform.anchoredPosition, mousePoint, t);
        Debug.Log(t.ToString());
        //Debug.Log($"This is anchored{ birdRectTransform.anchoredPosition.ToString()}");
        //Debug.Log($"This is mousePoint{mousePoint.ToString()}");
        
        
        
    }
    Vector2 CurrentMousePosition(RectTransform rectTransform)
    {
        Vector2 currentMousePosition;
        RectTransform parentRectTransform = rectTransform;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(parentRectTransform, Input.mousePosition, GameObject.FindWithTag("MainCamera").GetComponent<Camera>(), out currentMousePosition);
        return currentMousePosition;
    }
    private void OnGUI()
    {
        GUI.Label(new Rect(0, 20, 150, 80), "Anchor Position X : ");
    }
}
