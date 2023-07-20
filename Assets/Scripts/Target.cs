using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log($"Target collision: {collision.gameObject.name}");
    }
}
