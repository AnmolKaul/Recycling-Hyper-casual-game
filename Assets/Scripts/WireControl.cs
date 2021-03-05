using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WireControl : MonoBehaviour
{
    private float mousePosX;
    public Collider wireCollider;
    public Animator recycleMachineAnimator;
    public Rigidbody[] papers;
    public GameObject sparks;
    private float m_previousX;
    private float m_previousY;
    public GameObject levelCompletePanel;

    private void OnEnable()
    {
        Sound.instance.BoilingWater(0);
    }
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
        sparks.SetActive(false);
        wireCollider.enabled = false;
        recycleMachineAnimator.SetTrigger("On");

        // Play the washing machine dryer sound effect
        Sound.instance.Dryer(1);

        yield return new WaitForSeconds(1f);

        // Enable recycled papers and throw them in the air
        foreach (var item in papers)
        {
            Physics.gravity = new Vector3(0, -9.81f, 0);
            item.AddForce(Vector3.up * 8f, ForceMode.Impulse);
            item.useGravity = true;
        }
        yield return new WaitForSeconds(1f);
        foreach (var item in papers)
        {
            item.gameObject.SetActive(false);
        }

        // Paper cracker particles
        Effects.instance.PlayEffect(2, new Vector3(-0.1f, 2f, -3.73f));
        Effects.instance.PlayEffect(3, new Vector3(-0.1f, 2f, -3.73f));

        // Get coins
        CoinManager.instance.GetCoins();
        Sound.instance.CoinSound();
        yield return new WaitForSeconds(0.55f);
        CoinManager.instance.SetCoinText(500);

        levelCompletePanel.SetActive(true);
        yield return new WaitForSeconds(3f);
        Sound.instance.Dryer(0);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Recycle")
        {
            StartCoroutine(RecyclingFinished());
        }
    }
}
