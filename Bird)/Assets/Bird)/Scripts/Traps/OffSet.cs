using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OffSet : MonoBehaviour
{
    public Vector3 offSet;
    Transform parentTr;
    Transform platformParentTr;

    private void Awake()
    {
        parentTr = GetComponentInParent<Transform>();
        platformParentTr = GetComponentInParent<Platform>().GetComponent<Transform>();
    }
    private void Start()
    {
        parentTr.transform.position = parentTr.transform.position + offSet;
    }
    private void Update()
    {
        parentTr.transform.position = new Vector3(parentTr.transform.position.x, platformParentTr.transform.position.y + offSet.y, parentTr.transform.position.z);
    }
}
