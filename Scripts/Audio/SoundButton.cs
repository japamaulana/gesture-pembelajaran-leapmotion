// using System.Collections;
// using System.Collections.Generic;
using UnityEngine;

public class SoundButton : MonoBehaviour
{
    public void ToggleMusic()
    {
        if (AudioManager.Instance != null)
        {
            AudioManager.Instance.ToggleMusic();
        }
    }
}
