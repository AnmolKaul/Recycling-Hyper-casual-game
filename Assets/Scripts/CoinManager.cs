using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;

public class CoinManager : MonoBehaviour
{
    public static CoinManager instance;
    public RectTransform[] coin;
    public int gameCoins = 120;
    private float coinAnimSpeed;
    public TextMeshProUGUI coinText;
    public Vector2[] defaultPositions;

    private void Start()
    {
        instance = this;
        SetCoinText(gameCoins);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SetDefaultCoinPos();
        }
    }
    public void SetCoinText(int coins)
    {
        gameCoins += coins;
        coinText.text = gameCoins.ToString();
    }

    public void GetCoins()
    {
        StartCoroutine(GainCoinsAnim());
    }

    public void SetDefaultCoinPos()
    {
        for (int i = 0; i < coin.Length; i++)
        {
            coin[i].gameObject.SetActive(false);
            coin[i].anchoredPosition = new Vector2(defaultPositions[i].x, defaultPositions[i].y);
        }
    }

    IEnumerator GainCoinsAnim()
    {
        foreach (var item in coin)
        {
            item.gameObject.SetActive(true);
            coinAnimSpeed = Random.Range(0.5f, 1f);
            item.DOAnchorPos(new Vector2(442f, 1122f), coinAnimSpeed);
        }
        yield return new WaitForSeconds(2f);
        SetDefaultCoinPos();
    }
}
