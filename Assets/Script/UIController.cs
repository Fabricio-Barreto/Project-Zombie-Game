using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{

    private PlayerController scriptPlayerController;
    public Slider SliderLifePlayer;

    // Start is called before the first frame update
    void Start()
    {
        scriptPlayerController = GameObject.FindWithTag("Player").GetComponent<PlayerController>();

        SliderLifePlayer.maxValue = scriptPlayerController.life;

        UpdateSliderPlayerLife();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateSliderPlayerLife()
    {
        SliderLifePlayer.value = scriptPlayerController.life;
    }
}
