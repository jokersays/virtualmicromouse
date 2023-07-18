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
        
        Rigidbody2D body = GetComponent<Rigidbody2D>();
        moveObject(body);
    }

    private void moveObject(Rigidbody2D body)
    {
        //move object
        switch (body.rotation)
        {
            case 0:
                body.position = body.position+Vector2.up;
                break;
            case 90:
                body.position = body.position+Vector2.left;
                break;
            case 180:
                body.position = body.position+Vector2.down;
                break;
            case 270:
                body.position = body.position+Vector2.right;
                break;
        }
    }
    
}
