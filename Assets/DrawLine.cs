using System.Collections.Generic;
using UnityEngine;

public class DrawLine : MonoBehaviour
{
    public GameObject linePrefab;
    private LineRenderer currentLine;
    private EdgeCollider2D edgeCollider;

    private List<Vector2> points = new List<Vector2>();

    [Header("Ink Settings")]
    public float maxInk = 5f;
    private float currentInk;

    public float inkUseRate = 1f;
    public float inkRegenRate = 0.5f;

    void Start()
    {
        currentInk = maxInk;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && currentInk > 0)
        {
            CreateLine();
        }
        
        if (Input.GetMouseButton(0) && currentInk > 0 && currentLine != null)
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePos.z = 0f;

            AddPoint(mousePos);
            
            currentInk -= inkUseRate * Time.deltaTime;
            currentInk = Mathf.Clamp(currentInk, 0, maxInk);
            
            if (currentInk <= 0)
            {
                currentLine = null;
            }
        }
        
        if (!Input.GetMouseButton(0))
        {
            currentInk += inkRegenRate * Time.deltaTime;
            currentInk = Mathf.Clamp(currentInk, 0, maxInk);
        }
    }

    public float GetInkPercent()
    {
        return currentInk / maxInk;
    }

    void CreateLine()
    {
        GameObject lineObj = Instantiate(linePrefab);
        
        Destroy(lineObj, 7f);
        
        currentLine = lineObj.GetComponent<LineRenderer>();
        edgeCollider = lineObj.GetComponent<EdgeCollider2D>();

        points.Clear();
        
        currentLine.startWidth = 0.1f;
        currentLine.endWidth = 0.1f;
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