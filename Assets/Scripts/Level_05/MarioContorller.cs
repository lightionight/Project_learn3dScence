using UnityEngine;
using System.Collections;

public class MarioContorller : MonoBehaviour
{
    CharacterControllerBase characterControllerBase;
    private bool animatorIsJump;
    private bool isJump = false;

    // Use this for initialization
    void Start()
    {
        characterControllerBase = gameObject.AddComponent<CharacterControllerBase>();
        animatorIsJump = gameObject.GetComponent<Animator>().GetBool("isJump"); //获取animator里面的isJump参数；
    }
    // Update is called once per frame
    void Update()
    {
        if(isJump)
        {
            characterControllerBase._base2dController(gameObject, isJump);
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
        Debug.Log(collision2D.gameObject.ToString());
        if (collision2D.gameObject.tag == "Ground")
        {
            Debug.Log("Touch Ground");
            isJump = true;
        }
    }
}
