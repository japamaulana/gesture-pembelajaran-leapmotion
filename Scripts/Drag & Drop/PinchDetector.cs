using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinchDetector : MonoBehaviour
{
    [Header("Finger")]
    public Transform indexFinger;
    public Transform thumbFinger;

    [Header("Pinch Setting")]
    public float pinchDistance = 0.03f;

    public bool IsPinching()
    {
        if (indexFinger == null || thumbFinger == null)
            return false;

        float distance =
            Vector3.Distance(
                indexFinger.position,
                thumbFinger.position);

        return distance <= pinchDistance;
    }
}
