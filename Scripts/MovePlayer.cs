using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MovePlayer : MonoBehaviour
{
    public Transform player;
    public Slider move;
    public float speed = 0.1F;
    public bool useWeightCalculation = true;
    public float WeightPerVol = 2;
    public float SlowPerWeight = 0.001F;
    public float WeightMax;
    public float lastSpeed;
    public float slowable;
    public float lastVolume;
    public GameObject[] allPlayer;
    // Update is called once per frame
    float CalculateVolume(){
        if(useWeightCalculation){
            float temp = 0;
            foreach(GameObject t in allPlayer){
                if(t.active == true){
                    temp += t.transform.localScale.x * t.transform.localScale.y * t.transform.localScale.z;
                }
            }
            return temp;
        } else {
            return 1;
        }
    }
    void Start(){
        if(useWeightCalculation){
            WeightMax = CalculateVolume();
        } else {
            WeightMax = 1;
        }
    }

    float Slowable(){
        return SlowPerWeight*((WeightMax - CalculateVolume())*WeightPerVol);
    }

    void Update()
    {
        lastVolume = CalculateVolume();
        slowable = Slowable();
        Vector3 a = player.transform.localPosition;
        a.x = move.value - 4.5F;
        a.z += speed * Time.deltaTime - Slowable();
        lastSpeed = speed * Time.deltaTime - Slowable();
        player.transform.localPosition = a;
    }
}
