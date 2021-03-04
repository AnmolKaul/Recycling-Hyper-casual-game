using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BooksDroppedBar : MonoBehaviour
{
    public Image booksDroppedSlider;
    private int maxBooks = 4;
    private GameManager gameManager;

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    private void Update()
    {
        booksDroppedSlider.fillAmount = gameManager.booksDroppedInTankCount / maxBooks;
    }
}
