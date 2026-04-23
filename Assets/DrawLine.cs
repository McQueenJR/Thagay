using System.Collections.Generic;
using UnityEngine;

public class DrawLine : MonoBehaviour
{
    public GameObject linePrefab;
    private LineRenderer currentLine;
    private EdgeCollider2D edgeCollider;

    private List<Vector2> points = new List<Vector2>();

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            CreateLine();
        }
        else if (Input.GetMouseButton(0))
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            AddPoint(mousePos);
        }
    }

    void CreateLine()
    {
        GameObject lineObj = Instantiate(linePrefab);
        currentLine = lineObj.GetComponent<LineRenderer>();
        edgeCollider = lineObj.GetComponent<EdgeCollider2D>();

        points.Clear();
    }

    void AddPoint(Vector2 point)
    {
        if (points.Count > 0 && Vector2.Distance(points[points.Count - 1], point) < 0.1f)
            return;

        points.Add(point);

        currentLine.positionCount = points.Count;
        currentLine.SetPosition(points.Count - 1, point);

        edgeCollider.points = points.ToArray();
    }
}