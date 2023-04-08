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
using Random = UnityEngine.Random;

public class Needs : MonoBehaviour
{
    //Needs
    #region NeedsDefaultValues

    public DefaultShrekData ShrekData;
    private float Hunger;
    private float Thirsty;
    private float Toilet;
    private float Hygiene;
    private float Sleep;
    private float Fun;

    #endregion

    //Delays
    #region DelaysDefaultValues

    private float ThirstyWaitTime;
    private float HungerWaitTime;
    private float ToiletWaitTime;
    private float HygieneWaitTime;
    private float SleepWaitTime;
    private float FunWaitTime;
    private float MoveWaitTime;

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
    public Animator ShrekAnimator;

    [HideInInspector]
    public bool IsCurrentlyRegenerating;
    [HideInInspector]
    public bool IsCurrentlyMoving;
    
    #endregion

    void Awake()
    {
        //Initialize default variables
        Hunger = ShrekData.Hunger;
        Thirsty = ShrekData.Thirsty;
        Toilet = ShrekData.Toilet;
        Hygiene = ShrekData.Hygiene;
        Sleep = ShrekData.Sleep;
        Fun = ShrekData.Fun;

        ThirstyWaitTime = ShrekData.ThirstyRate;
        HungerWaitTime = ShrekData.HungerRate;
        ToiletWaitTime = ShrekData.ToiletRate;
        HygieneWaitTime = ShrekData.HygieneRate;
        SleepWaitTime = ShrekData.SleepRate;
        FunWaitTime = ShrekData.FunRate;
        MoveWaitTime = ShrekData.MoveRate;
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
            ThirstyWaitTime = ShrekData.ThirstyRate;

            if (Thirsty <= 50)
            {
                if (!IsCurrentlyRegenerating)
                {
                    IsCurrentlyRegenerating = true;
                    Player.SetDestination(ThirstyRegen.transform.position);
                    ShrekAnimator.SetBool("IsWalking", true);
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
                                ShrekAnimator.SetBool("IsWalking", false);
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
            HungerWaitTime = ShrekData.HungerRate;
            
            if (Hunger <= 50)
            {
                if (!IsCurrentlyRegenerating)
                {
                    ShrekAnimator.SetBool("IsWalking", true);
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
                                ShrekAnimator.SetBool("IsWalking", false);
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
            ToiletWaitTime = ShrekData.ToiletRate;
            
            if (Toilet <= 50)
            {
                if (!IsCurrentlyRegenerating)
                {
                    ShrekAnimator.SetBool("IsWalking", true);
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
                                ShrekAnimator.SetBool("IsWalking", false);
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
            HygieneWaitTime = ShrekData.HygieneRate;
            
            if (Hygiene <= 50)
            {
                if (!IsCurrentlyRegenerating)
                {
                    ShrekAnimator.SetBool("IsWalking", true);
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
                                ShrekAnimator.SetBool("IsWalking", false);
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
            SleepWaitTime = ShrekData.SleepRate;
            
            if (Sleep <= 50)
            {
                if (!IsCurrentlyRegenerating)
                {
                    ShrekAnimator.SetBool("IsWalking", true);
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
                                ShrekAnimator.SetBool("IsWalking", false);
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
            FunWaitTime = ShrekData.FunRate;
            
            if (Fun <= 50)
            {
                if (!IsCurrentlyRegenerating)
                {
                    ShrekAnimator.SetBool("IsWalking", true);
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
                                ShrekAnimator.SetBool("IsWalking", false);
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

        #region RandomRoam

        if (!IsCurrentlyRegenerating)
        {
            if (MoveWaitTime > 0)
            {
                MoveWaitTime -= Time.deltaTime;
            }
            else
            {
                MoveWaitTime = ShrekData.MoveRate;
                if (!IsCurrentlyMoving)
                {
                    Player.SetDestination(RandomNavmeshLocation(8.0f));
                    ShrekAnimator.SetBool("IsWalking", true);
                    IsCurrentlyMoving = true;
                }
                else
                {
                    if (Player.remainingDistance <= Player.stoppingDistance)
                    {
                        if (Player.hasPath || Player.velocity.sqrMagnitude == 0f)
                        {
                            ShrekAnimator.SetBool("IsWalking", false);
                            IsCurrentlyMoving = false;
                        }
                    }
                }
            }
        }
        else
        {
            IsCurrentlyMoving = false;
            MoveWaitTime = ShrekData.MoveRate;
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

    #region RandomPointInNavMesh

    //Find random nav mesh location
    public Vector3 RandomNavmeshLocation(float radius) {
        Vector3 randomDirection = Random.insideUnitSphere * radius;
        randomDirection += transform.position;
        NavMeshHit hit;
        Vector3 finalPosition = Vector3.zero;
        if (NavMesh.SamplePosition(randomDirection, out hit, radius, 1)) {
            finalPosition = hit.position;            
        }
        return finalPosition;
    }

    #endregion
}
