using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{

    public GameObject Bullet;
    public GameObject WeaponReference;
    public AudioClip ShotSound;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Instantiate(Bullet, WeaponReference.transform.position, WeaponReference.transform.rotation);
            AudioController.instancia.PlayOneShot(ShotSound);
        }
    }
}
