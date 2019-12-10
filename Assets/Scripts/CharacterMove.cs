using UnityEngine;
using System.Collections;

public class CharacterMove : MonoBehaviour
{
    public bool isJump = false;
    CharacterControllerClass characterControllerBaseClass;

    void Start()
    {
        characterControllerBaseClass = new CharacterControllerClass();
    }
    void Update()
    {
        if(isJump)
        {
            
            characterControllerBaseClass._base2dController(gameObject, isJump, isJump);
            if(gameObject.GetComponent<Rigidbody2D>().velocity.y != 0)
            {
                isJump = false;
            }
            else
            {
                isJump = true;
            }
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



