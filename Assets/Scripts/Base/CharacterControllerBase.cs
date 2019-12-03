using UnityEngine;

public class CharacterControllerBase : MonoBehaviour
{
    //2D Parameter
    

    //3D Parameter

    //2D基本控制
    public void _base2dController(GameObject player, bool isJump)
    {
        Vector2 moveSpeed = new Vector2(3f, 10f);
        float jump = Input.GetAxisRaw("Jump");
        float leftRight = Input.GetAxisRaw("Horizontal");
        Rigidbody2D playerRigi2d = player.GetComponent<Rigidbody2D>();
        if (isJump)
        {
            playerRigi2d.velocity = new Vector2(leftRight, jump) * moveSpeed;
        }
        


    }
    





    //3D基本控制
    public void _base3dController(GameObject player)
    {

    }
}
