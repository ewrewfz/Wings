using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowSkillEffect : MonoBehaviour
{
    public SkillsManager skillManager;
    public ParticleSystem[] particle = new ParticleSystem[2]; // 0���� ��������Ʈ, 1���� ������ ����Ʈ
    private void Start()
    {
        //intro ����Ʈ
        particle[0].Play();
    }
    private void OnCollisionEnter(Collision other)
    {
        print("���𰡿� ����");
        if (other.gameObject.CompareTag("wall"))
        {
            print("�ٴڿ� ����");
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
