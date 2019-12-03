using UnityEngine;

public class CharacterControllerBase : MonoBehaviour
{
    //2D Parameter
    

    //3D Parameter
    //2D基本控制
    public void _base2dController(GameObject player, bool isJump)
    {
        Animator animatorPlayer = player.GetComponent<Animator>();//获取2d玩家角色的动画控件
        Rigidbody2D playerRigi2d = player.GetComponent<Rigidbody2D>();//获取2d玩家的Rigi控件
        Vector2 moveSpeed = new Vector2(3f, 10f);//设置跳跃及移动放大倍数
        float jump = Input.GetAxisRaw("Jump");//获取用户输入跳跃数值
        float leftRight = Input.GetAxisRaw("Horizontal");//获取用户输入


        if (isJump)
        {
            animatorPlayer.Play("Jump", 0);
            playerRigi2d.velocity = new Vector2(leftRight, jump) * moveSpeed;
        }
        else
        {
            animatorPlayer.Play("StandBy", 0);
        }
        


    }
    





    //3D基本控制
    public void _base3dController(GameObject player)
    {

    }
}
