using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseController : MonoBehaviour
{
    private Rigidbody2D body;
    
    private static float speed = 2.0f;
    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //rotate object
        if (Input.GetKeyDown("left"))
        {
            body.rotation = (body.rotation+90f)%360;
        }
        if (Input.GetKeyDown("right"))
        {
            body.rotation = (body.rotation+270f)%360;
        }
        
        //move object
        float move = Input.GetAxis("Vertical"); //-1 backwards
        if (move != 0)
        {
            switch (body.rotation)
            {
                case 0:
                    body.velocity = move * speed * Vector3.up;
                    break;
                case 90:
                    body.velocity = move * speed * Vector3.left;
                    break;
                case 180:
                    body.velocity = move * speed * Vector3.down;
                    break;
                case 270:
                    body.velocity = move * speed * Vector3.right;
                    break;
            }
        }

        move = 0;
    }
}
