using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleEdgeColliderGenerator : MonoBehaviour
{
    EdgeCollider2D edgeColl;

    public float radius = 1;
    public int numberOfVerts = 32;

    public List<Vector2> newVerticies = new List<Vector2>();

    // Start is called before the first frame update
    void Start()
    {
        edgeColl = GetComponent<EdgeCollider2D>();

        float angleIncrement = 2f * Mathf.PI / (numberOfVerts -1);
        for (int i = 0; i < numberOfVerts; i++)
        {
            print(i);
            Vector2 newPos = new Vector2(Mathf.Cos(i * angleIncrement) * radius, Mathf.Sin(i * angleIncrement) * radius);
            newVerticies.Add(newPos);
        }
        edgeColl.points = newVerticies.ToArray();
    }
}
