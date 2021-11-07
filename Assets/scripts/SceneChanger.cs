using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;  
using TMPro;
public class SceneChanger : MonoBehaviour
{

    public TMP_InputField mainInputField;
    public static int MATRIX_SIZE;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void StartGame() {  
        
        if( int.TryParse(this.mainInputField.text, out SceneChanger.MATRIX_SIZE)){
            SceneManager.LoadScene("GameScene");  
            Debug.Log(MATRIX_SIZE);
        }
    }  
}
