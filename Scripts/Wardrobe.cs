using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Wardrobe : MonoBehaviour
{
    [System.Serializable]
    public class SliderGroup {
        public Slider Red;
        public Slider Green;
        public Slider Blue;
    }
    [System.Serializable]
    public class SliderGroupButFour {
        public Slider Red;
        public Slider Green;
        public Slider Blue;
        public Slider Four;
    }

    Vector3 ToValues(SliderGroup group){
        return new Vector3(group.Red.value, group.Green.value, group.Blue.value);
    }

    Vector4 ToValues(SliderGroupButFour group){
        return new Vector4(group.Red.value, group.Green.value, group.Blue.value, group.Four.value);
    }

    void LoadSliders(SliderGroup group, Vector3 values){
        group.Red.value = values.x;
        group.Green.value = values.y;
        group.Blue.value = values.z;
    }

    void LoadSliders(SliderGroupButFour group, Vector4 values){
        group.Red.value = values.x;
        group.Green.value = values.y;
        group.Blue.value = values.z;
        group.Four.value = values.w;
    }

    // S,  B,    T,     N,   I    F
    //kin ody rousers  one  c e  ire

    public SaveFiles sf;
    public GameObject Loading;
    public string currentWardrobe = "N";
    public ColorUpdater getDataFromHere;
    public GameObject[] noneColors;
    public GameObject[] skinColors;
    public SliderGroup skinSG;
    public int CostSkin;
    public GameObject[] bodyColors;
    public SliderGroup bodySG;
    public int CostBody;
    public GameObject[] trouColors;
    public SliderGroup trouSG;
    public int CostTrousers;
    public GameObject[] iceColors;
    public SliderGroupButFour iceSG;
    public int CostIce;
    public GameObject[] fireColors;
    public SliderGroupButFour fireSG;
    public int CostFire;

    public SliderGroup tempSkin;
    public SliderGroup tempBody;
    public SliderGroup tempTrou;
    public SliderGroupButFour tempIce;
    public SliderGroupButFour tempFire;
    public Vector3 valuestempSkin;
    public Vector3 valuestempBody;
    public Vector3 valuestempTrou;
    public Vector4 valuestempIce;
    public Vector4 valuestempFire;

    
    public Text[] For100Dollars;
    public Text[] For150Dollars;

    public Slider temperature;
    public Slider LoadSlider;
    public bool Ready = false;

    // Update is called once per frame

    void NEXT_STEP(int STEP, int MAX, Slider LOAD){
        if(!Ready){
            LOAD.maxValue = MAX;
            STEP += 1;
            LOAD.value = STEP;
        }
    }

    void Start(){
        int MAX_STEPS = 6;
        int STEP = 0;

        Vector3 v = getDataFromHere.dh.data.Skin;
        skinSG.Red.value = v.x; /////;
        skinSG.Green.value = v.z; /////;
        skinSG.Blue.value = v.y; /////;

        NEXT_STEP(STEP, MAX_STEPS, LoadSlider);

        Vector3 v1 = getDataFromHere.dh.data.Body;
        bodySG.Red.value = v1.x; /////;
        bodySG.Green.value = v1.z; /////;
        bodySG.Blue.value = v1.y; /////;

        NEXT_STEP(STEP, MAX_STEPS, LoadSlider);

        Vector3 v2 = getDataFromHere.dh.data.Trousers;
        trouSG.Red.value = v2.x; /////;
        trouSG.Green.value = v2.z; /////;
        trouSG.Blue.value = v2.y; /////;

        NEXT_STEP(STEP, MAX_STEPS, LoadSlider);

        Vector4 v3 = getDataFromHere.dh.data.Ice;
        iceSG.Red.value = v3.x; /////;
        iceSG.Green.value = v3.z; /////;
        iceSG.Blue.value = v3.y; /////;
        iceSG.Four.value = v3.w; /////;

        NEXT_STEP(STEP, MAX_STEPS, LoadSlider);

        Vector4 v4 = getDataFromHere.dh.data.Fire;
        fireSG.Red.value = v4.x; /////;
        fireSG.Green.value = v4.z; /////;
        fireSG.Blue.value = v4.y; /////;
        fireSG.Four.value = v3.w; /////;

        NEXT_STEP(STEP, MAX_STEPS, LoadSlider);

        tempSkin = skinSG;
        tempBody = bodySG;
        tempTrou = trouSG;
        tempIce = iceSG;
        tempFire = fireSG;

        valuestempSkin = ToValues(tempSkin);
        valuestempBody = ToValues(tempBody);
        valuestempTrou = ToValues(tempTrou);
        valuestempIce = ToValues(tempIce);
        valuestempFire = ToValues(tempFire);

        NEXT_STEP(STEP, MAX_STEPS, LoadSlider);

        Ready = true;
    }
    void Update(){
        if(Ready){
            Loading.SetActive(false);
            getDataFromHere.dh.data.Skin = new Vector3(skinSG.Red.value, skinSG.Blue.value, skinSG.Green.value) / 255;
            getDataFromHere.dh.data.Body = new Vector3(bodySG.Red.value, bodySG.Blue.value, bodySG.Green.value) / 255;
            getDataFromHere.dh.data.Trousers = new Vector3(trouSG.Red.value, trouSG.Blue.value, trouSG.Green.value) / 255;
            getDataFromHere.dh.data.Ice = new Vector4(iceSG.Red.value, iceSG.Blue.value, iceSG.Green.value, iceSG.Four.value) / 255;
            getDataFromHere.dh.data.Fire = new Vector4(fireSG.Red.value, fireSG.Blue.value, fireSG.Green.value, fireSG.Four.value) / 255;

            foreach(var t in For100Dollars){
                if(getDataFromHere.dh.data.CoinCount >= 100){
                    t.color = Color.white;
                    t.text = "Buy (100$)";
                } else {
                    t.color = Color.red;
                    t.text = "INSUFFICIENT FUNTS\nBuy (100$)";
                }
            }

            foreach(var t in For150Dollars){
                if(getDataFromHere.dh.data.CoinCount >= 150){
                    t.color = Color.white;
                    t.text = "Buy (150$)";
                } else {
                    t.color = Color.red;
                    t.text = "INSUFFICIENT FUNTS\nBuy (150$)";
                }
            }
        } else {
            Loading.SetActive(true);
        }
    }

    public void TakeMoney(int countMoney) {
        if(getDataFromHere.dh.data.CoinCount >= countMoney){
            getDataFromHere.dh.data.CoinCount -= countMoney;
            getDataFromHere.dh.data.Skin = new Vector3(tempSkin.Red.value, tempSkin.Blue.value, tempSkin.Green.value) / 255;
            getDataFromHere.dh.data.Body = new Vector3(tempBody.Red.value, tempBody.Blue.value, tempBody.Green.value) / 255;
            getDataFromHere.dh.data.Trousers = new Vector3(tempTrou.Red.value, tempTrou.Blue.value, tempTrou.Green.value) / 255;
            getDataFromHere.dh.data.Ice = new Vector4(tempIce.Red.value, tempIce.Blue.value, tempIce.Green.value, tempIce.Four.value) / 255;
            getDataFromHere.dh.data.Fire = new Vector4(tempFire.Red.value, tempFire.Blue.value, tempFire.Green.value, tempFire.Four.value) / 255;

            ChangeWardrobe("N");
            sf.DoSave();
        } else {
            GoBacc();
        }
    }

    public void GoBacc(){
        /*getDataFromHere.dh.data.Skin = new Vector3(valuestempSkin.x, valuestempSkin.y, valuestempSkin.z) / 255;
        getDataFromHere.dh.data.Body = new Vector3(valuestempBody.x, valuestempBody.y, valuestempBody.z) / 255;
        getDataFromHere.dh.data.Trousers = new Vector3(valuestempTrou.x, valuestempTrou.y, valuestempTrou.z) / 255;
        getDataFromHere.dh.data.Ice = new Vector4(valuestempIce.x, valuestempIce.y, valuestempIce.z, valuestempIce.w) / 255;
        getDataFromHere.dh.data.Fire = new Vector4(valuestempFire.x, valuestempFire.y, valuestempFire.z, valuestempFire.w) / 255;*/
        LoadSliders(skinSG, valuestempSkin);
        LoadSliders(bodySG, valuestempBody);
        LoadSliders(trouSG, valuestempTrou);
        LoadSliders(iceSG, valuestempIce);
        LoadSliders(fireSG, valuestempFire);

        //Start();

        ChangeWardrobe("N");
    }

    void FixedUpdate(){
        if(currentWardrobe == "N"){
            foreach(GameObject noneColor in noneColors){
                noneColor.SetActive(true);
            }
        }
        else{
            foreach(GameObject noneColor in noneColors){
                noneColor.SetActive(false);
            }
        }
        
        if(currentWardrobe == "S"){
            foreach(GameObject noneColor in skinColors){
                noneColor.SetActive(true);
            }
        }
        else{
            foreach(GameObject noneColor in skinColors){
                noneColor.SetActive(false);
            }
        }
        
        if(currentWardrobe == "B"){
            foreach(GameObject noneColor in bodyColors){
                noneColor.SetActive(true);
            }
        }
        else{
            foreach(GameObject noneColor in bodyColors){
                noneColor.SetActive(false);
            }
        }
        
        if(currentWardrobe == "T"){
            foreach(GameObject noneColor in trouColors){
                noneColor.SetActive(true);
            }
        }
        else{
            foreach(GameObject noneColor in trouColors){
                noneColor.SetActive(false);
            }
        }

        if(currentWardrobe == "I"){
            foreach(GameObject noneColor in iceColors){
                noneColor.SetActive(true);
            }
        }
        else{
            foreach(GameObject noneColor in iceColors){
                noneColor.SetActive(false);
            }
        }

        if(currentWardrobe == "F"){
            foreach(GameObject noneColor in fireColors){
                noneColor.SetActive(true);
            }
        }
        else{
            foreach(GameObject noneColor in fireColors){
                noneColor.SetActive(false);
            }
        }

        if(currentWardrobe == "I"){
            temperature.value -= 0.01f;
        }
        else if(currentWardrobe == "F"){
            temperature.value += 0.01f;
        }
        else{
            if(temperature.value < 0.505f){
                temperature.value += 0.001f;
            }
            else if(temperature.value > 0.505f){
                temperature.value -= 0.001f;
            }
        }
    }

    public void ChangeWardrobe(string c){
        currentWardrobe = c;
    }
}
