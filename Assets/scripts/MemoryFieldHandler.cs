using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MemoryFieldHandler : MonoBehaviour
{
    public string fieldValue; // ime materijala koji prikazuje kada se okrene

    private int clickCounter = 0;

    public GameStart gameStart;

    void Start()
    {
        gameStart =
            GameObject
                .FindGameObjectsWithTag("Start")[0]
                .GetComponent<GameStart>();
    }

    void OnMouseDown()
    {
        if (gameStart.canClick())
        {
            if (gameStart.firstField == null)
                gameStart.revalField(this.gameObject, fieldValue);
            else
            {
                if (gameStart.firstField != this.gameObject)
                {
                    gameStart.revalField(this.gameObject, fieldValue);
                    StartCoroutine(gameStart.checkIfEqual());
                }
            }
        }
    }
}
