using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class MainMenu : MonoBehaviour
{
    public Text update;
    public DataHolder dh;
    public void Play(){
        SceneManager.LoadScene(1);
    }

    public void Wardrobe(){
        SceneManager.LoadScene(2);
    }

    public void Exit(){
        Application.Quit();
    }

    void Update(){
        update.text = "Play level: " + dh.data.Level;
    }
}
