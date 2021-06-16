using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{

    public float speed = 10;
    Vector3 direction;
    public LayerMask GroundMask;
    public GameObject gameOverText;
    public int life = 100;
    public UIController scriptUIController;
    public AudioClip DamageTakenSound;


    private void Start()
    {
        Time.timeScale = 1;
    }

    void Update()
    {

        float eixoX = Input.GetAxis("Horizontal");
        float eixoY = Input.GetAxis("Vertical");

        direction = new Vector3(eixoX * -1, 0, eixoY * -1);


        if (direction != Vector3.zero)
        {
            GetComponent<Animator>().SetBool("isRunning", true);
        }
        else
        {
            GetComponent<Animator>().SetBool("isRunning", false);
        }

        if(life <=  0)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                SceneManager.LoadScene("game");
            }
        }
    }

    void FixedUpdate()
    {
        GetComponent<Rigidbody>().MovePosition(GetComponent<Rigidbody>().position + direction * speed * Time.deltaTime);

        Ray raio = Camera.main.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(raio.origin, raio.direction * 150, Color.red);

        RaycastHit impact;

        if(Physics.Raycast(raio, out impact, 150, GroundMask))
        {
            Vector3 positionVisionPlayer = impact.point - transform.position;

            positionVisionPlayer.y = transform.position.y;

            Quaternion newRotation = Quaternion.LookRotation(positionVisionPlayer);

            GetComponent<Rigidbody>().MoveRotation(newRotation);
        }
    }

    public void DamageTaken(int damage)
    {
        life -= damage;
        scriptUIController.UpdateSliderPlayerLife();
        AudioController.instancia.PlayOneShot(DamageTakenSound);


        if (life <= 0)
        {
            Time.timeScale = 0;
            gameOverText.SetActive(true);
        }

    }

}
