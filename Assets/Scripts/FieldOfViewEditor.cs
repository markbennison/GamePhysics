using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(Sight))]
public class FieldOfViewEditor : Editor
{
    void OnSceneGUI()
    {
        Sight sight = (Sight)target;
        Handles.color = new Color(1, 0, 0, 0.25f);
        Vector3 positionOnGround = new Vector3(sight.transform.position.x, 0, sight.transform.position.z);
        Handles.DrawSolidArc(positionOnGround, Vector3.up, sight.FromVector, sight.angle, sight.radius);
    }
}
