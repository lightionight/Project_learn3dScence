using UnityEngine;
using System;

public class ClickMove : MonoBehaviour
{
    void Start()
    {
        
        
    }
    void Update()
    {
        

    }
    Vector2 CurrentMousePosition(Transform transform)
    {
        Vector2 currentMousePosition;
        RectTransform parentRecTransform = transform.parent.GetComponent<RectTransform>();
        RectTransformUtility.ScreenPointToLocalPointInRectangle(parentRecTransform, Input.mousePosition, GameObject.FindWithTag("MainCamera").GetComponent<Camera>(), out currentMousePosition);
        return currentMousePosition;
    }
}
