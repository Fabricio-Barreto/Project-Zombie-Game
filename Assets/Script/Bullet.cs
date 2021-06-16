using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public float speed;
    public AudioClip ZombieDeath;
    
    void FixedUpdate()
    {
        GetComponent<Rigidbody>().MovePosition(GetComponent<Rigidbody>().position + transform.forward * speed * Time.deltaTime * -1);
    }

    void OnTriggerEnter(Collider objectCollision)
    {
        if(objectCollision.tag == "Enemy")
        {
            Destroy(objectCollision.gameObject);
            AudioController.instancia.PlayOneShot(ZombieDeath);
        }

        Destroy(gameObject);
    }
}
