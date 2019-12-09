using System;
using UnityEngine;
/*********************角色基础操控方式类****************************/
class CharacterControllerBase
{
    //武器属性
    float weaponFireInterval = 1f;
    float weaponPressBeforeTime = Time.time;
    //用户输入接收
    private float animatorNormalSpeed = 0.1f;
    private float animatorFastSpeed = 0.25f;
    private Vector2 moveSpeed = new Vector2(3f, 8f);//设置跳跃及移动放大倍数
    private string rayCheckResult;

    //3D Parameter
    //2D基本控制
    public void _base2dController(GameObject player, bool isGround, bool test)
    {

    }
    public void _base2dController(GameObject player, GameObject weapon)
    {
        Animator playerAnimator             = player.GetComponent<Animator>();//获取2d玩家角色的动画控件
        Rigidbody2D playerRigi2d            = player.GetComponent<Rigidbody2D>();//获取2d玩家的Rigi控件
        SpriteRenderer playerSpriteRenderer = player.GetComponent<SpriteRenderer>();//获取操控角色的sprite渲染控件
        float jump               = Input.GetAxis("Jump");                    //获取玩家输入控制
        float leftRight          = Input.GetAxis("Horizontal");              //获取玩家跳跃输入
        rayCheckResult = null;
        RayCheck(player);
        if (rayCheckResult == "CanJump")
        {
            playerRigi2d.velocity = new Vector2(leftRight, jump) * moveSpeed;
            //Debug.Log(playerRigi2d.velocity.ToString());
            if (playerRigi2d.velocity.x != 0)
            {
                playerAnimator.SetBool("_IsRun", true);
                if (playerRigi2d.velocity.x < 0)
                    playerSpriteRenderer.flipX = true;
                else
                {
                    playerSpriteRenderer.flipX = false;
                }
                if ((Math.Abs(playerRigi2d.velocity.x) / 3) > 0.5 && playerAnimator.GetCurrentAnimatorStateInfo(0).IsName("Run"))
                {
                    //Debug.Log(playerRigi2d.velocity.x.ToString());
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

        }

        
        Shoot(weapon);

        
    }

    //控制武器释放
    private void Shoot(GameObject weapon)
    {
        //shootTimer += Time.deltaTime;
        //if(shootTimer > 3f)
        //{
        //    shootTimer = 3f;
        //}
        //Debug.Log($"before: {shootTimer}");
        //if(shootTimer > shootTimerInterval)
        //{
        //shootTimer -= shootTimerInterval;
        //Debug.Log($"after: {shootTimer}")
        //};
        if (Input.GetKeyDown(KeyCode.K))
        {
            if(Time.time - weaponPressBeforeTime >=  weaponFireInterval)
            {
                weaponPressBeforeTime = Time.time;
                Vector3 bornPoint = GameObject.Find("weapon_BornPoint").GetComponent<Transform>().position;
                UnityEngine.Object.Instantiate(weapon, bornPoint, Quaternion.identity, GameObject.Find("/Canvas/Level_02/Grid/weaponFather").GetComponent<Transform>()); //有待重新编写game object 运行生成的方法

            }
        }
        
        
    }

    //射线检测玩家周围环境
    public void RayCheck(GameObject player)
    {
        Vector2 player_2dPosition      = new Vector2(player.transform.position.x, player.transform.position.y);
        RaycastHit2D player_UpRay      = Physics2D.Raycast(player_2dPosition, Vector2.up, 0.5f,    layerMask: 1 << 9);
        RaycastHit2D player_DownRay    = Physics2D.BoxCast(player_2dPosition, new Vector2(1f, 0.1f), 0, Vector2.down, 0, layerMask: 1 << 9);
        //RaycastHit2D player_LeftRay  = Physics2D.Raycast(player_2dPosition, Vector2.left,  1f,    layerMask: 1 << 9);
        //RaycastHit2D player_RightRay = Physics2D.Raycast(player_2dPosition, Vector2.right, 0.5f,    layerMask: 1 << 9);

        if (player_UpRay.collider == null && player_DownRay.collider != null)
            if (player_DownRay.collider.tag == "Ground" || player_DownRay.collider.tag == "Enemy")
                    rayCheckResult = "CanJump";

    }

    //3D基本控制
    public void _base3dController(GameObject player)
    {

    }

}
