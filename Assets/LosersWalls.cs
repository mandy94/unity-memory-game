using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LosersWalls : MonoBehaviour
{
    private TextMeshPro Text;

    private TextMeshPro PlayAgainText;

    private void OnTriggerEnter(Collider other)
    {
        // if (other.name == "Player")
        // {
            
        //     this.Text = GameObject.Find("Victory").GetComponent<TextMeshPro>();
        //     this.PlayAgainText =
        //         GameObject.Find("PlayAgain").GetComponent<TextMeshPro>();
           
        //     this.Text.faceColor = new Color32(255, 255, 255, 254);
        // }
    }
}
