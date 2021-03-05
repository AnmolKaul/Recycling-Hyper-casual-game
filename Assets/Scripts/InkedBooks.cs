using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InkedBooks : MonoBehaviour
{
    private int deInkedBookCount = 0;
    private GameManager gameManager;
    public RectTransform hand3;
    public Material darkInk;
    public MeshRenderer meshRenderer;
    private InkMachineTouchInput touchInput;

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        touchInput = FindObjectOfType<InkMachineTouchInput>();
        StartCoroutine(Tutorial());
    }
    IEnumerator Tutorial()
    {
        yield return new WaitForSeconds(1f);

        // Hand tutorial 
        TutorialManager.instance.EnableHand(hand3);
        TutorialManager.instance.MoveHand(new Vector2(20f, -440f), hand3);
        TutorialManager.instance.ScaleHand(hand3);
        yield return new WaitForSeconds(2f);
        TutorialManager.instance.DisableHand(hand3);
        yield return new WaitForSeconds(0.5f);
        touchInput.canFill = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Books"))
        {
            other.gameObject.SetActive(false);
            if (deInkedBookCount >= 4)
            {
                // Change the colour of ink to dark
                meshRenderer.material = darkInk;

                // Move to next part of the game
                gameManager.BooksDropped();
            }
            else
            {
                gameManager.booksDroppedInTankCount++;
                deInkedBookCount++;
            }
        }
    }
}
