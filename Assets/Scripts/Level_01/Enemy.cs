using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    public GameObject[] enemyArms;
    public int gamePass = 0;
    void Update()
    {
        enemyArms = GameObject.FindGameObjectsWithTag("Enemy");
        if(enemyArms.Length != 0)
        {
            //Debug.Log($"EnemyArms is {enemyArms.Length}");
            enemyArms[0].GetComponent<Renderer>().enabled = true;
            enemyArms[0].GetComponent<Collider>().enabled = true;
        }
        else
        {
            SceneManager.LoadSceneAsync(0);
        }
    }
}
