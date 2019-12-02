using UnityEngine;
using System.Collections;

public class CharacterMove : MonoBehaviour
{
    public bool isJump = false;

    CharacterControllerBase characterControllerBase;
    void Start()
    {
        characterControllerBase = new CharacterControllerBase();   
    }
    void Update()
    {
        if(isJump)
        {
            Debug.Log(isJump + "aaa");
            characterControllerBase._base2dController(gameObject, isJump);
            Debug.Log(isJump);
        }
        
    }
    void OnCollisionEnter2D(Collision2D collision2D)
    {
        if (collision2D.collider.tag == "Ground")
        {
            Debug.Log("Touch Ground");
            isJump = true;
        }
    }
}
