using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MemoryFieldHandler : MonoBehaviour
{
    public string fieldValue; // ime materijala koji prikazuje kada se okrene

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
        if (GameStart.CanClick)
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
            if (gameStart.memoryFields.Length == 0)
            {
                //you also lost
            }
        }
    }
}
