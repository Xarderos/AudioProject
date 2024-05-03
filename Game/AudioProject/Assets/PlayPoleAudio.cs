using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayPoleAudio : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioSource audiosource;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void PlayAudio()
    {
        audiosource.Play();
    }
}
