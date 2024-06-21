using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEngine.GraphicsBuffer;

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
        //player = GameObject.FindWithTag("Player").transform.gameObject;
        //characterColl = player.GetComponent<Collider>();
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
                ultimateSkill = ultimateSkillPrefab[0];
                Ac_ShowdownSkill += Showdown_Fire; break;
            case Property.Ice:
                ultimateSkill = ultimateSkillPrefab[1];
                Ac_ShowdownSkill += Showdown_Ice; break;
            case Property.Lightning:
                ultimateSkill = ultimateSkillPrefab[2];
                Ac_ShowdownSkill += Showdown_Ele; break;
            case Property.None:
                ultimateSkill = ultimateSkillPrefab[3];
                Ac_ShowdownSkill += Showdown_Wind; break;
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
    //private Collider characterColl;
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
    public float handDis = 0.002f;
    public void UseThreeGo()
    {
        if ((lefthandPos.transform.position - player.transform.position).magnitude < handDis)
        {
            return;
        }
        else if (skillLaunched == false && threeGo >= 1)
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
        print(player.transform.position);
        while (_t <= 0.1f)
        {
            //if ( 0f <= _t && _t <= 0.05f)
            //{
            //    characterColl.enabled = false;
            //}
            //characterColl.enabled = true;
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
                skillRigidbody.AddForce((hit.point - shotPos).normalized * skillForce, ForceMode.Impulse);
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
    #region Ű�ٿ�
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
        RaycastHit hit = crosshairray.hit;
        skillBox = Instantiate(SkillSet[1], righthandPos.transform.position, Quaternion.identity);
        while (_t < time_holding)
        {
            _t += Time.deltaTime;
            skillBox.transform.LookAt(hit.point);
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
        if (keydownCount == 2 && skillLaunched == false &&
            Vector3.Distance(righthandPos.transform.position, lefthandPos.transform.position) <= 1f)
        {
            skillLaunched = true;
            StartCoroutine(IceMake());
        }
    }
    private IEnumerator IceMake()
    {
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
    #endregion
    //================================
    #region ���ο�
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
            Vector3 targetPos = (hit.point - shotPos).normalized;

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

    #endregion
    //==================================
    #region ��
    private event Action Ac_ShowdownSkill;
    [SerializeField] private bool makeShowdownkill;
    [SerializeField] private int showtimeDelay = 3;
    [SerializeField] private float showdownForce = 10f;
    public ParticleSystem showdownAfterEffect;
    public void UseShowdownSkill()
    {
        Ac_ShowdownSkill();
    }
    public void PreShowdown()
    {
        if (skillLaunched == false && showdownCount == 2 &&
            (lefthandPos.transform.position - righthandPos.transform.position).magnitude >= 0.2f)
        {
            skillLaunched = true;
            skillBox = Instantiate(SkillSet[0], Vector3.Lerp(lefthandPos.transform.position, righthandPos.transform.position, 0.5f), Quaternion.identity);
            StartCoroutine(Showtime());
        }
    }
    private IEnumerator Showtime()
    {
        float _t = 0f;
        while (_t < showtimeDelay)
        {
            _t += Time.deltaTime;
            skillBox.transform.position = Vector3.Lerp(lefthandPos.transform.position, righthandPos.transform.position, 0.5f);
            skillBox.transform.localScale = Vector3.Lerp(Vector3.zero,Vector3.one * 0.3f, _t/ showtimeDelay);
            yield return null;
        }
        if ((lefthandPos.transform.position - righthandPos.transform.position).magnitude <= 0.6f)
        {
            makeShowdownkill = true;
            Destroy(skillBox);
            StartCoroutine(ShowtimeAfterEffect());
        }
    }
    private IEnumerator ShowtimeAfterEffect()
    {
        while (makeShowdownkill)
        {
            Destroy(Instantiate(showdownAfterEffect, lefthandPos.transform.position, Quaternion.identity),1);
            Destroy(Instantiate(showdownAfterEffect, righthandPos.transform.position, Quaternion.identity),1);
            yield return new WaitForSeconds(1);
        }
    }

    private void Showdown_Fire()
    {
        RaycastHit hit = crosshairray.hit;
        if (makeShowdownkill)
        {
            skillBox = Instantiate(SkillSet[3], player.transform.position + (Vector3.up * 10), Quaternion.identity);
            skillBox.GetComponent<Rigidbody>().AddForce((hit.point - skillBox.transform.position).normalized * showdownForce);
        }
        makeShowdownkill = false;
        skillLaunched = false;
    }
    private void Showdown_Ice()
    {
        if (makeShowdownkill)
        {
            skillBox = Instantiate(SkillSet[3], player.transform.position, Quaternion.identity);
        }
        makeShowdownkill = false;
        skillLaunched = false;
    }
    private void Showdown_Ele()
    {
        RaycastHit hit = crosshairray.hit;
        if (makeShowdownkill)
        {
            skillBox = Instantiate(SkillSet[3], Vector3.zero, Quaternion.identity);
            skillBox.transform.Rotate(-90, 0, -30);
            skillBox.transform.SetParent(player.transform, true);
            StartCoroutine(Showdown_EleEffect());
        }
        makeShowdownkill = false;
        skillLaunched = false;
    }
    private IEnumerator Showdown_EleEffect()
    {
        float _t = 0f;
        Vector3 _origin = skillBox.transform.position;
        while (_t < 0.1f)
        {
            _t += Time.deltaTime;
            skillBox.transform.localPosition = Vector3.Lerp(_origin, _origin + player.transform.right, _t / 0.1f);
            skillBox.transform.Rotate(Vector3.up, 60 * (_t / 0.1f));
            yield return null;
        }
    }
    private void Showdown_Wind()
    {
        RaycastHit hit = crosshairray.hit;
        if (makeShowdownkill)
        {
            skillBox = Instantiate(SkillSet[3], player.transform.position, Quaternion.identity);
            skillBox.GetComponent<Rigidbody>().AddForce((hit.point - skillBox.transform.position).normalized * showdownForce);
            StartCoroutine(Showdown_WindEffect(hit));
        }
        makeShowdownkill = false;
        skillLaunched = false;
    }
    private IEnumerator Showdown_WindEffect(RaycastHit _hit)
    {
        float _t = 0f;
        Vector3 _originVel = skillBox.GetComponent<Rigidbody>().velocity;
        while (_t < 10f)
        {
            _t += Time.deltaTime;
            Vector3 toTarget = (_hit.point - transform.position).normalized;
            skillBox.GetComponent<Rigidbody>().velocity = toTarget * _originVel.magnitude;
            yield return null;
        }
    }

    #endregion
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