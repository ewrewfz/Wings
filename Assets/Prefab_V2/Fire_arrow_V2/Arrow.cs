using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    [SerializeField] GameObject rotate;
    float x;
    int speed = 50;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        x += Time.deltaTime * speed * 2;
        rotate.transform.rotation = Quaternion.Euler(x, 180, -90);
    }
}
