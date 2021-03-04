using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class TutorialManager : MonoBehaviour
{
    public static TutorialManager instance;

    private void Start()
    {
        instance = this;
    }

    public void DisableHand(RectTransform hand)
    {
        hand.gameObject.SetActive(false);
    }
    public void EnableHand(RectTransform hand)
    {
        hand.gameObject.SetActive(true);
    }
    public void MoveHand(Vector2 pos, RectTransform hand)
    {
        hand.DOAnchorPos(pos, 2f);
    }
    public void ScaleHand(RectTransform hand)
    {
        hand.DOScale(hand.localScale / 2f, 1f);
    }

}
