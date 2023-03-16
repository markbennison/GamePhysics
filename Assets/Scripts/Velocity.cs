using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Velocity : MonoBehaviour
{
    Vector3 finalPosition, initialPosition, directionVector, velocity;
    int speed = 3;

    public Vector3 wind;

    void Start()
    {
        directionVector = Vector3.down;
        wind = Wind();
    }

    void Update()
    {
        //wind = Wind();
        initialPosition = transform.position;
        transform.position += ((directionVector.normalized * speed) + wind) * Time.deltaTime;
        finalPosition = transform.position;
        velocity = (finalPosition - initialPosition) / Time.deltaTime;
    }

    Vector3 Wind()
    {
        return new Vector3(Random.Range(-1, 1), 0f, Random.Range(-1, 1));
    }
}
