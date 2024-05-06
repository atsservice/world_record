using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Tempo : MonoBehaviour
{
    float recordTime = 240*60*60;
    float alertTime = 24*60*60;
    public float tempoTrascorso;

    System.DateTime startTime;

    //unity GUI Text
    public Text tempoTrascorsoText;
    // Start is called before the first frame update
    void Start()
    {
        //open a file anmed start.txt
        try{
            string[] lines = System.IO.File.ReadAllLines("start.txt");        
            startTime = System.DateTime.Parse(lines[0]);                        
        }
        catch{
            startTime = System.DateTime.Now;
            System.IO.File.WriteAllText("start.txt", startTime.ToString());
        }
    }

    // Update is called once per frame
    void Update()
    {   
        tempoTrascorso=(float)(System.DateTime.Now - startTime).TotalSeconds;
        float secondi,minuti,ore,giorni;
        secondi = Mathf.FloorToInt(tempoTrascorso % 60);
        minuti = Mathf.FloorToInt(tempoTrascorso / 60 % 60);
        ore = Mathf.FloorToInt(tempoTrascorso / 3600);
        giorni = Mathf.FloorToInt(tempoTrascorso / 86400);

        //string tempometrascorso = giorni.ToString("00") + ":" + ore.ToString("00") + ":" + minuti.ToString("00") + ":" + secondi.ToString("00");
        string tempoStringa = ore.ToString("00") + ":" + minuti.ToString("00") + ":" + secondi.ToString("00");
        if (giorni > 0)
        {
            //tempoStringa = giorni + " giorni\n"+tempoStringa;
        }

        tempoTrascorsoText.text = tempoStringa;

        if (recordTime-tempoTrascorso<alertTime){
            tempoTrascorsoText.color = Color.yellow;
            if (recordTime-tempoTrascorso<0){
                tempoTrascorsoText.color = Color.red;
            }
        } 
        else{
            tempoTrascorsoText.color = Color.white;
        }
    }
}
