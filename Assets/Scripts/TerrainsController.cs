using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public class TerrainsController : MonoBehaviour
{
    public TerrainData tr;
    public string place;
    public bool makeTrrain;

    // Start is called before the first frame update
    void Start(){
        if(makeTrrain) MakeTrrain();
    }

    void MakeTrrain()
    {
        int i, j;

        float[,] heights = new float[4097, 4097];

        string file_path = $"Assets/MapsData/{place}.csv";
        StreamReader sr = new StreamReader(file_path);
        string text = sr.ReadToEnd();
        string[] rows = text.Split('\n');

        i = 0;
        foreach(string row in rows){
            string[] cols = row.Split(',');
            j = 0;
            foreach(string col in cols){
                float height;
                if(col == "e"){
                    height = 0;
                }else if(col == ""){
                    height = 0;
                }else{
                    height = float.Parse(col);
                }
                // Debug.Log(height);
                heights[i, 4096 - j] = height / (4097 * 5);
                j++;
            }
            i++;
        }
        tr.SetHeights(0, 0, heights);
        sr.Close();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
