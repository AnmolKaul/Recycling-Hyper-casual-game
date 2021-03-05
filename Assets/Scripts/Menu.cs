using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;
public class Menu : MonoBehaviour
{
    public RectTransform playButton;
    public RectTransform shareButton;
    public RectTransform quitButton;
    public RectTransform gameTitle;
    public Button play;
    public Button share;
    private bool playPressed = false;

    private void OnEnable()
    {
        MenuAnims();
    }

    public void NextScene()
    {
        playPressed = true;
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

    void MenuAnims()
    {
        gameTitle.DOAnchorPos(new Vector2(0, -350f), 1f);
        playButton.DOAnchorPos(Vector2.zero, 1f);
        quitButton.DOAnchorPos(new Vector2(50f, 50f), 1f);
        shareButton.DOAnchorPos(new Vector2(-50f, 50f), 1f);
    }
}
