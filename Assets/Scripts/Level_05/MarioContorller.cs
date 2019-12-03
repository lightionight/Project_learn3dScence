using UnityEngine;
using System.Collections;

public class MarioContorller : MonoBehaviour
{
    CharacterControllerBase characterControllerBase;

    // Use this for initialization
    void Start()
    {
        characterControllerBase = gameObject.AddComponent<CharacterControllerBase>();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
