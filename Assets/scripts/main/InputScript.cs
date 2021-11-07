using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI; // Required when Using UI elements.


public class InputScript : MonoBehaviour
{
   
    public TMP_InputField mainInputField;
    public Button newGameButton;

    public void Start()
    {
        
        mainInputField.onValueChanged.AddListener(delegate {ValueChangeCheck(); });
    }

    // Invoked when the value of the text field changes.
    public void ValueChangeCheck()
    {
        int n;
        if(int.TryParse(this.mainInputField.text, out n)){
            if(n>2 && n <99){
               newGameButton.interactable = true;
            }else
                newGameButton.interactable = false;
        }else
                newGameButton.interactable = false;
    }

}
