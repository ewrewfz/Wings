using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowSkillEffect : MonoBehaviour
{
    public SkillsManager skillManager;
    public ParticleSystem[] particle = new ParticleSystem[2]; // 0번이 시작이펙트, 1번이 터질때 이펙트
    private void Start()
    {
        //intro 이펙트
        particle[0].Play();
    }
    private void OnCollisionEnter(Collision other)
    {
        print("무언가에 닿음");
        if (other.gameObject.CompareTag("wall"))
        {
            print("바닥에 닿음");
            particle[1].Play();
            StartCoroutine(WaitDestroy(particle[1]));
        }
    }

    private IEnumerator WaitDestroy(ParticleSystem _effect)
    {
        yield return new WaitForSeconds(_effect.time);
        Destroy(gameObject);
        skillManager.skillLaunched = false;
    }
}
