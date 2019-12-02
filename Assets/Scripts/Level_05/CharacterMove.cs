using UnityEngine;
using System.Collections;

public class CharacterMove : MonoBehaviour
{
    CharacterControllerBase characterControllerBase;
    void Start()
    {
        characterControllerBase = new CharacterControllerBase();   
    }
    void Update()
    {
        characterControllerBase._base2dController(gameObject);

    }
}
