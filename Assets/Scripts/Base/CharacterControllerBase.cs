using UnityEngine;
using Unity;
using System;

public class CharacterControllerBase : MonoBehaviour
{
    //2D Parameter
    private bool isJump = false;
    private bool isMove = false;

    //3D Parameter

    //2D基本控制
    public void _base2dController(GameObject player)
    {
        Rigidbody2D playerRigi2d = player.GetComponent<Rigidbody2D>();
        Vector2 moveSpeed = new Vector2(3f, 5f);
        float leftRight = Input.GetAxisRaw("Horizontal");
        float jump = Input.GetAxisRaw("Jump");
        OnCollisionEnter2D(player, ref isJump);
        if(isJump)
        {
            playerRigi2d.velocity = new Vector2(0, jump) * moveSpeed;
        }


    }
    private void OnCollisionEnter2D(GameObject gameObject, ref bool isJump)
    {
        if(gameObject.GetComponent<Collider2D>().gameObject.tag == "Ground")
        {
            isJump = true;
        }
    }





    //3D基本控制
    public void _base3dController(GameObject player)
    {

    }
}
