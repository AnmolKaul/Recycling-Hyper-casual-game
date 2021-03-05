using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Binrotate : MonoBehaviour
{
    [SerializeField] private LayerMask targetLayer;
    [SerializeField] private float rotationRate = 3.0f;
    [SerializeField] private bool xRotation;
    [SerializeField] private bool yRotation;
    [SerializeField] private bool invertX;
    [SerializeField] private bool invertY;
    [SerializeField] private bool touchAnywhere;
    private bool canRotate = false;
    private float m_previousX;
    private float m_previousY;
    private Camera m_camera;
    private bool m_rotating = false;
    public RectTransform hand4;
    public RectTransform hand5;

    private void Awake()
    {
        m_camera = Camera.main;
    }

    private void Start()
    {
        StartCoroutine(Tutorial());
    }

    IEnumerator Tutorial()
    {
        yield return new WaitForSeconds(1);

        // Hand tutorial 
        TutorialManager.instance.EnableHand(hand4);
        TutorialManager.instance.MoveHand(new Vector2(20f, -600f), hand4);
        TutorialManager.instance.ScaleHand(hand4);
        yield return new WaitForSeconds(2f);
        TutorialManager.instance.DisableHand(hand4);

        TutorialManager.instance.EnableHand(hand5);
        TutorialManager.instance.MoveHand(new Vector2(20f, -600f), hand5);
        TutorialManager.instance.ScaleHand(hand5);
        yield return new WaitForSeconds(2f);
        TutorialManager.instance.DisableHand(hand5);
        yield return new WaitForSeconds(0.5f);
        canRotate = true;
    }

    private void Update()
    {
        if (!touchAnywhere)
        {
            //No need to check if already rotating
            if (!m_rotating)
            {
                RaycastHit hit;
                Ray ray = m_camera.ScreenPointToRay(Input.mousePosition);
                if (!Physics.Raycast(ray, out hit, 1000, targetLayer))
                {
                    return;
                }
            }
        }

        if (Input.GetMouseButtonDown(0) && canRotate)
        {
            m_rotating = true;
            m_previousX = Input.mousePosition.x;
            m_previousY = Input.mousePosition.y;
        }
        // get the user touch input
        if (Input.GetMouseButton(0) && canRotate)
        {
            var touch = Input.mousePosition;
            var deltaX = -(Input.mousePosition.y - m_previousY) * rotationRate;
            var deltaY = -(Input.mousePosition.x - m_previousX) * rotationRate;
            if (!yRotation) deltaX = 0;
            if (!xRotation) deltaY = 0;
            if (invertX) deltaY *= -1;
            if (invertY) deltaX *= -1;

            transform.Rotate(deltaX, deltaY, 0, Space.World);

            m_previousX = Input.mousePosition.x;
            m_previousY = Input.mousePosition.y;
        }
        if (Input.GetMouseButtonUp(0))
            m_rotating = false;
    }
}
