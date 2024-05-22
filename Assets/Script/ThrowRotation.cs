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
        throwforce = 4;
        rb = GetComponent<Rigidbody>();
        player = GameObject.FindWithTag("Player").transform;
        handColl = GameObject.FindWithTag("R_handColl").GetComponent<Collider>();
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other == handColl)
        {
            StartCoroutine(WaitGravity());
        }        
    }
    private void OnTriggerExit(Collider other)
    {
        if (other == handColl)
        {
            rb.AddForce(player.forward * throwforce + player.up * (throwforce / 2));
        }
    }

    private IEnumerator WaitGravity()
    {
        yield return new WaitForSeconds(0.3f);
        rb.useGravity = true;
    }

}
