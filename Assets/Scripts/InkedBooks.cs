using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InkedBooks : MonoBehaviour
{
    private int deInkedBookCount = 0;
    private GameManager gameManager;

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Books"))
        {
            if (deInkedBookCount >= 3)
            {
                // Move to next part of the game
                gameManager.BooksDropped();
            }
            else
            {
                other.gameObject.SetActive(false);
                deInkedBookCount++;
            }
        }
    }
}
