using UnityEngine;

public class Sight : MonoBehaviour
{
    public GameObject player;
    private float distance;

    public float angle = 120f;
    public float radius = 10f;

    public Vector3 FromVector
    {
        get
        {
            float leftAngle = -angle / 2;
            leftAngle += transform.eulerAngles.y;
            return new Vector3(Mathf.Sin(leftAngle * Mathf.Deg2Rad), 0, Mathf.Cos(leftAngle * Mathf.Deg2Rad));
        }
    }

    void Update()
    {
        Vector3 directionVector = (transform.position - player.transform.position).normalized;
        //// Note: the following only looks at x-z axis, i.e. the 2D distance ignoring the height
        //distance = Mathf.Sqrt(Mathf.Pow(directionVector.x, 2) + Mathf.Pow(directionVector.z, 2));
        distance = Vector3.Distance(transform.position, player.transform.position);

        float dotProduct = Vector3.Dot(directionVector, transform.forward);

        if(dotProduct < -0.5f)
        {
            Debug.Log(dotProduct + ": IN FIELD OF VIEW. Distance = " + distance);
        }
        else
        {
            Debug.Log(dotProduct + ": OUT OF SIGHT. Distance: " + distance);
        }
    }
}
