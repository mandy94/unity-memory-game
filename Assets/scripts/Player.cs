using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public TextMeshPro Text;

    private TextMeshPro PlayAgain;

    private GameObject BlockBehindPlayAgain;

    void Start()
    {
        this.Text = GameObject.Find("Victory").GetComponent<TextMeshPro>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "End")
        {
            this.Text.text = "VICTORY!!";
            GameStart.CanClick = false;
            this.PlayAgain =
                GameObject.Find("PlayAgain").GetComponent<TextMeshPro>();
            this.Text.faceColor = new Color32(255, 255, 255, 254);
            this.PlayAgain.faceColor = new Color32(255, 255, 255, 254);
        }
        else if (other.name.Contains("Wall") == true)
        {
            GameStart.CanClick = false;
            this.Text.text = "DEFEAT!";
            this.PlayAgain =
                GameObject.Find("PlayAgain").GetComponent<TextMeshPro>();
            this.Text.faceColor = new Color32(255, 255, 255, 254);
            this.PlayAgain.faceColor = new Color32(255, 255, 255, 254);
        }
    }
}
