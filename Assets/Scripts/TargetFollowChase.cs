using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetFollowChase : MonoBehaviour
{
    public GameObject CubeA;

    [SerializeField]
    Action action;

    Vector3 origin, destination, directionVector;

    enum Action
    {
        Target,
        Follow,
        Chase
    }

    void Start()
    {
        origin = transform.position;
        destination = CubeA.transform.position;
        directionVector = destination - origin;
    }

    void Update()
    {
        if (action == Action.Target)
        {
            Target();
        }
        else if (action == Action.Follow)
        {
            Follow();
        }
        else if (action == Action.Chase)
        {
            Chase();
        }
    }

    void Target()
    {
        // origin is the position of Cube-B
        origin = transform.position;

        // destination is the position of Cube-A
        destination = CubeA.transform.position;

        // directionVector is the direction of Cube-A from Cube B
        directionVector = destination - origin;

        // Point this in the direction of Cube-A
        transform.forward = directionVector;
    }

    void Follow()
    {
        //directionVector = destination - origin;
        destination = CubeA.transform.position;

        transform.forward = directionVector;
        transform.position = destination - directionVector;
    }

    void Chase()
    {
        origin = transform.position;
        destination = CubeA.transform.position;
        directionVector = destination - origin;
        transform.forward = directionVector;
        transform.position += directionVector.normalized * Time.deltaTime;
    }
}
