using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimSen : MonoBehaviour, ISensor
{
    private bool contact = false; 

    public string Name { get; set; } = "SimSen1";

    public void Start()
    {
        Debug.Log($"{Name} is running.");
        //Name = "ACTIVE - SimSen1";
    }

    public bool CheckCollision()
    {
        return contact;
    }

    public void OnTriggerEnter2D()
    {
        Debug.Log("CONTACT!");
        contact = true;
    }

    public void OnTriggerExit2D()
    {
        Debug.Log("All clear.");
        contact = false;
    }

}
