using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ChangerCube : MonoBehaviour
{
    //public Collider player;
    //public Slider temperature;
    public ParticleSystem onGet;
    public GameObject go;
    public float PlusSlider;
    void OnTriggerEnter(Collider other)
    {
        //Debug.Log("TriggerEnter");
        if(other.name == "Player (All)"){
            Slider s = other.gameObject.GetComponent<Useless>().Temperature;
            float temp = s.value;
            s.value += PlusSlider;
            if(s.value == temp){
                System.Random r = new System.Random();
                other.gameObject.GetComponent<DataHolder>().data.CoinCount += r.Next(1, 5);
            }
            onGet.Play();
            Destroy(go);
        }
    }
}
