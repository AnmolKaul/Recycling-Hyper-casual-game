using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchInput : MonoBehaviour
{
    [SerializeField] bool canTouch = true;
    public bool SetTouch { get { return canTouch; } set { canTouch = value; } }
    private float speed;
    private Vector3 deltaPosition, touchPos;
    GameManager gameManager;

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        speed = 0.003f;
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
