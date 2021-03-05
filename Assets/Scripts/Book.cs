using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Book : MonoBehaviour
{
    private GameManager gameManager;
    private PaperCollectedBar PaperCollectedBar;

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        PaperCollectedBar = FindObjectOfType<PaperCollectedBar>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Bin"))
        {
            // Play book dropped sound effect
            Sound.instance.BookDropped();
            // Generate crumpled paper particle effect
            Effects.instance.PlayEffect(1, transform.position);

            // Check if the bin is full or not
            if (gameManager.paperCount < gameManager.maxPaperCount)
            {
                // Book is in the bin so increment papercount
                gameManager.paperCount++;

                // Hide the book
                transform.gameObject.SetActive(false);
            }

            // Bin is full so move to the next part
            if (gameManager.paperCount >= gameManager.maxPaperCount)
            {
                gameManager.SlideAnim();
            }

        }
    }
}
