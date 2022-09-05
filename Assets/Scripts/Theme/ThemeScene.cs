using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;


public class ThemeScene : MonoBehaviour
{
    public TextMeshProUGUI coinText;

    private void Start()
    {
        coinText.text = PlayerPrefs.GetInt("coin").ToString();
    }
    public void BackButton()
    {
        SceneManager.LoadScene("Home");
    }
}
