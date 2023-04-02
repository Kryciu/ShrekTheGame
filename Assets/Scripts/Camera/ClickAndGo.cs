using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ClickAndGo : MonoBehaviour
{
    public Camera MainCamera;
    public NavMeshAgent Player;
    public bool UseClickAndGo;

    private void Update()
    {
        if (UseClickAndGo)
        {
            if (Input.GetMouseButtonDown(0))
            {
                RaycastHit hit;
            
                if(Physics.Raycast(MainCamera.ScreenPointToRay(Input.mousePosition), out hit, 100))
                {
                    Player.SetDestination(hit.point);
                }
            }
        }
    }
}