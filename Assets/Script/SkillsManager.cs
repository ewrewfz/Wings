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
    //크로스헤어 받아오기
    public CrosshairRay crosshairray;
    //hmd부모위치 받아오기(현재위치 계산용)
    [SerializeField] private Vector3 hmdParent;
    // 손이 얼마나 멀어져야 스킬 나갈거?
    public float distanceThreshold = 1.0f;
    // 스킬이 내 기준으로 어느정도 떨어져서 나갈거?
    public float skillSpawnDistance = 10.0f;
    // 스킬에 가해질 힘
    public float skillForce = 40.0f;
    // 스킬의 지속시간
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
        Debug.Log("스킬발사 중");

        // handPos의 로컬 forward 방향을 기준으로 발사 방향을 계산합니다.
        Vector3 localForward = righthandPos.transform.forward;

        // handPos의 로컬 forward 방향을 기준으로 발사 위치를 계산합니다.
        Vector3 localShootPosition = localForward * skillSpawnDistance;

        // localShootPosition을 world space로 변환하여 실제 발사 위치를 계산합니다.
        Vector3 shootPosition = righthandPos.transform.TransformPoint(localShootPosition);

        // 스킬 프리팹을 생성하고 지정된 위치에 생성합니다.
        skillBox = Instantiate(SkillSet[1], shootPosition, Quaternion.LookRotation(localForward));

        Rigidbody skillRigidbody = skillBox.GetComponent<Rigidbody>();
        if (skillRigidbody != null)
        {
            // Rigidbody가 있다면 지정된 방향으로 힘을 가합니다.
            skillRigidbody.AddForce(localForward * skillForce, ForceMode.Impulse);
        }

        skillLaunched = true;

        // 스킬 사용 시간이 지난 후 스킬을 파괴하는 코루틴을 시작합니다.
        //StartCoroutine(DestroySkillAfterDuration());
    }


    IEnumerator DestroySkillAfterDuration()
    {
        // 스킬 지속 시간만큼 대기
        yield return new WaitForSeconds(skillDuration);

        // 파괴
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
            Debug.Log("스킬발사 중");

            // handPos의 로컬 forward 방향을 기준으로 발사 방향을 계산합니다.
            //Vector3 localForward = righthandPos.transform.forward;

            // handPos의 로컬 forward 방향을 기준으로 발사 위치를 계산합니다.
            //Vector3 localShootPosition = localForward * skillSpawnDistance;

            // localShootPosition을 world space로 변환하여 실제 발사 위치를 계산합니다.
            //Vector3 shootPosition = righthandPos.transform.TransformPoint(localShootPosition);

            //스킬 나가는 위치 (오른손 끝)
            Vector3 shotPos = hmdParent + righthandPos.transform.position;

            // 스킬 프리팹을 생성하고 지정된 위치에 생성합니다. Quaternion.LookRotation(localForward)
            skillBox = Instantiate(SkillSet[0], shotPos, Quaternion.LookRotation(hit.point - shotPos));

            Rigidbody skillRigidbody = skillBox.GetComponent<Rigidbody>();
            if (skillRigidbody != null)
            {
                // Rigidbody가 있다면 지정된 방향으로 힘을 가합니다.
                skillRigidbody.AddForce((hit.point - shotPos) * skillForce, ForceMode.Impulse);
            }

            skillLaunched = true;
            StartCoroutine(DestroySkillAfterDuration());
        }
    }
    public void ThrowSkill()
    {
        //스킬나가는 조건에 양손 위치를 받아서 양손의 거리가 특정 거리가 되면 나가게하기
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