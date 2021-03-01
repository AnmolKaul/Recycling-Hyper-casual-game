using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [HideInInspector] public float paperCount = 0;
    public float maxPaperCount;
    [HideInInspector] public float inkLevel = 0f;
    public float maxInkLevel;
    public float slideAnimWaitTime = 1f;
    public GameObject paperCollectLevel;
    public GameObject inkFillLevel;
    public GameObject inkFillSlider;
    public GameObject bin;
    public Canvas stage1Canvas;
    public Canvas stage2Canvas;
    public RectTransform transitionImage1;
    public RectTransform transitionImage2;
    public Image transitionImage;
    public Camera cam;
    public Vector3 newCamPosition;
    public Vector3 newCamRotation;
    public InkMachineTouchInput inkMachineTouchInput;
    public InkedBooks inkedBooks;
    private void Start()
    {
        paperCollectLevel.SetActive(true);
        stage1Canvas.gameObject.SetActive(true);
        stage2Canvas.gameObject.SetActive(false);
    }

    public void SlideAnim()
    {
        StartCoroutine(SlideAnimation());
    }

    public void TankFilled()
    {
        StartCoroutine(InkTankFilled());
    }

    public void BooksDropped()
    {
        StartCoroutine(BooksDroppedInTank());
    }

    IEnumerator SlideAnimation()
    {
        // Wait
        yield return new WaitForSeconds(0.5f);

        // Slide In effect
        transitionImage1.DOAnchorPos(Vector2.zero, 0.5f);

        // Wait
        yield return new WaitForSeconds(slideAnimWaitTime);

        // Move and rotate camera to new position
        cam.transform.DOMove(newCamPosition, 0.05f);
        cam.transform.DORotate(newCamRotation, 0.05f);

        // Enable next level
        paperCollectLevel.SetActive(false);
        inkFillLevel.SetActive(true);

        // Enable next level canvas
        stage1Canvas.gameObject.SetActive(false);
        stage2Canvas.gameObject.SetActive(true);

        // Enable transition image and slide it out
        transitionImage.gameObject.SetActive(true);
        transitionImage2.DOAnchorPos(new Vector2(-1100, 0), 0.5f);
    }

    IEnumerator InkTankFilled()
    {
        inkMachineTouchInput.enabled = false;

        // Wait
        yield return new WaitForSeconds(0.5f);

        // Slide In effect
        transitionImage2.DOAnchorPos(Vector2.zero, 0.5f);

        // Wait
        yield return new WaitForSeconds(slideAnimWaitTime);

        // Slide In effect
        transitionImage2.DOAnchorPos(new Vector2(-1100, 0), 0.5f);

        inkFillSlider.SetActive(false);
        bin.SetActive(true);
    }

    IEnumerator BooksDroppedInTank()
    {
        inkedBooks.enabled = false;

        // Wait
        yield return new WaitForSeconds(0.5f);

        // Slide In effect
        transitionImage2.DOAnchorPos(Vector2.zero, 0.5f);

        // Wait
        yield return new WaitForSeconds(slideAnimWaitTime);

        // Slide In effect
        transitionImage2.DOAnchorPos(new Vector2(-1100, 0), 0.5f);

        inkFillLevel.SetActive(false);
    }
}
