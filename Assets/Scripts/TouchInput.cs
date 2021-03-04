using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchInput : MonoBehaviour
{
    private float speed;
    private Vector3 deltaPosition, touchPos;
    public RectTransform hand1;
    public RectTransform hand2;

    private void Start()
    {
        speed = 0f;
        StartCoroutine(Tutorial());
    }

    IEnumerator Tutorial()
    {
        // Hand tutorial
        yield return new WaitForSeconds(1f);

        // First hand 
        TutorialManager.instance.EnableHand(hand1);
        TutorialManager.instance.MoveHand(new Vector2(-80f, -888f), hand1);
        TutorialManager.instance.ScaleHand(hand1);
        yield return new WaitForSeconds(2f);
        TutorialManager.instance.DisableHand(hand1);

        // Second hand
        TutorialManager.instance.EnableHand(hand2);
        TutorialManager.instance.MoveHand(new Vector2(-80f, -888f), hand2);
        TutorialManager.instance.ScaleHand(hand2);
        yield return new WaitForSeconds(2f);
        TutorialManager.instance.DisableHand(hand2);

        yield return new WaitForSeconds(0.5f);
        speed = 0.005f;
    }

    private void OnMouseDown()
    {
        touchPos = Input.mousePosition;
        transform.GetComponent<Rigidbody>().useGravity = false;
    }

    private void OnMouseDrag()
    {
        deltaPosition = touchPos - Input.mousePosition;
        deltaPosition *= -1;
        transform.position = new Vector3(transform.position.x + deltaPosition.x * speed, transform.position.y, transform.position.z + deltaPosition.y * speed);
        touchPos = Input.mousePosition;
    }

    private void OnMouseUp()
    {
        transform.GetComponent<Rigidbody>().useGravity = true;
        transform.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
    }
}
