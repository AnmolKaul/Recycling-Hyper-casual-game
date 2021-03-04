using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class InkMachineTouchInput : MonoBehaviour
{
    public Image inkFillSlider;
    private GameManager gameManager;
    public Transform inkBox;
    public float inkHeightIncrement;
    public bool canFill = false;

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    private void Update()
    {
        if (Input.GetMouseButton(0) && canFill)
        {
            if (gameManager.inkLevel >= gameManager.maxInkLevel)
            {
                // Ink filled so move to the next part
                gameManager.TankFilled();
            }
            if (gameManager.inkLevel < gameManager.maxInkLevel)
            {
                gameManager.inkLevel += 0.1f;
                TapToFillInk();

                // Raise the ink level with each tap
                inkBox.DOMoveY(inkBox.transform.position.y + inkHeightIncrement, 0.5f, snapping: false);
            }
        }
    }

    void TapToFillInk()
    {
        inkFillSlider.fillAmount = gameManager.inkLevel / gameManager.maxInkLevel;
    }
}
