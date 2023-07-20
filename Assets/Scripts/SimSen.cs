using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimSen : MonoBehaviour, ISensor
{
    private bool contact = false;

    public string Name { get; set; }

    public void Start()
    {
        Name = name;
        Debug.Log($"{Name} is running.");
        //Name = "ACTIVE - SimSen1";
    }

    public bool HasContact()
    {
        return contact;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.isTrigger)
        {
            if (collision.gameObject.CompareTag("Target"))
            {
                GameObject.Find("Player").GetComponent<AutomaticMode>().Running = false;
            }
        }
        else
        {
            contact = true;
        }
    }

    public void OnTriggerExit2D()
    {
        contact = false;
    }

}
