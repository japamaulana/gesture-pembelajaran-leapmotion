using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShapeDrag : MonoBehaviour
{
    private static ShapeDrag currentDragging = null;

    [Header("Reference")]
    public Transform indexFinger;
    public PinchDetector pinchDetector;

    [Header("Setting")]
    public float touchDistance = 0.05f;

    [HideInInspector]
    public bool isDragging = false;

    [HideInInspector]
    public bool isChecked = false;

    private Vector3 startPosition;

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
    if (isChecked)
        return;

    if (indexFinger == null || pinchDetector == null)
        return;

        // ======================
        // Mulai Drag
        // ======================
        if (!isDragging)
    {
        // kalau sudah ada objek lain yang sedang dipegang
        if (currentDragging != null)
            return;

        float distance =
            Vector3.Distance(indexFinger.position,
                            transform.position);

        if (distance <= touchDistance &&
            pinchDetector.IsPinching())
        {
            isDragging = true;
            currentDragging = this;
        }

        return;
    }

        // ======================
        // Sedang Drag
        // ======================
        transform.position = indexFinger.position;

        // ======================
        // Cubitan dilepas
        // ======================
        if (!pinchDetector.IsPinching())
    {
        isDragging = false;
        currentDragging = null;
    }
    }

    public void ResetPosition()
    {
        transform.position = startPosition;
        isChecked = false;
    }

    public void KeepPosition(Vector3 pos)
    {
        transform.position = pos;
        startPosition = pos;
        isChecked = true;
    }
}