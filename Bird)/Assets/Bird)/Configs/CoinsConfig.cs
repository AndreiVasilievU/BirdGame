using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class CoinsConfig : ScriptableObject
{
    [SerializeField]
    List<CoinConfig> coinsConfig;

    public List<CoinConfig> CoinsConfigure => coinsConfig;
}

[Serializable]
public class CoinConfig
{
    [SerializeField]
    GameObject coin;

    public GameObject Coin => coin;
}
