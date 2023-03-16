using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawRays : MonoBehaviour
{
    void Update()
    {
        Debug.DrawRay(transform.position, transform.up, Color.green);
        Debug.DrawRay(transform.position, transform.right, Color.red);
        Debug.DrawRay(transform.position, transform.forward, Color.cyan);
    }
}
