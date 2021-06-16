using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{

    private AudioSource myAudioSource;
    public static AudioSource instancia;

    void Awake ()
    {
        myAudioSource = GetComponent<AudioSource>();
        instancia = myAudioSource;
    }

}
