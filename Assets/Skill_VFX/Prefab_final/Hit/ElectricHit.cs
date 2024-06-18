using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class ElectricHit : MonoBehaviour
{

    public ParticleSystem electronicParticle;
    public VisualEffect electronicVFX;

    private void Start()
    {
        electronicVFX.Play();
        StartCoroutine(effectPlay());
    }
    private IEnumerator effectPlay()
    {
        yield return new WaitForSeconds(0.35f);
        electronicVFX.Stop();
        electronicParticle.Play();
    }

}
