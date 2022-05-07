using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class EndOfGame : MonoBehaviour
{
    public Slider temperature;
    public GameObject toohot;
    public GameObject warmup;
    public GameObject toocold;
    public SaveFiles sf;
    public bool ended;
    public bool IsEnd(){
        return ended;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void ResetGame(){
        SceneManager.LoadScene(0);
    }

    public void Wardrobe(){
        SceneManager.LoadScene(2);
    }

    public void MainMenu(){
        SceneManager.LoadScene(0);
    }

    void OnTriggerEnter(Collider other)
    {
        //Debug.Log("TriggerEnter");
        if(other.name == "Player (All)"){
            ended = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(ended == true){
            sf.dh.data.Level += 1;
            sf.DoSave();
            if(temperature.value < 0.5F){
                toocold.SetActive(true);
            }
            else if(temperature.value > 0.5F && temperature.value < 0.51F){
                warmup.SetActive(true);
            } else {
                toohot.SetActive(true);
            }
            ended = false;
        }
    }
}
