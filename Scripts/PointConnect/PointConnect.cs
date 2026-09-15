using UnityEngine;

public class PointConnect : MonoBehaviour
{
    [Header("Finger")]
    public Transform fingerTip;

    [Header("Points")]
    public Transform point1;
    public Transform point2;
    public Transform point3;
    public Transform point4;

    [Header("Reference")]
    public DrawSquare drawSquare;
    public PopupManager popupManager;

    [Header("Setting")]
    public float touchDistance = 0.03f;

    private Transform[] points;

    // Urutan yang benar : 1 -> 2 -> 3 -> 4 -> 1
    private int[] sequence = { 0, 1, 2, 3, 0 };

    private int currentStep = 0;
    private bool canTouch = true;

    void Start()
    {
        points = new Transform[]
        {
            point1,
            point2,
            point3,
            point4
        };
    }

    void Update()
    {
        if (fingerTip == null)
            return;

        int touchedPoint = GetTouchedPoint();

        // Belum menyentuh titik mana pun
        if (touchedPoint == -1)
        {
            canTouch = true;
            return;
        }

        // Mencegah satu titik terbaca berkali-kali
        if (!canTouch)
            return;

        canTouch = false;

        // ==========================
        // JAWABAN BENAR
        // ==========================
        if (touchedPoint == sequence[currentStep])
        {
            drawSquare.AddPoint(points[touchedPoint].position);

            Debug.Log("Point " + (touchedPoint + 1) + " berhasil");

            currentStep++;

            // Semua titik selesai
            if (currentStep >= sequence.Length)
            {
                ResultManager.Instance.SetSuccess();
                popupManager.ShowSuccessPopup();
            }

            return;
        }

        // ==========================
        // JAWABAN SALAH
        // ==========================
        Debug.Log("SALAH");

        ResultManager.Instance.AddAttempt();

        popupManager.ShowFailedPopup();

        drawSquare.ResetLine();

        ResetGame();
    }

    // ==========================
    // Mencari titik yang disentuh
    // ==========================
    int GetTouchedPoint()
    {
        for (int i = 0; i < points.Length; i++)
        {
            float distance = Vector3.Distance(
                fingerTip.position,
                points[i].position);

            if (distance <= touchDistance)
            {
                return i;
            }
        }

        return -1;
    }

    // ==========================
    // Reset permainan
    // ==========================
    public void ResetGame()
    {
        currentStep = 0;
        canTouch = false;

        drawSquare.ResetLine();
    }
}