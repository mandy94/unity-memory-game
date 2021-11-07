using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStart : MonoBehaviour
{
    public GameObject firstField = null;

    public GameObject secondField = null;

    private GameObject[] memoryFields;

    public GameObject player;
    public GameObject end;

    private bool clicable = true;

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
            MovePlayer(firstField.GetComponent<Renderer>().material.name, 
            firstField.GetComponent<Collider>().bounds.size.x);
            Destroy (firstField);
            Destroy (secondField);
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
    private string movement;
    private float step;
    private bool timeToMove = false;
    void MovePlayer(string movement , float step)
    {
   
        if (movement.Contains("left"))
            player.transform.position += new Vector3(step*1.1f, 0);
        if (movement.Contains("up"))
            player.transform.position += new Vector3(0,-step*1.1f, 0);
        if (movement.Contains("right"))
            player.transform.position += new Vector3(-step*1.1f,0, 0);
        if (movement.Contains("down"))
            player.transform.position += new Vector3(0,step*1.1f, 0);
            // this.timeToMove = true;
            // this.step = step;
            // this.movement = movement;
          

    }


   

}
