using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class DefaultShrekData : ScriptableObject
{
    [Header("Default Needs Values")]
    public float Hunger = 100.0f;
    public float Thirsty = 100.0f;
    public float Toilet = 100.0f;
    public float Hygiene = 100.0f;
    public float Sleep = 100.0f;
    public float Fun = 100.0f;
    
    [Header("Default Needs Drop Rate")]
    public float HungerRate = 1.0f;
    public float ThirstyRate = 1.0f;
    public float ToiletRate = 1.0f;
    public float HygieneRate = 1.0f;
    public float SleepRate = 1.0f;
    public float FunRate = 1.0f;
}
