using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Jumpscare : MonoBehaviour
{
    public Needs NeedsScript;
    public GameObject Knight;
    public float KnightLifetime = 0.0f;
    private void OnTriggerEnter(Collider other)
    {
        if (NeedsScript.IsCurrentlyRegenerating)
        {
            StartCoroutine(ToggleKnight());
        }
    }

    IEnumerator ToggleKnight()
    {
        Knight.SetActive(true);
        yield return new WaitForSeconds(KnightLifetime);
        Knight.SetActive(false);
    }
}
