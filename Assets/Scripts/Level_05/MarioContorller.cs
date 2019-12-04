using UnityEngine;

public class MarioContorller : MonoBehaviour
{
    private CharacterControllerBase characterControllerBase;
    private bool isGround = false;
    public GameObject bullet;

    // Use this for initialization
    void Start()
    {
        characterControllerBase = gameObject.AddComponent<CharacterControllerBase>();
    }
    // Update is called once per frame
    void Update()
    {
        
        if (isGround)
        {
            characterControllerBase._base2dController(gameObject, isGround, bullet);
            if (gameObject.GetComponent<Rigidbody2D>().velocity.y != 0)
            {
                isGround = false;
            }
            else
            {
                isGround = true;
            }
        }
        //Debug.Log(gameObject.GetComponent<Animator>().GetBool("_IsJump"));
    }
    void OnCollisionEnter2D(Collision2D collision2D)
    {
        //Debug.Log(collision2D.gameObject.ToString());
        if (collision2D.gameObject.tag == "Ground")
        {
            //Debug.Log("Touch Ground");
            isGround = true;
        }
    }
    void Fire()
    {

    }
}
