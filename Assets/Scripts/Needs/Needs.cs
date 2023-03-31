using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class Needs : MonoBehaviour
{
    //Needs
    public float Hunger = 100;
    public float Thirsty = 100;
    public float Toilet = 100;
    public float Hygiene = 100;
    public float Sleep = 100;
    public float Fun = 100;
    public float WaitTime = 1.0f;
    
    //Sliders
    public Slider HungerSlider;
    public Slider ThirstySlider;
    public Slider ToiletSlider;
    public Slider HygieneSlider;
    public Slider SleepSlider;
    public Slider FunSlider;
    
    //AI
    public NavMeshAgent Player;
    public GameObject ThirstyRegen;
    public GameObject HungerRegen;
    public GameObject ToiletRegen;
    public GameObject HygieneRegen;
    public GameObject SleepRegen;
    public GameObject FunRegen;

    private bool IsRegen;

    void Start()
    {
        SetMaxNeeds(HungerSlider, Hunger);
        StartCoroutine(UpdateNeeds(HungerSlider,Hunger, WaitTime));
        
        SetMaxNeeds(ThirstySlider, Thirsty);
        StartCoroutine(UpdateNeeds(ThirstySlider,Thirsty, WaitTime));

        SetMaxNeeds(ToiletSlider, Toilet);
        StartCoroutine(UpdateNeeds(ToiletSlider,Toilet, WaitTime));
        
        SetMaxNeeds(HygieneSlider, Hygiene);
        StartCoroutine(UpdateNeeds(HygieneSlider,Hygiene, WaitTime));
        
        SetMaxNeeds(SleepSlider, Sleep);
        StartCoroutine(UpdateNeeds(SleepSlider,Sleep, WaitTime));
        
        SetMaxNeeds(FunSlider, Fun);
        StartCoroutine(UpdateNeeds(FunSlider,Fun, WaitTime));

    }

    #region Needs Functions
    public void SetMaxNeeds(Slider Value, float Needs)
    {
        Value.maxValue = Needs;
        Value.value = Needs;
    }

    public void UpdateSlider(Slider Value, float Needs)
    {
        Value.value = Needs;
    }

    IEnumerator UpdateNeeds(Slider Slider, float Input, float Wait)
    {
        while (Input >= 0)
        {
            Input = Input - 1;
            UpdateSlider(Slider, Input);

            yield return new WaitForSeconds(Wait);
        }
    }

    #endregion

}
