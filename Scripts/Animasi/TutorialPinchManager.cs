using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialPinchManager : MonoBehaviour
{
    public RectTransform handOpen;
    public RectTransform handPinch;

    public RectTransform objectImage;
    public RectTransform dropArea;

    public float speed = 250f;

    private Vector3 handStartPos;
    private Vector3 objectStartPos;

    void Start()
    {
        handStartPos = handOpen.position;
        objectStartPos = objectImage.position;

        StartCoroutine(TutorialLoop());
    }

    IEnumerator TutorialLoop()
    {
        while (true)
        {
            //--------------------------------
            // Reset
            //--------------------------------

            handOpen.position = handStartPos;
            objectImage.position = objectStartPos;

            handOpen.gameObject.SetActive(true);
            handPinch.gameObject.SetActive(false);

            yield return new WaitForSeconds(0.5f);

            //--------------------------------
            // Hand menuju Object
            //--------------------------------

            while (Vector3.Distance(handOpen.position, objectImage.position) > 1f)
            {
                handOpen.position = Vector3.MoveTowards(
                    handOpen.position,
                    objectImage.position,
                    speed * Time.deltaTime);

                yield return null;
            }

            //--------------------------------
            // Ganti menjadi Pinch
            //--------------------------------

            handPinch.position = handOpen.position;

            handOpen.gameObject.SetActive(false);
            handPinch.gameObject.SetActive(true);

            yield return new WaitForSeconds(0.3f);

            //--------------------------------
            // Drag Object
            //--------------------------------

            while (Vector3.Distance(objectImage.position, dropArea.position) > 1f)
            {
                handPinch.position = Vector3.MoveTowards(
                    handPinch.position,
                    dropArea.position,
                    speed * Time.deltaTime);

                objectImage.position = handPinch.position;

                yield return null;
            }

            //--------------------------------
            // Lepas Object
            //--------------------------------

            handPinch.gameObject.SetActive(false);
            handOpen.position = handStartPos;
            handOpen.gameObject.SetActive(true);

            yield return new WaitForSeconds(1f);
        }
    }
}