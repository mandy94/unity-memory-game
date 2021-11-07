using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Player : MonoBehaviour
{
    
    public TextMeshPro Text;
    private TextMeshPro PlayAgain;
    private GameObject BlockBehindPlayAgain;
    void Start()
    {

        this.Text = GameObject.Find("Victory").GetComponent<TextMeshPro>();
        this.PlayAgain = GameObject.Find("PlayAgain").GetComponent<TextMeshPro>();
        this.BlockBehindPlayAgain = GameObject.Find("BlockBehindPlayAgain");
       
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.name == "End"){
            
            Debug.Log(this.Text.faceColor );

            this.Text.faceColor = new Color32(255,255,255,254);
            this.PlayAgain.faceColor = new Color32(255,255,255,254);
           // this.BlockBehindPlayAgain.GetComponent<Renderer>().material.color = new Color32(255,255,255,254);
        }
    }

    void Update()
    {
    }
}
