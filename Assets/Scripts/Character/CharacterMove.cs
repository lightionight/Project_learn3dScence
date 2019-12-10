using UnityEngine;
using BaseClass;

public class CharacterMove : MonoBehaviour
{
    public bool isJump = false;
    private PlayerCharacterController playerCharacterController;

    void Start()
    {
        playerCharacterController = new PlayerCharacterController();
    }
    void Update()
    {
        if(isJump)
        {
            
            playerCharacterController._base2dController(gameObject, isJump, isJump);
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



