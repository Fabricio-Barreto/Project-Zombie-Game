using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratorController : MonoBehaviour
{

    public GameObject Zombie;
    float time = 0;
    public float GeneratorTime = 2;
    public LayerMask LayerZombie;

    void Update()
    {
        time += Time.deltaTime;

        if(time >= GeneratorTime)
        {
            StartCoroutine(NewZombieGenerator());

            time = 0;
        }

    }

    IEnumerator NewZombieGenerator ()
    {
        Vector3 creatingPosition = PositionRandom();
        Collider[] colliders = Physics.OverlapSphere(creatingPosition, 1, LayerZombie);

        while(colliders.Length > 0)
        {
            creatingPosition = PositionRandom();
            colliders = Physics.OverlapSphere(creatingPosition, 1, LayerZombie);

            yield return null;
        }
        Instantiate(Zombie, creatingPosition, transform.rotation);
    }

    Vector3 PositionRandom()
    {
        Vector3 position = Random.insideUnitSphere * 3;

        position += transform.position;
        position.y = 0;

        return position;
    }
}
