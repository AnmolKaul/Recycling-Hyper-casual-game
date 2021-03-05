using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effects : MonoBehaviour
{
    public GameObject paperCrackersPrefab;
    public GameObject starsPrefab;
    public GameObject crumpledPaperPrefab;
    public static Effects instance;
    private void Start()
    {
        instance = this;
    }

    public void PlayEffect(int index, Vector3 pos)
    {
        switch (index)
        {
            case 1:
                Instantiate(crumpledPaperPrefab, pos, Quaternion.identity);
                break;
            case 2:
                Instantiate(starsPrefab, pos, Quaternion.identity);
                break;
            case 3:
                Instantiate(paperCrackersPrefab, pos, Quaternion.identity);
                break;
            default: break;
        }
    }
}
