using UnityEngine;

public class CharacterControllerBase : MonoBehaviour
{
    //2D Parameter
    

    //3D Parameter

    //2D基本控制
    public void _base2dController(GameObject player, bool isJump)
    {
        Rigidbody2D playerRigi2d = player.GetComponent<Rigidbody2D>();
        Vector2 moveSpeed = new Vector2(3f, 5f);
        float leftRight = Input.GetAxisRaw("Horizontal");
        float jump = Input.GetAxisRaw("Jump");
        if (isJump)
        {
            playerRigi2d.velocity = new Vector2(0, jump) * moveSpeed;
            playerRigi2d.GetComponent<CharacterMove>().isJump = false;
        }


    }
    





    //3D基本控制
    public void _base3dController(GameObject player)
    {

    }
}
