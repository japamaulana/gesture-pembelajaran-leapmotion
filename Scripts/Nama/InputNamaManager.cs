using UnityEngine;
using TMPro;

public class InputNamaManager : MonoBehaviour
{
    public TMP_InputField inputNama;
    public GameObject inputNamaPanel;
    public NamaSiswaUI namaSiswaUI;

    void Start()
{
    // Menghapus nama yang tersimpan sebelumnya
    PlayerPrefs.DeleteKey("NamaSiswa");

    // Mengosongkan input field
    inputNama.text = "";
}

    public void MulaiBelajar()
{
    if (string.IsNullOrWhiteSpace(inputNama.text))
    {
        Debug.Log("Nama masih kosong");
        return;
    }

    PlayerPrefs.SetString("NamaSiswa", inputNama.text);

    // Simpan nama ke ResultManager
    ResultManager.Instance.namaSiswa = inputNama.text;

    ResultManager.Instance.totalSoal = 6;

    // Update tulisan nama
    namaSiswaUI.UpdateNama();

    inputNamaPanel.SetActive(false);

    Debug.Log("Halo " + inputNama.text);
}   
}