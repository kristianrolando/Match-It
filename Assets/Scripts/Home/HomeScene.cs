using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HomeScene : MonoBehaviour
{
    public void PlayButton()
    {
        SceneManager.LoadScene("Gameplay");
    }
    public void ThemeButton()
    {
        SceneManager.LoadScene("Theme");
    }
}
