using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

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

    private GameObject KeydownSkill(Property property) // ��ų��ġ�� �ް� keydown �� �Ҵ�
    {
        GameObject keydownSkill = null;
        switch (property)
        {
            case Property.Fire:
                keydownSkill = keydownSkillPrefab[0];
                Ac_KeydownSkill += Keydown_Fire;
                break;
            case Property.Ice:
                keydownSkill = keydownSkillPrefab[1];
                Ac_KeydownSkill += Keydown_Ice;
                break;
            case Property.Lightning:
                keydownSkill = keydownSkillPrefab[2];
                Ac_KeydownSkill += Keydown_Ele;
                break;
            case Property.None:
                keydownSkill = keydownSkillPrefab[3];
                Ac_KeydownSkill += Keydown_Wind;
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
    public bool PreSkillLaunched = false;

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
        //if (keydownCount >= 1 && skillLaunched == false)
        //{
        //    //KeydownSkill();
        //}
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
    //=========== GoStop=================
    #region Dash

    public Player player;
    private Transform handPos;
    private Vector3 targetPos;
    [SerializeField] private int ThreeGo = 3;
    [SerializeField] private int dashDistance = 6;
    public int threeGo
    {
        get { return ThreeGo; }
        set 
        { 
            if (ThreeGo > 3)
            {
                ThreeGo = 3;
            }
            else if (ThreeGo <= 0)
            {
                ThreeGo = 0;
            }
            ThreeGo = value; 
        }
    }
    public float handDis = 0.02f;
    public void UseThreeGo()
    {
        if ((lefthandPos.transform.position - player.transform.position).magnitude < handDis)
        {
            return;
        }
        if (skillLaunched == false && threeGo >= 1)
        {
            skillLaunched = true;
            targetPos = player.transform.position;
            threeGo--;
            GetTargetPos();
            StartCoroutine(GoDash());
        }
    }

   
    public void GetTargetPos()
    {
        RaycastHit hit = crosshairray.hit;
        Vector3 _temphit = new Vector3(hit.point.x, 0, hit.point.z);
        Vector3 _tempplayer = new Vector3(player.transform.position.x, 0, player.transform.position.z);

        if (dashDistance > (_temphit - _tempplayer).magnitude)
        {
            targetPos = _temphit - _tempplayer;
        }
        else
        {
            Vector3 _tempVec3 = (_temphit - _tempplayer).normalized * dashDistance;
            targetPos = _tempVec3;
        }
    }
    public IEnumerator GoDash()
    {
        float _t = 0f;
        Vector3 _origin = player.transform.position;
        while (_t <= 0.1f)
        {
            _t += Time.deltaTime;
            player.transform.position = new Vector3(_origin.x + targetPos.x * (_t / 0.1f), player.transform.position.y, _origin.z + targetPos.z * (_t / 0.1f));
            yield return null;
        }
        player.transform.position = new Vector3(_origin.x + targetPos.x, player.transform.position.y, _origin.z + targetPos.z);
        skillLaunched = false;
    }




    #endregion
    //===================================


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

    //public void KeydownSkill()
    //{
    //    if (keydownCount == 2 && Vector3.Distance(righthandPos.transform.position, lefthandPos.transform.position) <= 0.014f)
    //    {
    //        skillBox = Instantiate(SkillSet[1], righthandPos.transform.position, Quaternion.identity);
    //        skillBox.transform.SetParent(righthandPos.transform);
    //        skillLaunched = true;
    //    }
    //}

    //================================

    //Ű�ٿ��� �̺�Ʈ �׼����� ó��
    private event Action Ac_KeydownSkill;
    public void UseKeydownSkill()
    {
        Ac_KeydownSkill();
    }

    [SerializeField] private float time_holding = 5f; //������
    [SerializeField] private float time_step = 0.2f; //���̽��� ��������
    private void Keydown_Fire()
    {
        print("��");
        if (keydownCount == 2 && skillLaunched == false &&
            Vector3.Distance(righthandPos.transform.position, lefthandPos.transform.position) <= 1f)
        {
            skillLaunched = true;
            StartCoroutine(FireMake());
        }        
    }
    private IEnumerator FireMake()
    {
        //if (isKeydownSkill != null) yield break; //�絿���ϴ°� ����(��ų��ġ�� �̹� ��������)
        float _t = 0;
        print("��2");
        skillBox = Instantiate(SkillSet[1], righthandPos.transform.position, Quaternion.identity);
        skillBox.transform.SetParent(righthandPos.transform);
        while (_t < time_holding)
        {
            _t += Time.deltaTime;
            yield return null;
            if (keydownCount < 2)
            {
                skillLaunched = false;
                Destroy(skillBox);
                yield break; //���� Ǯ���� �ڷ�ƾ Ż��
            }
        }
        skillLaunched = false;
        Destroy(skillBox);
    }
    private void Keydown_Ice() //������ �ڷ�ƾ���� ������ hit.point�� ����
    {
        print("����");
        if (keydownCount == 2 && skillLaunched == false &&
            Vector3.Distance(righthandPos.transform.position, lefthandPos.transform.position) <= 1f)
        {
            skillLaunched = true;
            StartCoroutine(IceMake());
        }
    }
    private IEnumerator IceMake()
    {
        print("����2");
        //if (isKeydownSkill != null) yield break;
        float _t = 0;
        while (_t < time_holding) //5�ʰ� ����
        {
            RaycastHit hit = crosshairray.hit;
            _t += Time.deltaTime;
            skillBox = Instantiate(SkillSet[1], hit.point, Quaternion.identity);
            Destroy(skillBox, 1f);
            yield return new WaitForSeconds(time_step);
            if (keydownCount < 2)
            {
                skillLaunched = false;
                Destroy(skillBox);
                yield break; //���� Ǯ���� �ڷ�ƾ Ż��
            }
        }
        skillLaunched = false;
        Destroy(skillBox);
    }
    private void Keydown_Ele()
    {
        print("����");
        if (keydownCount == 2 && skillLaunched == false &&
            Vector3.Distance(righthandPos.transform.position, lefthandPos.transform.position) <= 1f)
        {
            skillLaunched = true;
            StartCoroutine(EleMake());
        }
    }
    private IEnumerator EleMake()
    {
        float _t = 0;
        print("����3");
        skillBox = Instantiate(SkillSet[1], player.transform.position, Quaternion.identity);
        skillBox.transform.SetParent(player.transform);
        while (_t < time_holding) //5�ʰ� ����
        {
            _t += Time.deltaTime;
            
            yield return null;
            if (keydownCount < 2)
            {
                skillLaunched = false;
                Destroy(skillBox);
                yield break; //���� Ǯ���� �ڷ�ƾ Ż��
            }
        }
        skillLaunched = false;
        Destroy(skillBox);
    }
    private void Keydown_Wind()
    {
        print("�ٶ�");
        if (keydownCount == 2 && skillLaunched == false &&
            Vector3.Distance(righthandPos.transform.position, lefthandPos.transform.position) <= 1f)
        {
            skillLaunched = true;
            StartCoroutine(WindMake());
        }
    }
    private IEnumerator WindMake()
    {
        float _t = 0;
        print("�ٶ�2");
        skillBox = Instantiate(SkillSet[1], righthandPos.transform.position, Quaternion.identity);
        skillBox.transform.SetParent(righthandPos.transform);
        while (_t < time_holding) //5�ʰ� ����
        {
            _t += Time.deltaTime;
            yield return null;
            if (keydownCount < 2)
            {
                skillLaunched = false;
                Destroy(skillBox);
                yield break; //���� Ǯ���� �ڷ�ƾ Ż��
            }
        }
        skillLaunched = false;
        Destroy(skillBox);
    }
    //================================
    public void PreThrowSkill()
    {
        //������ �� ���� �յ��� ��ų
        bool cool = true;
        bool righttransform = true;
        if (cool && righttransform && skillLaunched == false)
        {
            Debug.Log("�����յ��� ����");
            skillBox = Instantiate(SkillSet[2], righthandPos.transform.position + (righthandPos.transform.right * -0.03f) + (righthandPos.transform.forward * -0.1f), Quaternion.identity);
            skillBox.transform.SetParent(righthandPos.transform);
            skillLaunched = true;
            PreSkillLaunched = true;
        }
    }
    public void ThrowSkill()
    {
        //��ų������ ���ǿ� ��� ��ġ�� �޾Ƽ� ����� �Ÿ��� Ư�� �Ÿ��� �Ǹ� �������ϱ�
        bool cool = true;
        bool righttransform = true;
        RaycastHit hit = crosshairray.hit;
        if (cool && righttransform && PreSkillLaunched == true)
        {
            Vector3 shotPos = righthandPos.transform.position + (righthandPos.transform.right * -0.03f) + (righthandPos.transform.forward * -0.1f);
            skillBox.transform.SetParent(null);
            Rigidbody rb = skillBox.gameObject.GetComponent<Rigidbody>();
            Vector3 targetPos = (hit.point - shotPos);

            targetPos.y = 0;
            skillBox.transform.rotation = Quaternion.identity;
            rb.AddForce(targetPos * skillForce);
            skillLaunched = true;
            PreSkillLaunched = false;
            ChangeEffect();
        }
    }

    public void ThrowExplosion()
    {
        if (skillBox.GetComponent<ThrowSkillEffect>() == null)
        {
            return;
        }
        skillBox.GetComponent<ThrowSkillEffect>().OnExplosion();
        skillLaunched = false;
        Destroy(skillBox, 1.5f);
    }
    //================
    private void ChangeEffect()
    {
        ThrowSkillEffect _throwskill = skillBox.GetComponent<ThrowSkillEffect>();
        _throwskill.TestCor();
    }
    //===============
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
    #region ī��Ʈ

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
    #endregion
}