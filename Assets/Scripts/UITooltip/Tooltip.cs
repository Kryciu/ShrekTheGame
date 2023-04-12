using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Tooltip : MonoBehaviour
{
    public TextMeshProUGUI[] Hints;

    private void Start()
    {
        //Set hints disabled by default
        OnUnHovered();
    }

    public void OnHovered()
    {
        foreach (var Hint in Hints)
        {
            Hint.enabled = true;
        }
    }

    public void OnUnHovered()
    {
        foreach (var Hint in Hints)
        {
            Hint.enabled = false;
        }
    }
}
