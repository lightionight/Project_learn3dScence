using UnityEngine;
using BaseClass;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]

public class MarioContorller : MonoBehaviour
{
    private PlayerCharacterController playerCharacterController;
    void Start()
    {
        playerCharacterController = new PlayerCharacterController();
        
    }
    void Update()
    {
        playerCharacterController._base2dController(gameObject);
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position + transform.up * 0.5f, new Vector3(1, 1, 1));
    }

}
