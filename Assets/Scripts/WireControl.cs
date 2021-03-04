using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WireControl : MonoBehaviour
{
    private float mousePosX;
    public Collider wireCollider;
    public Animator recycleMachineAnimator;
    public Rigidbody[] papers;

    private void OnMouseDrag()
    {
        Ray ray;
        RaycastHit hitInfo;
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hitInfo))
        {
            if (hitInfo.transform.name == "Wire")
            {
                mousePosX = hitInfo.point.x;
            }
        }
        Vector3 pos = transform.position;
        pos.x = mousePosX;
        transform.position = pos;
    }

    IEnumerator RecyclingFinished()
    {
        wireCollider.enabled = false;
        recycleMachineAnimator.SetTrigger("On");

        yield return new WaitForSeconds(1f);

        // Enable recycled papers and throw them in the air
        foreach (var item in papers)
        {
            Physics.gravity = new Vector3(0, -9.81f, 0);
            item.AddForce(Vector3.up * 8f, ForceMode.Impulse);
            item.useGravity = true;
        }
        yield return new WaitForSeconds(1f);

        // Get coins
        CoinManager.instance.GetCoins();
        yield return new WaitForSeconds(0.55f);
        CoinManager.instance.SetCoinText(500);
        yield return new WaitForSeconds(3f);

        foreach (var item in papers)
        {
            item.gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Recycle")
        {
            StartCoroutine(RecyclingFinished());
        }
    }
}
