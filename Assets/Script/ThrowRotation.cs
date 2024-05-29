using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowRotation : MonoBehaviour
{
    private Transform player;
    private Rigidbody rb;
    [SerializeField] private Collider handColl;

    private int throwforce;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        handColl = GameObject.FindWithTag("L_Hand").transform.gameObject.GetComponent<Collider>();
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other == handColl)
        {
            StartCoroutine(WaitGravity());
        }        
    }

    private IEnumerator WaitGravity()
    {
        yield return new WaitForSeconds(1f);
        rb.useGravity = true;
    }

}
