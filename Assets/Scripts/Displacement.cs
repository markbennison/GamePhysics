using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Displacement : MonoBehaviour
{
    public GameObject CubeA, CubeB;

    [SerializeField]
    DisplacementType displacementType;

    Vector3 A, B, directionVector;

    enum DisplacementType
    {
        A_minus_B,
        B_minus_A,
        Right,
        Up,
        Right_add_Up
    }

    void Start()
    {

    }

    void Update()
    {
        DisplaceObject();

    }

    void DisplaceObject()
    {
        directionVector = Vector3.zero;

        A = CubeA.transform.position;
        B = CubeB.transform.position;

        if (displacementType == DisplacementType.A_minus_B)
        {
            directionVector = (A - B);
        }
        else if (displacementType == DisplacementType.B_minus_A)
        {
            directionVector = (B - A);
        }
        else if (displacementType == DisplacementType.Right)
        {
            directionVector = Vector3.right;  // or = CubeA.transform.right
        }
        else if (displacementType == DisplacementType.Up)
        {
            directionVector = Vector3.up;  // or = CubeA.transform.up
        }
        else if (displacementType == DisplacementType.Right_add_Up)
        {
            directionVector = Vector3.right + Vector3.up;
            // or directionVector = CubeA.transform.right + CubeA.transform.up
        }

        // normalise direction so its length is assumed to be 1
        directionVector.Normalize();

        // this is too fast on the scale we're working, so divide by 100 (x 0.01)
        directionVector *= 0.01f;

        // add the directionVector to Cube A, displacing it.
        CubeA.transform.position += directionVector;

        Debug.DrawRay(CubeA.transform.position, directionVector * 300, Color.yellow);
    }
}
