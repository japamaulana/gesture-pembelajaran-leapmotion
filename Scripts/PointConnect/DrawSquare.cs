using System.Collections.Generic;
using UnityEngine;

public class DrawSquare : MonoBehaviour
{
    public LineRenderer lineRenderer;

    private List<Vector3> points = new List<Vector3>();

    //====================================================
    // Menambah titik ke Line Renderer
    //====================================================

    public void AddPoint(Vector3 newPoint)
    {
        points.Add(newPoint);

        lineRenderer.positionCount = points.Count;
        lineRenderer.SetPositions(points.ToArray());
    }

    //====================================================
    // Menghapus semua garis
    //====================================================

    public void ResetLine()
    {
        points.Clear();

        lineRenderer.positionCount = 0;
    }

    //====================================================
    // Mengembalikan jumlah titik yang sudah dibuat
    //====================================================

    public int GetPointCount()
    {
        return points.Count;
    }

    //====================================================
    // Mengecek apakah bangun sudah selesai
    //====================================================

    public bool IsComplete()
    {
        return points.Count == 5;
    }

    //====================================================
    // Mengambil seluruh titik
    //====================================================

    public List<Vector3> GetPoints()
    {
        return points;
    }
}