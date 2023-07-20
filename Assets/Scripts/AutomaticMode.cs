using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AutomaticMode : MonoBehaviour
{

    private bool running = false;
    private bool autoTurn = true;
    private bool autoRun = true; 
    private float moveSpeed = 2;
    //private float turnSpeed = 10;
    private Rigidbody2D body;
    private ISensor frontSensor;
    private ISensor leftSensor;
    private ISensor rightSensor;

    public AnimatorOverrideController yellow;
    public AnimatorOverrideController mouse;

    public bool Running { get => running; set => running = value; }

    public void Start()
    {
        Debug.Log("Start.");
        body = GetComponent<Rigidbody2D>();
    }

    public void OnButtonPress()
    {
        InitializeCollisionSensors();
        running = true;
    }

    public void FixedUpdate()
    {
        if (running)
        {
            
            if (frontSensor.HasContact())
            {
                if (!autoRun)
                {
                    running = false;
                }
                if (autoTurn)
                {
                    if (!rightSensor.HasContact())
                    {
                        body.transform.Rotate(Vector3.forward, -90);
                    }
                    else if (!leftSensor.HasContact())
                    {
                        body.transform.Rotate(Vector3.forward, 90);
                    }
                    else
                    {
                        body.transform.Rotate(Vector3.forward, 180);
                    }
                }
            }
            else
            {
                body.transform.Translate(Vector3.up * moveSpeed * Time.deltaTime);
            }

        }
    }


    private void InitializeCollisionSensors()
    {
        ISensor[] sensors = GetComponentsInChildren<ISensor>();
        foreach (ISensor sensor in sensors)
        {
            switch (sensor.Name)
            {
                case "SensorFront":
                    frontSensor = sensor;
                    break;
                case "SensorLeft":
                    leftSensor = sensor;
                    break;
                case "SensorRight":
                    rightSensor = sensor;
                    break;
            }
        }
    }

    public void OnAutoTurnChanged()
    {
        autoTurn = !autoTurn;
    }

    public void OnAutoRunChanged()
    {
        autoRun = !autoRun;
    }

    public void OnModelSelectionChanged(float value)
    {
        switch (value)
        {
            case 0:
                GetComponent<Animator>().runtimeAnimatorController = null;
                break;
            case 1: 
                GetComponent<Animator>().runtimeAnimatorController = yellow as RuntimeAnimatorController;
                break;
            case 2:
                GetComponent<Animator>().runtimeAnimatorController = mouse as RuntimeAnimatorController;
                break;
        }
        
    }
}
