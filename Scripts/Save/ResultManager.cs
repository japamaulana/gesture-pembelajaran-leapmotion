using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResultManager : MonoBehaviour
{
    public static ResultManager Instance;

    // ==========================
    // Data Umum
    // ==========================
    public string namaSiswa = "";

    public int totalSoal = 0;

    public int jawabanBenar = 0;

    public int jumlahKesalahan = 0;

    public string lastSavedPath = "";

    // ==========================
    // Data setiap Scene
    // ==========================
    [System.Serializable]
    public class GameResult
    {
        public string sceneName;
        public bool success;
        public int attempt;
    }

    public List<GameResult> results = new List<GameResult>();

    // ==========================
    // Singleton
    // ==========================
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // ==========================
    // Menambah Attempt
    // ==========================
    public void AddAttempt()
    {
        Debug.Log("AddAttempt DIPANGGIL");

        jumlahKesalahan++;

        string sceneName = SceneManager.GetActiveScene().name;

        GameResult data = results.Find(x => x.sceneName == sceneName);

        if (data == null)
        {
            data = new GameResult();

            data.sceneName = sceneName;

            data.success = false;

            data.attempt = 1;

            results.Add(data);
        }
        else
        {
            data.attempt++;
        }

        Debug.Log(sceneName + " Attempt : " + data.attempt);
    }

    // ==========================
    // Jawaban Berhasil
    // ==========================
    public void SetSuccess()
    {
        Debug.Log("SetSuccess DIPANGGIL");

        string sceneName = SceneManager.GetActiveScene().name;

        GameResult data = results.Find(x => x.sceneName == sceneName);

        if (data == null)
        {
            data = new GameResult();

            data.sceneName = sceneName;

            data.success = false;

            data.attempt = 1;

            results.Add(data);
        }

        // Supaya tidak dihitung dua kali
        if (!data.success)
        {
            data.success = true;

            jawabanBenar++;
        }

        Debug.Log(sceneName + " BERHASIL");
    }

    // ==========================
    // Data JSON
    // ==========================
    [System.Serializable]
    public class SaveData
    {
        public string namaSiswa;

        public string tanggal;

        public int totalSoal;

        public int jawabanBenar;

        public int jumlahKesalahan;

        public List<GameResult> hasil;
    }

    // ==========================
    // Simpan JSON
    // ==========================
    public void SaveToJson()
    {
        SaveData data = new SaveData();

        data.namaSiswa = namaSiswa;

        data.tanggal = System.DateTime.Now.ToString("dd-MM-yyyy");

        data.totalSoal = totalSoal;

        data.jawabanBenar = jawabanBenar;

        data.jumlahKesalahan = jumlahKesalahan;

        data.hasil = results;

        string json = JsonUtility.ToJson(data, true);

        string folder = Application.persistentDataPath + "/DataHasil";

        if (!System.IO.Directory.Exists(folder))
        {
            System.IO.Directory.CreateDirectory(folder);
        }

        string fileName =
            namaSiswa + "_" +
            System.DateTime.Now.ToString("yyyyMMdd_HHmmss") +
            ".json";

        string path = folder + "/" + fileName;

        lastSavedPath = path;

        System.IO.File.WriteAllText(path, json);

        Debug.Log("=================================");
        Debug.Log(json);
        Debug.Log("=================================");
        Debug.Log("Berhasil disimpan di : " + path);
    }

    // ==========================
    // Reset Data
    // ==========================
    public void ResetResult()
    {
        namaSiswa = "";

        totalSoal = 0;

        jawabanBenar = 0;

        jumlahKesalahan = 0;

        lastSavedPath = "";

        results.Clear();
    }
}