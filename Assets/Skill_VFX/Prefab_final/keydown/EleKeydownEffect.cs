using OVR.OpenVR;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EleKeydownEffect : MonoBehaviour
{
    public ParticleSystem eleBall;
    public int ballNum = 4;
    private float radius;
    public float rotateSpeed;
    private ParticleSystem[] eleBalls;
    public float diversionSpeed;
    private float _t = 0f;
    private void Start() // �ʱ���ġ�� ������ ���� ������ �������� ����
    {
        eleBalls = new ParticleSystem[ballNum];
        radius = GetComponent<SphereCollider>().radius;
        for (int i = 0; i < ballNum; i++)
        {
            float angle = i * (360f / ballNum);
            float angleRad = angle * Mathf.Deg2Rad;
            float x = Mathf.Cos(angleRad) * radius;
            float z = Mathf.Sin(angleRad) * radius;

            Vector3 objPos = new Vector3(x, 1f, z);
            eleBalls[i] = Instantiate(eleBall, objPos, Quaternion.identity);
            eleBalls[i].transform.SetParent(gameObject.transform, false); //true�� �ϸ� ������ ���� true�� �ϰ� instantiate ��ġ�� �Ű��൵ ��
            eleBalls[i].gameObject.SetActive(true);
        }
    }

    private void Update() // ���ư�, �ּ�ó���� ���ư��鼭 ������ �𿴴���
    {
        _t += Time.deltaTime;
        for (int i = 0; i < ballNum; i++)
        {
            eleBalls[i].transform.RotateAround(transform.position, Vector3.up, rotateSpeed * Time.deltaTime);
            eleBalls[i].transform.LookAt(transform.position);
            eleBalls[i].transform.Rotate(0, 180, 0);
            eleBalls[i].transform.Translate(Vector3.forward * Mathf.Sin(diversionSpeed * _t) * 0.02f);
        }
    }
}
