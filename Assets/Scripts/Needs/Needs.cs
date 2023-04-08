using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
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
    public DefaultShrekData ShrekData;
    private float Hunger;
    private float Thirsty;
    private float Toilet;
    private float Hygiene;
    private float Sleep;
    private float Fun;

    //Delays
    private float ThirstyWaitTime;
    private float HungerWaitTime;
    private float ToiletWaitTime;
    private float HygieneWaitTime;
    private float SleepWaitTime;
    private float FunWaitTime;
    private float MoveWaitTime;

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
    public Animator ShrekAnimator;

    [HideInInspector]
    public bool IsCurrentlyRegenerating;
    [HideInInspector]
    public bool IsCurrentlyMoving;

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

        StartCoroutine(UpdateNeed(Thirsty, ThirstySlider, ThirstyRegen, ThirstyWaitTime));
        StartCoroutine(UpdateNeed(Hunger, HungerSlider, HungerRegen, HungerWaitTime));
        StartCoroutine(UpdateNeed(Toilet, ToiletSlider, ToiletRegen, ToiletWaitTime));
        StartCoroutine(UpdateNeed(Hygiene, HygieneSlider, HygieneRegen, HygieneWaitTime));
        StartCoroutine(UpdateNeed(Sleep, SleepSlider, SleepRegen, SleepWaitTime));
        StartCoroutine(UpdateNeed(Fun, FunSlider, FunRegen, FunWaitTime));
    }

    void Update()
    {
        #region UpdateShrekAnimations

        if (Player.velocity.sqrMagnitude > 0)
        {
            ShrekAnimator.SetBool("IsWalking", true);
        } else if (Player.velocity.sqrMagnitude == 0)
        {
            ShrekAnimator.SetBool("IsWalking", false);
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
                    IsCurrentlyMoving = true;
                }
                else
                {
                    if (Player.remainingDistance <= Player.stoppingDistance)
                    {
                        if (Player.hasPath || Player.velocity.sqrMagnitude == 0f)
                        {
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
        Value.maxValue = 100;
        Value.value = Needs;
    }

    public void UpdateSlider(Slider Value, float Needs)
    {
        Value.value = Needs;
    }

    IEnumerator UpdateNeed(float NeedValue, Slider NeedSlider, GameObject NeedRegen, float WaitTime)
    {
        while (NeedValue > 0)
        {
            NeedValue = NeedValue - 1;
            UpdateSlider(NeedSlider, NeedValue);

            if (NeedValue <= 50)
            {
                if (!IsCurrentlyRegenerating)
                {
                    IsCurrentlyRegenerating = true;
                    Player.SetDestination(NeedRegen.transform.position);
                }
                else
                {
                    if (Vector3.Distance(Player.transform.position, NeedRegen.transform.position) < 5)
                    {
                        SetMaxNeeds(NeedSlider, 100);
                        NeedValue = 100;
                        UpdateSlider(NeedSlider, NeedValue);
                        IsCurrentlyRegenerating = false;
                    }
                }
            }
            yield return new WaitForSeconds(WaitTime);
        }
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
