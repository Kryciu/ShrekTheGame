using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Needs : MonoBehaviour
{
    [SerializeField] private float Hunger = 100;
    [SerializeField] private float Thirsty = 100;
    [SerializeField] private float Toilet = 100;
    [SerializeField] private float Hygiene = 100;
    [SerializeField] private float Sleep = 100;
    [SerializeField] private float Fun = 100;
    [SerializeField] private float WaitTime = 1.0f;

    void Start()
    {
        StartCoroutine(UpdateNeeds(Hunger, WaitTime));
        StartCoroutine(UpdateNeeds(Thirsty, WaitTime));
        StartCoroutine(UpdateNeeds(Toilet, WaitTime));
        StartCoroutine(UpdateNeeds(Hygiene, WaitTime));
        StartCoroutine(UpdateNeeds(Sleep, WaitTime));
        StartCoroutine(UpdateNeeds(Fun, WaitTime));

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
