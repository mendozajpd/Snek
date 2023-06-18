using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PulseSettings", menuName = "ScriptableObjects/Pulse Settings")]
public class PulseSettingsSO : ScriptableObject
{
    public float PulseSize;
    public float PulseFrequency;
    public float OriginalObjectSize;
    public float ColliderSize;
}
