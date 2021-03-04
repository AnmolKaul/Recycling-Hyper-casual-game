using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;
public class Menu : MonoBehaviour
{
    public Button play;
    public Button share;

    public void NextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Share()
    {
        Application.OpenURL("https://www.linkedin.com/in/anmolkaul/");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
