using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DataKeeper : MonoBehaviour
{
    public DataHolder dh;
    [Header("Text keepers")]
    public Text coin;

    void Update()
    {
        coin.text = "$" + dh.data.CoinCount;
    }
}
