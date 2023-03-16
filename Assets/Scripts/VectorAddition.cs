using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;
using UnityEngine.UI;

public class VectorAddition : MonoBehaviour
{
    // Only built-in .NET structures can be declared as constant
    // so we will use the 'ReadOnly' attribute (using Unity.Collections)
    [ReadOnly]
    Vector2 acceleration = new  Vector2(0, -1);

    Vector2 position;
    Vector2 velocity;

    float timerCount = 0f;
    float timeDelay = 2f;

    public Text positionText;
    public Text velocityText;
    public Text accelerationText;

    void Start()
    {
        position = new Vector2(1, 1);
        velocity = new Vector2(1, 3);

        MoveObject();
        PrintResults();
    }

    void Update()
    {
        timerCount += Time.deltaTime;

        if (timerCount > timeDelay)
        {
            timerCount = 0;
            AddVectors();
            MoveObject();
            PrintResults();
        }
    }

    void AddVectors()
    {
        position = position + velocity;     // position += velocity;
        velocity = velocity + acceleration; // velocity += acceleration;
    }

    void MoveObject()
    {
        this.transform.position = position;
    }

    void PrintResults()
    {
        positionText.text = "Position = " + position.ToString();
        velocityText.text = "Velocity = " + velocity.ToString();
        accelerationText.text = "Acceleration = " + acceleration.ToString();
    }
}
