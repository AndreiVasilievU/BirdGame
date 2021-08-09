using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyWarning : MonoBehaviour
{
    private void Update()
    {
        Invoke("DestroyGameObject", 0.5f);
    }
    void DestroyGameObject()
    {
        Destroy(gameObject);
    }
}
