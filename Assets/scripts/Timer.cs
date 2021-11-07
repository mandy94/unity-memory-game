using System.Data;
using System.Runtime.CompilerServices;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public float time = 0;
    
    private bool show = true;
    public GameObject[] memoryFields;
    private string MATERIAL_NAME= "dark";
    
    void Update()
    {
       time += Time.deltaTime;
       DisplayTime(time);    
        
    }
 
     void DisplayTime(float timeToDisplay)
    {        
        timeToDisplay += 1;
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        if(seconds % 2 == 0)
        {
            show =!show;
            time = 0;    
            ChangeScene();        
        }

        
    }
    void ChangeScene(){ 
        
        if(show == true){
            MATERIAL_NAME = "left";
        }
        else{            
            MATERIAL_NAME = "dark";
        }
        memoryFields = GameObject.FindGameObjectsWithTag("MemoryField");
        foreach (GameObject item in memoryFields){
            item.GetComponent<Renderer>().material = Resources.Load(MATERIAL_NAME, typeof(Material)) as Material;
        }
 
     
    }

}
