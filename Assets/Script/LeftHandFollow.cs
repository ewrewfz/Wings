using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftHandFollow : MonoBehaviour
{
    private GameObject lefthandPos;
    private void Start()
    {
        lefthandPos = GameObject.FindWithTag("L_Hand").transform.gameObject;
        transform.SetParent(lefthandPos.transform);
    }
}
