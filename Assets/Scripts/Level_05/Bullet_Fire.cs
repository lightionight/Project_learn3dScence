using UnityEngine;

public class Bullet_Fire : MonoBehaviour
{
    private float bullet_speed = 2f;
    Animator bulletAnimator;
    private bool hitEnemy =false;
    private void Start()
    {
        bulletAnimator = gameObject.GetComponent<Animator>();
    }
    void Update()
    {
        if(!hitEnemy)
        {
            transform.Translate(Vector3.right * Time.deltaTime * bullet_speed);

        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            Debug.Log(collision.gameObject.tag.ToString());
            Destroy(gameObject);
        }
        if (collision.gameObject.tag == "Enemy")
        {
            Debug.Log("Touch Enemy");
            hitEnemy = true;
            bulletAnimator.SetBool("_HitEnemy", true);
            if(bulletAnimator.GetBool("_HitEnemy"))
            {
                Debug.Log("play Explode animation");
            }
            Destroy(gameObject, 0.2f);
            Destroy(collision.gameObject, 0.2f);


        }
    }
}
