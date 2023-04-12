using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;
using FMOD.Studio;

public class soundManager : MonoBehaviour
{

    public FMODUnity.EventReference music;


    void Start()
    {
        RuntimeManager.PlayOneShot(music);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
