using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;
using FMOD.Studio;

public class soundManager : MonoBehaviour
{

    public EventReference music;
    public EventReference Dialogues;
    public Needs NeedsScript;

    private EventInstance DialoguesInstance;
    private bool ShouldPlay = true;


    void Start()
    {
        DialoguesInstance = RuntimeManager.CreateInstance(Dialogues);
        RuntimeManager.PlayOneShot(music);
    }

    // Update is called once per frame
    void Update()
    {
        if (NeedsScript.IsCurrentlyRegenerating)
        {
            if(!IsPlaying(DialoguesInstance))
            {
                if (ShouldPlay)
                {
                    DialoguesInstance.start();
                    StartCoroutine(RandomDialogue());
                }
            }
        }
        DialoguesInstance.set3DAttributes(RuntimeUtils.To3DAttributes(gameObject));
    }

    bool IsPlaying(EventInstance instance)
    {
        PLAYBACK_STATE state;
        instance.getPlaybackState(out state);
        return state == PLAYBACK_STATE.PLAYING;
    }

    IEnumerator RandomDialogue()
    {
        ShouldPlay = false;
        yield return new WaitForSeconds(Random.Range(10.0f, 20.0f));
        ShouldPlay = true;
    }
}
