﻿using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayAgain : MonoBehaviour
{
    public TextMeshPro Text;

    private TextMeshPro PlayAgainText;

    private GameObject BlockBehindPlayAgain;

    void Start()
    {
        this.Text = GameObject.Find("Victory").GetComponent<TextMeshPro>();
        this.PlayAgainText =
            GameObject.Find("PlayAgain").GetComponent<TextMeshPro>();
        this.BlockBehindPlayAgain = GameObject.Find("BlockBehindPlayAgain");
    }

    public void RestartTheGame()
    {
        this.Text.faceColor = new Color32(255, 255, 255, 0);
        this.PlayAgainText.faceColor = new Color32(255, 255, 255, 0);
        //this.BlockBehindPlayAgain.GetComponent<Renderer>().material.color = new Color32(255,255,255,0);
    }

    void Update()
    {
    }

    void OnMouseDown()
    {
        this.RestartTheGame();
    }
}
