using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    public GameObject Player;
    public float speed = 3;
    private Vector3 randomPosition;
    private Vector3 direction;
    private float timerWanderAround;
    private float timerBetweenWanderAround = 4;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindWithTag("Player");

        int generatorType = Random.Range(1, 28);

        transform.GetChild(generatorType).gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        float distance = Vector3.Distance(transform.position, Player.transform.position);

        Quaternion NewRotation = Quaternion.LookRotation(direction);
        GetComponent<Rigidbody>().MoveRotation(NewRotation);



        if (distance > 15)
        {
            WanderAround();
        }
        else if (distance > 2.5)
        {

            direction = Player.transform.position - transform.position;

            GetComponent<Rigidbody>().MovePosition(GetComponent<Rigidbody>().position + direction.normalized * speed * Time.deltaTime);

            GetComponent<Animator>().SetBool("isAttacking", false);
        }
        else
        {
            GetComponent<Animator>().SetBool("isAttacking", true);
        }
    }

    public void AttackingPlayer()
    {
        int damage = Random.Range(20, 30);
        Player.GetComponent<PlayerController>().DamageTaken(damage);

    }

    void WanderAround ()
    {
        timerWanderAround -= Time.deltaTime;
        if(timerWanderAround <= 0)
        {
            randomPosition = randomizerPosition();
            timerWanderAround += timerBetweenWanderAround;
        }

        bool closeEnough = Vector3.Distance(transform.position, randomPosition) <= 0.05;
        if (closeEnough == false)
        {
            direction = randomPosition - transform.position;
            GetComponent<Rigidbody>().MovePosition(GetComponent<Rigidbody>().position + direction.normalized * speed * Time.deltaTime);
        }


    }

    Vector3 randomizerPosition()
    {
        Vector3 position = Random.insideUnitSphere * 10;
        position += transform.position;
        position.y = transform.position.y;

        return position;
    }

}
