using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorUpdater : MonoBehaviour
{
    public Material body;
    public Material skin;
    public Material trousers;
    public Material ice;
    public Material fire;
    public DataHolder dh;
    void Update()
    {
        skin.SetColor("_Color", new Color(dh.data.Skin.x, dh.data.Skin.y, dh.data.Skin.z));
        body.SetColor("_Color", new Color(dh.data.Body.x, dh.data.Body.y, dh.data.Body.z));
        trousers.SetColor("_Color", new Color(dh.data.Trousers.x, dh.data.Trousers.y, dh.data.Trousers.z));
        ice.SetColor("_Color", new Color(dh.data.Ice.x, dh.data.Ice.y, dh.data.Ice.z, dh.data.Ice.w));
        fire.SetColor("_Color", new Color(dh.data.Fire.x, dh.data.Fire.y, dh.data.Fire.z, dh.data.Fire.w));
    }
}
