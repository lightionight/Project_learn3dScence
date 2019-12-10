using UnityEngine;

public class BulletFather: MonoBehaviour
{
    private GameObject bullet;
    private float weaponFireInterval = 1f;
    private float weaponPressBeforeTime = Time.time;

    void Start()
    {
        bullet = (GameObject)Resources.Load("/Assets/Sprites/bullet");
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            if (Time.time - weaponPressBeforeTime >= weaponFireInterval)
            {
                weaponPressBeforeTime = Time.time;
                Vector3 bornPoint = GameObject.Find("weapon_BornPoint").GetComponent<Transform>().position;
                Instantiate(bullet, bornPoint, Quaternion.identity, GameObject.Find("/Weapon_Father").GetComponent<Transform>());

            }
        }
    }

}
