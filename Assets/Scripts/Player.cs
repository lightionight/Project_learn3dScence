using UnityEngine;
using UnityEditor;
using System;

public class Player: MonoBehaviour {
    public float ballMass;
    public float ballBouniness;
    void Start()
    {
        gameObject.GetComponent<Rigidbody>().mass = ballMass;
        gameObject.GetComponent<Collider>().material.bounciness = ballBouniness;
        
    }

    void Update()
    {
        float move = Input.GetAxis("Vertical");
        transform.position += transform.forward * move * Time.deltaTime * 2;
        //�������ҷ���
        float LR = Input.GetAxis("Horizontal");
        transform.Rotate(transform.up * LR * Time.deltaTime * 100);
        //�ո��������Ծ
        float jump = Input.GetAxis("Jump");
        transform.position += transform.TransformVector(0, jump * 0.5f, 0);
    }
    
    //��ײ���
    void OnCollisionEnter(Collision collision)
    {

        if(collision.collider.tag == "Enemy")
        {
            Debug.Log("Kill a enemy");
            Destroy(collision.collider.gameObject);
        }
        if (collision.collider.tag == "Target")
        {
           Debug.Log("Eat a Star");
           Destroy(collision.collider.gameObject);
        }
        

    }
}