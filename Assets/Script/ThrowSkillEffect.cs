using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowSkillEffect : MonoBehaviour
{
    public GameObject prethrowskill;
    public GameObject throwskill;
    public GameObject circleskill;
    public GameObject explosion;
    private Rigidbody rb;

    private CrosshairRay crosshairray;

    private void Start()
    {
        crosshairray = GameObject.FindWithTag("crosshair").gameObject.GetComponent<CrosshairRay>();
        rb = GetComponent<Rigidbody>();
        prethrowskill.SetActive(true);
        throwskill.SetActive(false);
        circleskill.SetActive(false);
        explosion.SetActive(false);
    }

    private void TowardTarget()
    {
        RaycastHit hit = crosshairray.hit;
        Vector3 towardDirect = hit.point - transform.position;
        towardDirect.y = 0;
        rb.AddForce(towardDirect * 10f);
        StartCoroutine(ChangeEffect());
    }

    private void DownRay()
    {
        RaycastHit raycast;
        LayerMask layerMask = 1 << LayerMask.NameToLayer("Wall");
        Physics.Raycast(transform.position, -transform.up, out raycast, 5,layerMask);
        circleskill.transform.position = raycast.point;
        circleskill.SetActive(true);
    }

    private IEnumerator ChangeEffect()
    {
        yield return new WaitForSeconds(3f);
        DownRay();
        prethrowskill.SetActive(false);
        throwskill.SetActive(true);
        rb.velocity = Vector3.zero;
        yield return new WaitForSeconds(3f);
        OnExplosion();
    }
    public void TestCor()
    {
        StartCoroutine(ChangeEffect());
    }
    public void OnExplosion()
    {
        if (prethrowskill.activeInHierarchy == true)
        {
            return;
        }
        throwskill.SetActive(false);
        circleskill.SetActive(false);
        explosion.SetActive(true);
    }
}
