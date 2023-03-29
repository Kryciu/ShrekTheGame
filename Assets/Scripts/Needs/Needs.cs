using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Needs : MonoBehaviour
{
    [SerializeField] private float Hunger = 100;
    [SerializeField] private float WaitTime = 1.0f;

    void Start()
    {
        StartCoroutine(UpdateNeeds(Hunger, WaitTime));
    }

    IEnumerator UpdateNeeds(float Input, float Wait)
    {
        while (Input >= 0)
        {
            Input = Input - 1;
            Debug.Log(Input);
            yield return new WaitForSeconds(Wait);
        }
    }
    
}
