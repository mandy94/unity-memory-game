using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStart : MonoBehaviour
{
    public GameObject firstField = null;

    public GameObject secondField = null;

    private GameObject[] memoryFields;

    public GameObject player;

    private bool clicable = true;

    void Start()
    {
        /*   memoryFields = GameObject.FindGameObjectsWithTag("MemoryTile");
        foreach (GameObject item in memoryFields)
        {
            item.GetComponent<Renderer>().material =
                Resources.Load("dark", typeof (Material)) as Material;
        }*/
    }

    public void revalField(GameObject field, string fieldValue)
    {
        if (firstField == null)
            firstField = field;
        else
            secondField = field;

        field.GetComponent<Renderer>().material =
            Resources.Load(fieldValue, typeof (Material)) as Material;
    }

    public bool canClick()
    {
        return clicable;
    }

    public IEnumerator checkIfEqual()
    {
        clicable = false;
        yield return new WaitForSeconds(1);
        clicable = true;

        if (
            firstField.GetComponent<Renderer>().material.name ==
            secondField.GetComponent<Renderer>().material.name
        )
        {
            Destroy (firstField);
            Destroy (secondField);
           // MovePlayer(firstField.GetComponent<Renderer>().material.name);
        }
        else
        {
            firstField.GetComponent<Renderer>().material =
                Resources.Load("dark", typeof (Material)) as Material;
            secondField.GetComponent<Renderer>().material =
                Resources.Load("dark", typeof (Material)) as Material;
        }
        firstField = null;
        secondField = null;
    }

    void MovePlayer(string movement)
    {
        if (movement.Contains("leftleft"))
            player.transform.position = new Vector2(1, 0);
    }
}
