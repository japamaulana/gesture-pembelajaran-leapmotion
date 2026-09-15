using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialHandAnimation : MonoBehaviour
{
    public RectTransform hand;
    public RectTransform pointA;
    public RectTransform pointB;

    public float speed = 1.5f;

    private bool movingToB = true;

    void Start()
    {
        hand.position = pointA.position;
    }

    void Update()
    {
        if (movingToB)
        {
            hand.position = Vector3.MoveTowards(
                hand.position,
                pointB.position,
                speed * Time.deltaTime);

            if (Vector3.Distance(hand.position, pointB.position) < 1f)
            {
                movingToB = false;
            }
        }
        else
        {
            hand.position = Vector3.MoveTowards(
                hand.position,
                pointA.position,
                speed * Time.deltaTime);

            if (Vector3.Distance(hand.position, pointA.position) < 1f)
            {
                movingToB = true;
            }
        }
    }
}