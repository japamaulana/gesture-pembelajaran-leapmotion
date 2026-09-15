using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropArea : MonoBehaviour
{
    public string correctObjectName;

    public PopupManager popupManager;

    private void OnTriggerStay(Collider other)
    {
        ShapeDrag drag = other.GetComponent<ShapeDrag>();

        if (drag == null)
            return;

        // masih dicubit
        if (drag.isDragging)
            return;

        // sudah pernah dicek
        if (drag.isChecked)
            return;

        // ==========================
        // BENAR
        // ==========================
        if (other.name == correctObjectName)
        {
            ResultManager.Instance.SetSuccess();

            drag.isChecked = true;

            drag.KeepPosition(transform.position);

            popupManager.ShowSuccessPopup();
        }

        // ==========================
        // SALAH
        // ==========================
        else
        {
            Debug.Log("SALAH");

            // tambah attempt
            ResultManager.Instance.AddAttempt();

            drag.isChecked = true;

            popupManager.ShowFailedPopup();

            drag.ResetPosition();
        }
    }
}