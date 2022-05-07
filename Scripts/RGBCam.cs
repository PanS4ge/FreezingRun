using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RGBCam : MonoBehaviour
{
    public Camera cam;
    public Vector3 speedPerColor;
    void Update()
    {
        Color v = cam.backgroundColor;
        //Debug.Log(v);
        if(v.r >= 0.9F){
            //v.r -= speedPerColor.x/255;
            v.r = 0;
        } else {
            v.r += speedPerColor.x/255;
        }
        if(v.g >= 0.9F){
            //v.g -= speedPerColor.y/255;
            v.g = 0;
        } else {
            v.g += speedPerColor.y/255;
        }
        if(v.b >= 0.9F){
            //v.b -= speedPerColor.z/255;
            v.b = 0;
        } else {
            v.b += speedPerColor.z/255;
        }
        cam.backgroundColor = v;
    }
}
