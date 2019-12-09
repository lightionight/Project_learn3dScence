using UnityEngine;

public class Bullet_Fire : MonoBehaviour
{
    private float bullet_speed = 2f;
    Animator bulletAnimator;
    private bool hitEnemy = false;
    private void Start()
    {
        bulletAnimator = gameObject.GetComponent<Animator>();
    }
    void Update()
    {
        if (!hitEnemy)
        {
            transform.Translate(Vector3.right * Time.deltaTime * bullet_speed);

        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Ground")
        {
            
            Destroy(gameObject);
        }
        Debug.Log(collision.tag.ToString());
        if (collision.tag == "Enemy")
        {
            Debug.Log("Touch Enemy");
            hitEnemy = true;
            bulletAnimator.SetBool("_HitEnemy", true);
            Destroy(gameObject, 0.2f);
            Destroy(collision.gameObject, 0.2f);


        }
    }
}
