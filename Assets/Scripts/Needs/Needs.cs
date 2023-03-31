using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Unity.VisualScripting;
using UnityEditor.PackageManager;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class Needs : MonoBehaviour
{
    //Needs
    #region NeedsDefaultValues

    public float Hunger = 100;
    public float Thirsty = 100;
    public float Toilet = 100;
    public float Hygiene = 100;
    public float Sleep = 100;
    public float Fun = 100;

    #endregion

    //Delays
    #region DelaysDefaultValues

    public float ThirstyWaitTime = 1.0f;
    public float HungerWaitTime = 1.0f;
    public float ToiletWaitTime = 1.0f;
    public float HygieneWaitTime = 1.0f;
    public float SleepWaitTime = 1.0f;
    public float FunWaitTime = 1.0f;
    
    //Delay holders
    private float _ThirstyWaitTime;
    private float _HungerWaitTime;
    private float _ToiletWaitTime;
    private float _HygieneWaitTime;
    private float _SleepWaitTime;
    private float _FunWaitTime;

    #endregion

    //Sliders
    #region Sliders

    public Slider HungerSlider;
    public Slider ThirstySlider;
    public Slider ToiletSlider;
    public Slider HygieneSlider;
    public Slider SleepSlider;
    public Slider FunSlider;

    #endregion

    //AI
    #region AI

    public NavMeshAgent Player;
    public GameObject ThirstyRegen;
    public GameObject HungerRegen;
    public GameObject ToiletRegen;
    public GameObject HygieneRegen;
    public GameObject SleepRegen;
    public GameObject FunRegen;

    private bool IsCurrentlyRegenerating;
    
    #endregion

    void Awake()
    {
        _ThirstyWaitTime = ThirstyWaitTime;
        _HungerWaitTime = HungerWaitTime;
        _ToiletWaitTime = ToiletWaitTime;
        _HygieneWaitTime = HygieneWaitTime;
        _SleepWaitTime = SleepWaitTime; 
        _FunWaitTime = FunWaitTime;
    }

    void Start()
    {
        SetMaxNeeds(HungerSlider, Hunger);
        SetMaxNeeds(ThirstySlider, Thirsty);
        SetMaxNeeds(ToiletSlider, Toilet);
        SetMaxNeeds(HygieneSlider, Hygiene);
        SetMaxNeeds(SleepSlider, Sleep);
        SetMaxNeeds(FunSlider, Fun);
    }

    void Update()
    {
        #region ThirstyUpdate
        if (ThirstyWaitTime > 0)
        {
            ThirstyWaitTime -= Time.deltaTime;
        }
        else
        {
            Thirsty = Thirsty - 1;
            UpdateSlider(ThirstySlider, Thirsty);
            ThirstyWaitTime = _ThirstyWaitTime;

            if (Thirsty <= 50)
            {
                if (!IsCurrentlyRegenerating)
                {
                    IsCurrentlyRegenerating = true;
                    Player.SetDestination(ThirstyRegen.transform.position);
                    Debug.Log("Started Thirsty regeneration");
                }
                else
                {
                    if (Vector3.Distance(Player.transform.position, ThirstyRegen.transform.position) < 5)
                    {
                        if (Player.remainingDistance <= Player.stoppingDistance)
                        {
                            if (Player.hasPath || Player.velocity.sqrMagnitude == 0f)
                            {
                                SetMaxNeeds(ThirstySlider, 100);
                                Thirsty = 100;
                                UpdateSlider(ThirstySlider, Thirsty);
                                IsCurrentlyRegenerating = false;
                                Debug.Log("Regenerated Thirsty");
                            }
                        }
                    }
                }
            }
        }
        #endregion
        
        #region HungerUpdate
        if (HungerWaitTime > 0)
        {
            HungerWaitTime -= Time.deltaTime;
        }
        else
        {
            Hunger = Hunger - 1;
            UpdateSlider(HungerSlider, Hunger);
            HungerWaitTime = _HungerWaitTime;
            
            if (Hunger <= 50)
            {
                if (!IsCurrentlyRegenerating)
                {
                    IsCurrentlyRegenerating = true;
                    Player.SetDestination(HungerRegen.transform.position);
                    Debug.Log("Started Hunger regeneration");
                }
                else
                {
                    if (Vector3.Distance(Player.transform.position, HungerRegen.transform.position) < 5)
                    {
                        if (Player.remainingDistance <= Player.stoppingDistance)
                        {
                            if (Player.hasPath || Player.velocity.sqrMagnitude == 0f)
                            {
                                SetMaxNeeds(HungerSlider, 100);
                                Hunger = 100;
                                UpdateSlider(HungerSlider, Hunger);
                                IsCurrentlyRegenerating = false;
                                Debug.Log("Regenerated Hunger");
                            }
                        }
                    }
                }
            }
        }
        #endregion
        
        #region ToiletUpdate
        if (ToiletWaitTime > 0)
        {
            ToiletWaitTime -= Time.deltaTime;
        }
        else
        {
            Toilet = Toilet - 1;
            UpdateSlider(ToiletSlider, Toilet);
            ToiletWaitTime = _ToiletWaitTime;
            
            if (Toilet <= 50)
            {
                if (!IsCurrentlyRegenerating)
                {
                    IsCurrentlyRegenerating = true;
                    Player.SetDestination(ToiletRegen.transform.position);
                    Debug.Log("Started Toilet regeneration");
                }
                else
                {
                    if (Vector3.Distance(Player.transform.position, ToiletRegen.transform.position) < 5)
                    {
                        if (Player.remainingDistance <= Player.stoppingDistance)
                        {
                            if (Player.hasPath || Player.velocity.sqrMagnitude == 0f)
                            {
                                SetMaxNeeds(ToiletSlider, 100);
                                Toilet = 100;
                                UpdateSlider(ToiletSlider, Toilet);
                                IsCurrentlyRegenerating = false;
                                Debug.Log("Regenerated Toilet");
                            }
                        }
                    }
                }
            }
        }
        #endregion
        
        #region HygieneUpdate
        if (HygieneWaitTime > 0)
        {
            HygieneWaitTime -= Time.deltaTime;
        }
        else
        {
            Hygiene = Hygiene - 1;
            UpdateSlider(HygieneSlider, Hygiene);
            HygieneWaitTime = _HygieneWaitTime;
            
            if (Hygiene <= 50)
            {
                if (!IsCurrentlyRegenerating)
                {
                    IsCurrentlyRegenerating = true;
                    Player.SetDestination(HygieneRegen.transform.position);
                    Debug.Log("Started Hygiene regeneration");
                }
                else
                {
                    if (Vector3.Distance(Player.transform.position, HygieneRegen.transform.position) < 5)
                    {
                        if (Player.remainingDistance <= Player.stoppingDistance)
                        {
                            if (Player.hasPath || Player.velocity.sqrMagnitude == 0f)
                            {
                                SetMaxNeeds(HygieneSlider, 100);
                                Hygiene = 100;
                                UpdateSlider(HygieneSlider, Hygiene);
                                IsCurrentlyRegenerating = false;
                                Debug.Log("Regenerated Hygiene");
                            }
                        }
                    }
                }
            }
        }
        #endregion
        
        #region SleepUpdate
        if (SleepWaitTime > 0)
        {
            SleepWaitTime -= Time.deltaTime;
        }
        else
        {
            Sleep = Sleep - 1;
            UpdateSlider(SleepSlider, Sleep);
            SleepWaitTime = _SleepWaitTime;
            
            if (Sleep <= 50)
            {
                if (!IsCurrentlyRegenerating)
                {
                    IsCurrentlyRegenerating = true;
                    Player.SetDestination(SleepRegen.transform.position);
                    Debug.Log("Started Sleep regeneration");
                }
                else
                {
                    if (Vector3.Distance(Player.transform.position, SleepRegen.transform.position) < 5)
                    {
                        if (Player.remainingDistance <= Player.stoppingDistance)
                        {
                            if (Player.hasPath || Player.velocity.sqrMagnitude == 0f)
                            {
                                SetMaxNeeds(SleepSlider, 100);
                                Sleep = 100;
                                UpdateSlider(SleepSlider, Sleep);
                                IsCurrentlyRegenerating = false;
                                Debug.Log("Regenerated Sleep");
                            }
                        }
                    }
                }
            }
        }
        #endregion
        
        #region FunUpdate
        if (FunWaitTime > 0)
        {
            FunWaitTime -= Time.deltaTime;
        }
        else
        {
            Fun = Fun - 1;
            UpdateSlider(FunSlider, Fun);
            FunWaitTime = _FunWaitTime;
            
            if (Fun <= 50)
            {
                if (!IsCurrentlyRegenerating)
                {
                    IsCurrentlyRegenerating = true;
                    Player.SetDestination(FunRegen.transform.position);
                    Debug.Log("Started Fun regeneration");
                }
                else
                {
                    if (Vector3.Distance(Player.transform.position, FunRegen.transform.position) < 5)
                    {
                        if (Player.remainingDistance <= Player.stoppingDistance)
                        {
                            if (Player.hasPath || Player.velocity.sqrMagnitude == 0f)
                            {
                                SetMaxNeeds(FunSlider, 100);
                                Fun = 100;
                                UpdateSlider(FunSlider, Fun);
                                IsCurrentlyRegenerating = false;
                                Debug.Log("Regenerated Fun");
                            }
                        }
                    }
                }
            }
        }
        #endregion
    }

    #region NeedsFunctions

    public void SetMaxNeeds(Slider Value, float Needs)
    {
        Value.maxValue = Needs;
        Value.value = Needs;
    }

    public void UpdateSlider(Slider Value, float Needs)
    {
        Value.value = Needs;
    }

    #endregion
}
