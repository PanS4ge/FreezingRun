using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IcePlayerHandler : MonoBehaviour
{
    public Vector3 IceSize = new Vector3(2,4,2);
    public Slider percentage;
    public Text temperatureText;

    [Header("Ice")]
    public GameObject ice;
    public ParticleSystem iceps;
    public Material icematerial;

    [Header("Fire")]
    public GameObject firestorm;
    public Material firestormmaterial;
    public ParticleSystem[] firestormsps;

    // Update is called once per frame
    void Update()
    {
        float i = 1F - (percentage.value * 2);

        if(i <= 0){
            i = 0;
        }

        Vector3 tempIce = ice.GetComponent<Transform>().localScale;
        tempIce = IceSize * i;
        //tempIce.y = IceSize.y * (i/2);
        ice.GetComponent<Transform>().localScale = tempIce;

        icematerial.SetFloat("_Metallic", i);

        if(i == 0){
            //ice.SetActive(false);
            iceps.maxParticles = 0;
        } else {
            //ice.SetActive(true);
            iceps.maxParticles = 1000 - (int)Math.Floor(1000 * (percentage.value * 2));
        }

        if(Math.Floor(36.6F * (percentage.value * 2)) >= 40){
            //firestorm.SetActive(true);
            firestormmaterial.SetFloat("_Metallic", percentage.value/2F);
            foreach(ParticleSystem ps in firestormsps){
                ps.maxParticles = (int)Math.Floor(1000 * (percentage.value * 2));
            }
        } else {
            //firestorm.SetActive(false);
            foreach(ParticleSystem ps in firestormsps){
                ps.maxParticles = 0;
            }
        }

        //Debug.Log(firestormmaterial.GetFloat("_Metallic"));

        temperatureText.text = Math.Floor(36.6F * (percentage.value * 2)).ToString() + "*C";
    }
}
