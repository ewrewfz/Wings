using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class misile : MonoBehaviour
{
    [SerializeField] GameObject rotate;
    float x;
    int speed = 20;

    void Start()
    {

    }

    void Update()
    {
        x += Time.deltaTime * speed * 2;
        rotate.transform.rotation = Quaternion.Euler(x, -180,0 );
    }
}
