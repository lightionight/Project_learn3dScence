using UnityEngine;

public class Bullet_Fire : MonoBehaviour
{
    private float bullet_speed = 2f;
    Animator bulletAnimator;
    private void Start()
    {
        bulletAnimator = gameObject.GetComponent<Animator>();
    }
    void Update()
    {

        transform.Translate(Vector3.right * Time.deltaTime * bullet_speed);
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
            bulletAnimator.SetBool("_HitEnemy", true);
            Destroy(gameObject, 0.5f);
            Destroy(collision.gameObject, 0.5f);
        }
    }
}
