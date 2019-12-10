using System;
using UnityEngine;

namespace BaseClass
{
    public class PlayerCharacterController
    {
        private float   animatorNormalSpeed = 0.1f;
        private float   animatorFastSpeed   = 0.25f;        
        private Vector2 moveSpeed = new Vector2(3f, 8f);//设置跳跃及移动放大倍数
        private string  rayCheckResult; //角色周围射线检测结果

        
        public void _base2dController(GameObject player, bool isGround, bool test)//2D基本控制
        {

        }
        public void _base2dController(GameObject player)//2D角色操控方法
        {
            Animator        playerAnimator       = player.GetComponent<Animator>();
            Rigidbody2D     playerRigi2d         = player.GetComponent<Rigidbody2D>();
            SpriteRenderer  playerSpriteRenderer = player.GetComponent<SpriteRenderer>();
            float jump          = Input.GetAxis("Jump");                    
            float leftRight     = Input.GetAxis("Horizontal");
            Vector2 playerInput = new Vector2(leftRight, jump);
            rayCheckResult      = null;
            RayCheck(player);
            if (rayCheckResult == "CanJump")
            {
                playerRigi2d.velocity = playerInput * moveSpeed;

                if (playerRigi2d.velocity.x != 0)
                {
                    playerAnimator.SetBool("_IsRun", true);
                    if (playerRigi2d.velocity.x < 0)
                    {
                        playerSpriteRenderer.flipX = true;
                    }
                    else
                    {
                        playerSpriteRenderer.flipX = false;
                    }

                    if ((Math.Abs(playerRigi2d.velocity.x) / 3) > 0.5 && playerAnimator.GetCurrentAnimatorStateInfo(0).IsName("Run"))
                    {
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


                if (playerRigi2d.velocity.y != 0)
                {
                    playerAnimator.SetBool("_IsJump", true);
                }
                else
                {
                    playerAnimator.SetBool("_IsJump", false);
                }

            }

        }

        
        public void RayCheck(GameObject player)//射线检测玩家周围环境
        {
            Vector2 player_2dPosition      = new Vector2(player.transform.position.x, player.transform.position.y);
            RaycastHit2D player_UpRay      = Physics2D.Raycast(player_2dPosition, Vector2.up, 0.5f,    layerMask: 1 << 9);
            RaycastHit2D player_DownRay    = Physics2D.BoxCast(player_2dPosition, new Vector2(1f, 0.1f), 0, Vector2.down, 0, layerMask: 1 << 9);
            //RaycastHit2D player_LeftRay  = Physics2D.Raycast(player_2dPosition, Vector2.left,  1f,    layerMask: 1 << 9);
            //RaycastHit2D player_RightRay = Physics2D.Raycast(player_2dPosition, Vector2.right, 0.5f,    layerMask: 1 << 9);

            if (player_UpRay.collider == null && player_DownRay.collider != null)
            {
                if (player_DownRay.collider.tag == "Ground" || player_DownRay.collider.tag == "Enemy")
                {
                    rayCheckResult = "CanJump";
                }
            }
        }
    }
}
