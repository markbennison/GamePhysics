using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defend : MonoBehaviour
{
    public GameObject attacker;
    void Update()
    {
        Vector3 crossProduct = Vector3.Cross(transform.parent.up, attacker.transform.forward);
        Quaternion rotation = Quaternion.LookRotation(crossProduct);
        transform.rotation = rotation;
    }
}
