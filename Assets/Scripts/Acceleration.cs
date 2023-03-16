using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class Acceleration : MonoBehaviour
{
    public Text VelocityA, VelocityB, VelocityC, ButtonBool;

    [SerializeField]
    AcclerationType acclerationType;

    Vector3 directionVector, acceleration, velocity;
    float speed = 0.01f;
    float friction = 0.01f;
    bool move = false;

    enum AcclerationType
    {
        None,
        Constant,
        Inertia
    }

    void Start()
    {
        directionVector = Vector3.right;
        CalculateVelocity();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            move = true;
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            move = false;
        }

        if (acclerationType == AcclerationType.None)
        {
            ZeroAcceleration();
        }
        else if (acclerationType == AcclerationType.Constant)
        {
            ConstantAcceleration();
        }
        else if (acclerationType == AcclerationType.Inertia)
        {
            AccelerationWithFriction();
        }
    }

    void ZeroAcceleration()
    {
        acceleration = new Vector3(0, 0, 0);
        velocity += acceleration * Time.deltaTime;
        transform.position += velocity;

        PrintResult(VelocityA);
    }

    void ConstantAcceleration()
    {
        acceleration = new Vector3(0.01f, 0, 0);
        velocity += acceleration * Time.deltaTime;
        transform.position += velocity;

        PrintResult(VelocityB);
    }

    void AccelerationWithFriction()
    {
        if (move)
        {
            acceleration = new Vector3(0.02f, 0, 0);
        }
        else
        {
            acceleration = new Vector3(-0.02f, 0, 0);
        }

        velocity += acceleration * Time.deltaTime;

        if (velocity.x < 0.0f)
        {
            velocity = Vector3.zero;
        }

        transform.position += velocity;

        PrintResult(VelocityC);
        ButtonBool.text = "Button Down = " + move;
    }

    void CalculateVelocity()
    {
        Vector3 initialPosition = transform.position;
        Vector3 finalPosition = transform.position + (directionVector.normalized * speed) * Time.deltaTime;
        velocity = (finalPosition - initialPosition) / Time.deltaTime;
    }

    void PrintResult(Text textbox)
    {
        textbox.text = "( ";
        textbox.text += Math.Round(velocity.x * 100);
        textbox.text += ", ";
        textbox.text += Math.Round(velocity.y * 100);
        textbox.text += ", ";
        textbox.text += Math.Round(velocity.z * 100);
        textbox.text += ")";
    }
}
