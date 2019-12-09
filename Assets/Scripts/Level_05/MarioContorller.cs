using UnityEngine;

public class MarioContorller : MonoBehaviour
{
    private CharacterControllerBase characterControllerBase;
    public  GameObject              weapon;
    // Use this for initialization
    void Start()
    {
        characterControllerBase = new CharacterControllerBase();
        
    }
    // Update is called once per frame
    void Update()
    {
        characterControllerBase._base2dController(gameObject, weapon);
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position + transform.up * 0.5f, new Vector3(1, 1, 1));
    }

}
