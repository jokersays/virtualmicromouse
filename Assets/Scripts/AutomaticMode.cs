using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AutomaticMode : MonoBehaviour
{

    private bool running = false;
    private float moveSpeed = 2;
    private float turnSpeed = 2;
    private Rigidbody2D body;


    public void Start()
    {
        Debug.Log("Start.");
        body = GetComponent<Rigidbody2D>();
    }

    public void OnButtonPress()
    {
        running = true;
    }

    public void FixedUpdate()
    {
        if (running)
        {
            bool objectAhead = UpdateCollisionSensors();
            if (objectAhead)
            {
                body.transform.Rotate(Vector3.forward, 90);
            }
            else
            {
                body.transform.Translate(Vector3.up * moveSpeed * Time.deltaTime);
            }

        }
    }


    private bool UpdateCollisionSensors()
    {
        bool collisionDetected = false;
        ISensor[] sensors = GetComponentsInChildren<ISensor>();
        foreach (ISensor sensor in sensors)
        {
            bool contact = sensor.CheckCollision();
            Debug.Log($"{sensor.Name} returns {(contact ? "nearby" : "no")} contact.");
            collisionDetected = collisionDetected || contact;
        }

        return collisionDetected;
    }

}
