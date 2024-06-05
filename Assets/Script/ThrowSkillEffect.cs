using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowSkillEffect : MonoBehaviour
{
    public GameObject prethrowskill;
    public GameObject throwskill;
    private Rigidbody rb;

    private CrosshairRay crosshairray;

    private void Start()
    {
        crosshairray = GameObject.FindWithTag("crosshair").gameObject.GetComponent<CrosshairRay>();
        rb = GetComponent<Rigidbody>();
        prethrowskill.SetActive(true);
        throwskill.SetActive(false);
    }

    public void TowardTarget()
    {
        RaycastHit hit = crosshairray.hit;
        Vector3 towardDirect = hit.point - transform.position;
        towardDirect.y = 0;
        rb.AddForce(towardDirect * 10f);
        StartCoroutine(ChangeEffect());
    }
    private IEnumerator ChangeEffect()
    {
        yield return new WaitForSeconds(3f);
        prethrowskill.SetActive(false);
        throwskill.SetActive(true);
        rb.velocity = Vector3.zero;
    }
}
