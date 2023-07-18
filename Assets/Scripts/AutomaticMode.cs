using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AutomaticMode : MonoBehaviour
{
    int n;
    public void OnButtonPress(){
        n++;
        Debug.Log("Button clicked " + n + " times.");
    } 
    
}
