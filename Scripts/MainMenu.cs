using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void GoToScene(string sceneName)
    {
        // Jika menuju Scene Penilaian,
        // simpan hasil terlebih dahulu
        if (sceneName == "SPenilaian")
        {
            if (ResultManager.Instance != null)
            {
                ResultManager.Instance.SaveToJson();
            }
        }

        SceneManager.LoadScene(sceneName);
    }

    public void QuitApp()
    {
        Application.Quit();
        Debug.Log("Application has quit");
    }
}