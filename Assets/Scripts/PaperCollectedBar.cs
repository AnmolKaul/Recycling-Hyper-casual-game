using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PaperCollectedBar : MonoBehaviour
{
    public Image paperCollectedSlider;
    private GameManager gameManager;

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    private void Update()
    {
        paperCollectedSlider.fillAmount = gameManager.paperCount / gameManager.maxPaperCount;
    }
}
