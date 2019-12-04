using UnityEngine;
using System;

public class CharacterControllerBase : MonoBehaviour
{
    //2D Parameter
    private bool _IsRun;
    private bool _IsJump;

    //3D Parameter
    //2D基本控制
    public void _base2dController(GameObject player, bool isGround)
    {

    }
    public void _base2dController(GameObject player, bool isGround, GameObject bullet)
    {
        Animator playerAnimator = player.GetComponent<Animator>();//获取2d玩家角色的动画控件
        Rigidbody2D playerRigi2d = player.GetComponent<Rigidbody2D>();//获取2d玩家的Rigi控件
        Vector2 moveSpeed = new Vector2(3f, 7f);//设置跳跃及移动放大倍数
        float jump = Input.GetAxis("Jump");//获取用户输入跳跃数值
        float leftRight = Input.GetAxis("Horizontal");//获取用户输入
        float animatorNormalSpeed = 0.1f;
        float animatorFastSpeed = 0.25f;
        //Animator Parameter


        if (isGround)
        {

            playerRigi2d.velocity = new Vector2(leftRight, jump) * moveSpeed;
            if (playerRigi2d.velocity.x != 0)
            {
                playerAnimator.SetBool("_IsRun", true);

                if ((Math.Abs(playerRigi2d.velocity.x) / 3) > 0.5 && playerAnimator.GetCurrentAnimatorStateInfo(0).IsName("Run"))
                {
                    Debug.Log(playerRigi2d.velocity.x.ToString());
                    playerAnimator.speed = animatorFastSpeed;

                }
                else
                {
                    playerAnimator.speed = animatorNormalSpeed;
                }


            }
            else
            {
                playerAnimator.SetBool("_IsRun", false);
            }
            //Debug.Log(player.GetComponent<Animator>().GetBool("_IsRun"));
            if (playerRigi2d.velocity.y != 0)
            {
                playerAnimator.SetBool("_IsJump", true);
            }
            else
            {
                playerAnimator.SetBool("_IsJump", false);
                //playerAnimator.GetAnimatorTransitionInfo(0).
            }
            //Debug.Log(_IsJump);

        }
        else
        {
            playerRigi2d.velocity = new Vector2(0, 0);
        }

        //控制武器释放

        if (Input.GetKeyDown(KeyCode.K))
        {
            Vector3 bornPoint = GameObject.Find("Bullet_BornPoint").GetComponent<Transform>().position;
            Instantiate(bullet, bornPoint, Quaternion.identity,GameObject.Find("Mario").GetComponent<Transform>());
        }
    }
    


    //3D基本控制
    public void _base3dController(GameObject player)
    {

    }

}
