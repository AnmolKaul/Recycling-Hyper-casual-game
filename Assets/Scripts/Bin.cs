using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bin : MonoBehaviour
{
    public float rotateSpeed;
    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            transform.Rotate(new Vector3(0, 0, Input.GetAxis("Mouse X")) * Time.deltaTime * rotateSpeed);
        }

    }
}
