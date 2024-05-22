using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillsManager : MonoBehaviour
{
    public enum Property
    {
        Fire,
        Ice,
        Lightning,
        None
    }
    public GameObject[] singleSkillPrefab;
    public GameObject[] keydownSkillPrefab;
    public GameObject[] throwSkillPrefab;
    public GameObject[] ultimateSkillPrefab;

    public List<GameObject> SkillSet = new List<GameObject>();


    private void Awake()
    {
        SkillSet.Add(SingleSkill(RandomProperty()));
        SkillSet.Add(KeydownSkill(RandomProperty()));
        SkillSet.Add(ThrowSkill(RandomProperty()));
        SkillSet.Add(UltimateSkill(RandomProperty()));

        righthandPos = GameObject.FindWithTag("R_Hand").transform.gameObject;
        lefthandPos = GameObject.FindWithTag("L_Hand").transform.gameObject;
    }

    private GameObject SingleSkill(Property property)
    {
        GameObject singleSkill = null;
        switch (property)
        {
            case Property.Fire:
                singleSkill = singleSkillPrefab[0];
                break;
            case Property.Ice:

                singleSkill = singleSkillPrefab[1];
                break;
            case Property.Lightning:

                singleSkill = singleSkillPrefab[2];
                break;
            case Property.None:

                singleSkill = singleSkillPrefab[3];
                break;
        }
        return singleSkill;
    }

    private GameObject KeydownSkill(Property property)
    {
        GameObject keydownSkill = null;
        switch (property)
        {
            case Property.Fire:
                keydownSkill = keydownSkillPrefab[0];
                break;
            case Property.Ice:
                keydownSkill = keydownSkillPrefab[1];
                break;
            case Property.Lightning:
                keydownSkill = keydownSkillPrefab[2];
                break;
            case Property.None:
                keydownSkill = keydownSkillPrefab[3];
                break;
        }
        return keydownSkill;
    }

    private GameObject ThrowSkill(Property property)
    {
        GameObject throwSkill = null;
        switch (property)
        {
            case Property.Fire:
                throwSkill = throwSkillPrefab[0]; break;
            case Property.Ice:
                throwSkill = throwSkillPrefab[1]; break;
            case Property.Lightning:
                throwSkill = throwSkillPrefab[2]; break;
            case Property.None:
                throwSkill = throwSkillPrefab[3]; break;
        }
        return throwSkill;
    }

    private GameObject UltimateSkill(Property property)
    {
        GameObject ultimateSkill = null;
        switch (property)
        {
            case Property.Fire:
                ultimateSkill = ultimateSkillPrefab[0]; break;
            case Property.Ice:
                ultimateSkill = ultimateSkillPrefab[1]; break;
            case Property.Lightning:
                ultimateSkill = ultimateSkillPrefab[2]; break;
            case Property.None:
                ultimateSkill = ultimateSkillPrefab[3]; break;
        }
        return ultimateSkill;
    }



    private Property RandomProperty()
    {
        return (Property)UnityEngine.Random.Range(0, Enum.GetValues(typeof(Property)).Length);
    }

    //========================================================================
    public bool skillLaunched = false;
    private GameObject skillBox;
    private GameObject righthandPos;
    private GameObject lefthandPos;
    //ũ�ν���� �޾ƿ���
    public CrosshairRay crosshairray;
    //hmd�θ���ġ �޾ƿ���(������ġ ����)
    [SerializeField] private Vector3 hmdParent;
    // ���� �󸶳� �־����� ��ų ������?
    public float distanceThreshold = 1.0f;
    // ��ų�� �� �������� ������� �������� ������?
    public float skillSpawnDistance = 10.0f;
    // ��ų�� ������ ��
    public float skillForce = 40.0f;
    // ��ų�� ���ӽð�
    [HideInInspector] public float skillDuration = 2f;
    private void Update()
    {
        if (showdownCount >= 1 && skillLaunched == false)
        {
            ShowdownSkill();
        }
        if (keydownCount >= 1 && skillLaunched == false)
        {
            KeydownSkill();
        }
    }
    void LaunchSkill(Vector3 spawnPos)
    {
        Debug.Log("��ų�߻� ��");

        // handPos�� ���� forward ������ �������� �߻� ������ ����մϴ�.
        Vector3 localForward = righthandPos.transform.forward;

        // handPos�� ���� forward ������ �������� �߻� ��ġ�� ����մϴ�.
        Vector3 localShootPosition = localForward * skillSpawnDistance;

        // localShootPosition�� world space�� ��ȯ�Ͽ� ���� �߻� ��ġ�� ����մϴ�.
        Vector3 shootPosition = righthandPos.transform.TransformPoint(localShootPosition);

        // ��ų �������� �����ϰ� ������ ��ġ�� �����մϴ�.
        skillBox = Instantiate(SkillSet[1], shootPosition, Quaternion.LookRotation(localForward));

        Rigidbody skillRigidbody = skillBox.GetComponent<Rigidbody>();
        if (skillRigidbody != null)
        {
            // Rigidbody�� �ִٸ� ������ �������� ���� ���մϴ�.
            skillRigidbody.AddForce(localForward * skillForce, ForceMode.Impulse);
        }

        skillLaunched = true;

        // ��ų ��� �ð��� ���� �� ��ų�� �ı��ϴ� �ڷ�ƾ�� �����մϴ�.
        //StartCoroutine(DestroySkillAfterDuration());
    }


    IEnumerator DestroySkillAfterDuration()
    {
        // ��ų ���� �ð���ŭ ���
        yield return new WaitForSeconds(skillDuration);

        // �ı�
        skillLaunched = false;
        Destroy(skillBox);
    }
    public void SingleSkill()
    {
        bool cool = true;
        bool righttransform = true;
        RaycastHit hit = crosshairray.hit;
        if (cool && righttransform && skillLaunched == false)
        {
            Debug.Log("��ų�߻� ��");

            // handPos�� ���� forward ������ �������� �߻� ������ ����մϴ�.
            //Vector3 localForward = righthandPos.transform.forward;

            // handPos�� ���� forward ������ �������� �߻� ��ġ�� ����մϴ�.
            //Vector3 localShootPosition = localForward * skillSpawnDistance;

            // localShootPosition�� world space�� ��ȯ�Ͽ� ���� �߻� ��ġ�� ����մϴ�.
            //Vector3 shootPosition = righthandPos.transform.TransformPoint(localShootPosition);

            //��ų ������ ��ġ (������ ��)
            Vector3 shotPos = hmdParent + righthandPos.transform.position;

            // ��ų �������� �����ϰ� ������ ��ġ�� �����մϴ�. Quaternion.LookRotation(localForward)
            skillBox = Instantiate(SkillSet[0], shotPos, Quaternion.LookRotation(hit.point - shotPos));

            Rigidbody skillRigidbody = skillBox.GetComponent<Rigidbody>();
            if (skillRigidbody != null)
            {
                // Rigidbody�� �ִٸ� ������ �������� ���� ���մϴ�.
                skillRigidbody.AddForce((hit.point - shotPos) * skillForce, ForceMode.Impulse);
            }

            skillLaunched = true;
            StartCoroutine(DestroySkillAfterDuration());
        }
    }
    public void ThrowSkill()
    {
        //��ų������ ���ǿ� ��� ��ġ�� �޾Ƽ� ����� �Ÿ��� Ư�� �Ÿ��� �Ǹ� �������ϱ�
        bool cool = true;
        bool righttransform = true;
        if (cool && righttransform && skillLaunched == false)
        {
            skillBox = Instantiate(SkillSet[2], righthandPos.transform.position, Quaternion.identity);
            skillLaunched = true;
        }
    }
    public void KeydownSkill()
    {
        if (keydownCount == 2 && Vector3.Distance(righthandPos.transform.position, lefthandPos.transform.position) <= 0.014f)
        {
            skillBox = Instantiate(SkillSet[1], righthandPos.transform.position, Quaternion.identity);
            skillBox.transform.SetParent(righthandPos.transform);
            skillLaunched = true;
        }
    }
    private void ShowdownSkill()
    {
        if (showdownCount == 2)
        {
            skillBox = Instantiate(SkillSet[3], righthandPos.transform.position, Quaternion.identity);
            skillLaunched = true;
        }
    }


    public void DestroySkill()
    {
        Destroy(skillBox);
        skillLaunched = false;
    }

    private int showdownCount = 0;
    public void ShowdownCountUp()
    {
        showdownCount++;
    }
    public void ShowdownCountDown()
    {
        showdownCount--;
    }
    private int keydownCount = 0;
    public void KeydownCountUp()
    {
        keydownCount++;
    }
    public void KeydownCountDown()
    {
        keydownCount--;
    }
}