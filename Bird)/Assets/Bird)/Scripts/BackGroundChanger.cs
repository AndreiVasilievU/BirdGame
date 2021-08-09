using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundChanger : MonoBehaviour
{
    [SerializeField]
    List<GameObject> backgrounds;

    private void Update()
    {
        if(GameInfo.Score > 4)
        {
            backgrounds[0].SetActive(false);
            backgrounds[1].SetActive(true);
        }
        if(GameInfo.Score > 9)
        {
            backgrounds[1].SetActive(false);
            backgrounds[2].SetActive(true);
        }
        if (GameInfo.Score > 14)
        {
            backgrounds[2].SetActive(false);
            backgrounds[3].SetActive(true);
        }
        if (GameInfo.Score > 19)
        {
            backgrounds[2].SetActive(false);
            backgrounds[3].SetActive(true);
        }
    }
}
