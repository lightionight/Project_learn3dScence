using UnityEngine;

public class BulletFather: MonoBehaviour
{
    private GameObject bullet;
    private string bulletPath = "Bullet/Bullet";
    private float weaponFireInterval = 1f;
    private float weaponPressBeforeTime;

    private void Start()
    {
        bullet = Resources.Load<GameObject>(bulletPath);
        weaponPressBeforeTime = Time.time;
    }

    private void Update()
    {
       
        if (Input.GetKeyDown(KeyCode.K))
        {
            if(bullet != null)
            {
                if (Time.time - weaponPressBeforeTime >= weaponFireInterval)
                {
                    weaponPressBeforeTime = Time.time;
                    Vector3 bornPoint = GameObject.Find("/Mario/Weapon_BornPoint").GetComponent<Transform>().position;
                    Instantiate(bullet, bornPoint, Quaternion.identity, GameObject.Find("/Weapon_Father").GetComponent<Transform>());

                }
            }
            else
            {
                Debug.Log("Bullet Not Load");
            }
        }

    }

}
