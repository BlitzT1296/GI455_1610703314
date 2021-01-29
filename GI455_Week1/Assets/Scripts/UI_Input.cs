using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UI_Input : MonoBehaviour
{
    public string[] names = new string [] {"Unity", "Unreal", "ResidentEvil", "Google", "MongoDB"};
    public string output;
    public GameObject inputField;
    public GameObject textDisplay;
    

    public void StoreInput()
    {
        output = inputField.GetComponent<Text>().text;

        for (int i = 0; i < names.Length; i++)
        {
            if (output == names[i])
            {
                textDisplay.GetComponent<Text>().text = output + " is Found";
                return; 
            }
            else 
            {
                textDisplay.GetComponent<Text>().text = output + " is not Found";
                
            }

        }
        
        //

    }
}
