using UnityEngine;
using TMPro;

public class NamaSiswaUI : MonoBehaviour
{
    public TMP_Text namaText;

    void Start()
    {
        UpdateNama();
    }

    public void UpdateNama()
    {
        string nama = PlayerPrefs.GetString("NamaSiswa", "");

        if (string.IsNullOrEmpty(nama))
        {
            namaText.text = "";
        }
        else
        {
            namaText.text = "Halo, " + nama;
        }
    }
}