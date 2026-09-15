// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class DropChecker : MonoBehaviour
// {
//     [Header("Target")]
//     public Transform dropBox;

//     [Header("Setting")]
//     public float snapDistance = 0.2f;

//     public void CheckDrop(ShapeDrag drag)
//     {
//         float distance =
//             Vector3.Distance(
//                 drag.transform.position,
//                 dropBox.position);

//         if(distance <= snapDistance)
//         {
//             drag.transform.position = dropBox.position;
//             drag.KeepPosition();

//             Debug.Log("MASUK BOX");
//         }
//         else
//         {
//             drag.ResetPosition();

//             Debug.Log("KEMBALI");
//         }
//     }
// }