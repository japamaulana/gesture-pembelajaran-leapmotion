using UnityEngine;

public class PopupManager : MonoBehaviour
{
    [Header("Popup")]
    public GameObject popupSuccess;
    public GameObject popupFailed;

    [Header("Gameplay Object")]
    public GameObject pointManager;
    public GameObject dragObject;

    [Header("Line")]
    public LineRenderer lineRenderer;

    [Header("Reference")]
    public DrawSquare drawSquare;
    public PointConnect pointConnect;

    void Start()
    {
        popupSuccess.SetActive(false);
        popupFailed.SetActive(false);
    }

    //==================================
    // POPUP BERHASIL
    //==================================

    public void ShowSuccessPopup()
    {
        AudioManager.Instance.PlaySuccess();

        popupSuccess.transform.SetAsLastSibling();
        popupSuccess.SetActive(true);

        if (lineRenderer != null)
            lineRenderer.enabled = false;

        if (pointManager != null)
            pointManager.SetActive(false);

        if (dragObject != null)
            dragObject.SetActive(false);
    }

    public void HideSuccessPopup()
    {
        popupSuccess.SetActive(false);

        if (lineRenderer != null)
            lineRenderer.enabled = true;

        if (pointManager != null)
            pointManager.SetActive(true);

        if (dragObject != null)
            dragObject.SetActive(true);
    }

    //==================================
    // POPUP SALAH
    //==================================

    public void ShowFailedPopup()
    {
        AudioManager.Instance.PlayFailed();
        
        popupFailed.transform.SetAsLastSibling();
        popupFailed.SetActive(true);

        if (lineRenderer != null)
            lineRenderer.enabled = false;

        if (pointManager != null)
            pointManager.SetActive(false);

        if (dragObject != null)
            dragObject.SetActive(false);
    }

    public void HideFailedPopup()
    {
        popupFailed.SetActive(false);

        if (lineRenderer != null)
            lineRenderer.enabled = true;

        if (pointManager != null)
            pointManager.SetActive(true);

        if (dragObject != null)
            dragObject.SetActive(true);
    }

    //==================================
    // COBA LAGI
    //==================================

    public void Retry()
    {
        popupSuccess.SetActive(false);
        popupFailed.SetActive(false);

        if (lineRenderer != null)
            lineRenderer.enabled = true;

        if (pointManager != null)
            pointManager.SetActive(true);

        if (dragObject != null)
            dragObject.SetActive(true);

        if (drawSquare != null)
            drawSquare.ResetLine();

        if (pointConnect != null)
            pointConnect.ResetGame();
    }

    //==================================
    // TUTUP POPUP
    //==================================

    public void CloseAllPopup()
    {
        popupSuccess.SetActive(false);
        popupFailed.SetActive(false);

        if (lineRenderer != null)
            lineRenderer.enabled = true;

        if (pointManager != null)
            pointManager.SetActive(true);

        if (dragObject != null)
            dragObject.SetActive(true);
    }
}