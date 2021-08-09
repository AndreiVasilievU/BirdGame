using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class TrapsConfig : ScriptableObject
{
    [SerializeField]
    List<TrapConfig> trapsConfig;

    public List<TrapConfig> TrapsConfigure => trapsConfig;
}

[Serializable]
public class TrapConfig
{
    [SerializeField]
    GameObject trap;

    public GameObject Trap => trap;
}
