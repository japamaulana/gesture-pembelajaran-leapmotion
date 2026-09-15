using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FinishManager : MonoBehaviour
{
    [Header("Text")]
    public TMP_Text namaText;
    public TMP_Text nilaiText;
    public TMP_Text pointText;
    public TMP_Text wrongText;
    public TMP_Text pesanText;

    [Header("Stars")]
    public Image star1;
    public Image star2;
    public Image star3;

    void Start()
    {
        if (ResultManager.Instance == null)
        {
            Debug.LogError("ResultManager tidak ditemukan!");
            return;
        }

        Debug.Log("Nama : " + ResultManager.Instance.namaSiswa);
        Debug.Log("Benar : " + ResultManager.Instance.jawabanBenar);
        Debug.Log("Total : " + ResultManager.Instance.totalSoal);
        Debug.Log("Salah : " + ResultManager.Instance.jumlahKesalahan);

        TampilkanHasil();
    }

    void TampilkanHasil()
    {
        ResultManager rm = ResultManager.Instance;

        // =========================
        // DATA SISWA
        // =========================
        namaText.text = rm.namaSiswa;

        // =========================
        // JUMLAH BENAR
        // =========================
        pointText.text =
            rm.jawabanBenar + " / " + rm.totalSoal;

        // =========================
        // JUMLAH KESALAHAN
        // =========================
        wrongText.text =
            rm.jumlahKesalahan + " kali";

        // =========================
        // HITUNG NILAI
        // =========================
        int nilai = 100 - (rm.jumlahKesalahan * 5);

        // Nilai tidak boleh kurang dari 0
        if (nilai < 0)
        {
            nilai = 0;
        }

        // Tampilkan nilai
        nilaiText.text = nilai.ToString();

        Debug.Log("Nilai Akhir : " + nilai);

        // =========================
        // RESET BINTANG
        // =========================
        star1.enabled = false;
        star2.enabled = false;
        star3.enabled = false;

        // =========================
        // PENILAIAN & PESAN
        // =========================

        if (nilai >= 90)
        {
            pesanText.text =
                "Hebat!\nKamu berhasil menyelesaikan semua latihan dengan sangat baik.";

            star1.enabled = true;
            star2.enabled = true;
            star3.enabled = true;
        }
        else if (nilai >= 70)
        {
            pesanText.text =
                "Bagus!\nKamu berhasil menyelesaikan latihan.\nTerus semangat belajar!";

            star1.enabled = true;
            star2.enabled = true;
        }
        else if (nilai >= 50)
        {
            pesanText.text =
                "Lumayan!\nKamu sudah berhasil menyelesaikan latihan.\nTetap semangat belajar!";

            star1.enabled = true;
        }
        else
        {
            pesanText.text =
                "Tetap semangat!\nKamu sudah menyelesaikan latihan.\nYuk belajar dan coba lagi!";

            star1.enabled = true;
        }
    }

    // =========================================
    // TOMBOL ULANGI
    // Kembali ke latihan awal
    // =========================================
    public void Repeat()
    {
        ResultManager.Instance.ResetResult();

        SceneManager.LoadScene("Persegi");
    }

    // =========================================
    // TOMBOL NEXT
    // Kembali ke Menu Utama
    // =========================================
    public void KembaliMenu()
    {
        ResultManager.Instance.ResetResult();

        SceneManager.LoadScene("SampleScene");
    }
}