using UnityEngine;
using UnityEngine.SceneManagement;
public class Star : MonoBehaviour
{
    private float starSpeed = 0.25f;
    private GameObject[] stars;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        stars = GameObject.FindGameObjectsWithTag("Target");
        if (stars.Length != 0)
            foreach (var son in stars)
        {
            son.transform.position += Vector3.up * starSpeed * Time.deltaTime * 5f;

                if (son.transform. position.y >= 4 || son.transform.position.y <= 0)
            {
                starSpeed = - starSpeed;
            }
        }
        else
        {
            SceneManager.LoadSceneAsync(1);
        }


    }
}
