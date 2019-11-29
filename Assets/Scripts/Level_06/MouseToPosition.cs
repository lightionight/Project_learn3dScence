using UnityEngine;
using UnityEngine.AI;

public class MouseToPosition : MonoBehaviour
{
    private Transform playerTransform;
    private Vector3 mouseClickPosition;
    private float t;
    private static readonly float speed = 5f;
    private NavMeshAgent playerAgent;
    GameObject clickEffect;
    private void Start()
    {
        playerTransform = transform;
        playerAgent = gameObject.GetComponent<NavMeshAgent>();
        clickEffect = GameObject.Find("ClickEffect");
        clickEffect.GetComponent<ParticleSystem>().Pause(true);
    }
    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            GetMouseClickWorldPostion();
            MouseClickEffect();
            //t = 1 / ((playerTransform.position - mouseClickPosition).magnitude) * speed;
            playerAgent.speed = 5f;
            playerAgent.height = 5f;
            playerAgent.SetDestination(mouseClickPosition);

        }
    }
    private void GetMouseClickWorldPostion()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if(Physics.Raycast(ray, out hit))
        {
            mouseClickPosition = hit.point;

        }
    }
    private void MouseClickEffect()
    {
        clickEffect.transform.position = mouseClickPosition;
        clickEffect.GetComponent<ParticleSystem>().Play(true);
    }
}