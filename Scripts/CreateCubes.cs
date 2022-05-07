using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateCubes : MonoBehaviour
{
    public Vector3[] startOfLines;
    public int breakBetween;
    public int breakBetweenMinRandomNumber;
    public int breakBetweenMaxRandomNumber;
    public bool randomBreak = false;
    public int lengthOfLines;

    [System.Serializable]
    public class CubeData{
        public GameObject cube;// { get; set; }
        // Probability to 100
        public int Probability;// { get; set; }
    }
    public CubeData[] cubes;
    void Start()
    {
        //foreach(var a in chanceTable()){
        //    Debug.Log(a);
        //}
        for(int j = 0; j < startOfLines.Length; j++){
            Vector3 temp = startOfLines[j];
            System.Random rand = new System.Random();
            GameObject[] ct = chanceTable();
            int temp2 = rand.Next(1, ct.Length);
            for(int i = 0; i < lengthOfLines; i++){
                if(randomBreak){
                    breakBetween = rand.Next(breakBetweenMinRandomNumber, breakBetweenMaxRandomNumber);
                }
                if(i % breakBetween == 0){
                    if(ct[temp2] != null){
                        Instantiate(ct[temp2], new Vector3(temp.x, temp.y, temp.z + i), Quaternion.identity);
                    }
                    temp2 += 1;
                    if(temp2 >= ct.Length){
                        temp2 = 0;
                    }
                }
            }
        }
    }

    GameObject[] chanceTable(){
        int last = 0;
        GameObject[] goa = new GameObject[100];
        foreach(CubeData cube in cubes){
            for(int i = 0; i < cube.Probability; i++){
                goa[last] = cube.cube;
                last++;
            }
        }
        System.Random rand = new System.Random();
        return goa.OrderBy(x => rand.Next()).ToArray();
    }
}
