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
        Wind
    }

    public enum Type
    {
        Single,
        KeyDown,
        Throw,
        Showdown
    }

    public GameObject[] singleSkillPrefab;
    public GameObject[] keydownSkillPrefab;
    public GameObject[] throwSkillPrefab;
    public GameObject[] ultimateSkillPrefab;

    public List<GameObject> SkillSet = new List<GameObject>();
    public SkillUI skillUI;
    public Dictionary<int, Skills> skillDic = new Dictionary<int, Skills>();

    Skills awef;
    private void Awake()
    {
        SkillSet.Add(SingleSkill(RandomProperty()));
        SkillSet.Add(KeydownSkill(RandomProperty()));
        SkillSet.Add(ThrowSkill(RandomProperty()));
        SkillSet.Add(UltimateSkill(RandomProperty()));

        //righthandPos = GameObject.FindWithTag("R_Hand").transform.gameObject;
        //lefthandPos = GameObject.FindWithTag("L_Hand").transform.gameObject;
        //player = GameObject.FindWithTag("Player").transform.gameObject;
        //characterColl = player.GetComponent<Collider>();

      //skillDic.Add(0, new Skills("FireSingle", Prefab, Damage,ManaCost,CoolTime, Property, Type, SkillSpecialEffect));
        skillDic.Add(1, new Skills("FireSingle", singleSkillPrefab[0], 4,5,5,Property.Fire, Type.Single, new SkillSpecialEffect.FireEffect(1.0f, 1f)));
        skillDic.Add(2, new Skills("IceSingle", singleSkillPrefab[1], 5, 5, 5, Property.Ice, Type.Single, new SkillSpecialEffect.IceEffect(1.0f, 3f)));
        skillDic.Add(3, new Skills("LighteningSingle", singleSkillPrefab[2], 5, 5, 5, Property.Lightning, Type.Single, new SkillSpecialEffect.LightningEffect(1.0f, 3f)));
        skillDic.Add(4, new Skills("WindSingle", singleSkillPrefab[3], 4, 5, 5, Property.Wind, Type.Single, new SkillSpecialEffect.WindEffect(1.0f, 3f)));

        skillDic.TryGetValue(1, out awef);
        awef.damage *= 1.2f;
        awef.specialEffect.ChangeValue(3, 7);


        
    }
    bool _a = true; //�ڷ�ƾ�� ��� �Ǵ°� �������� ����, update�� �ֱ⶧����
    private void Update()
    {
        if (threeGo < 3 && _a)
        {
            _a = false;
            StartCoroutine(ChargeDash());
        }

        awef = skillDic[1];
        print(awef.damage);
    }

    private GameObject SingleSkill(Property property)
    {
        GameObject singleSkill = null;
        switch (property)
        {
            case Property.Fire:
                singleSkill = singleSkillPrefab[0];
                skillUI.set_skills[0].sprite = skillUI.all_skills[0];
                break;
            case Property.Ice:
                singleSkill = singleSkillPrefab[1];
                skillUI.set_skills[0].sprite = skillUI.all_skills[1];
                break;
            case Property.Lightning:
                singleSkill = singleSkillPrefab[2];
                skillUI.set_skills[0].sprite = skillUI.all_skills[2];
                break;
            case Property.Wind:
                singleSkill = singleSkillPrefab[3];
                skillUI.set_skills[0].sprite = skillUI.all_skills[3];
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
                skillUI.set_skills[1].sprite = skillUI.all_skills[4];
                break;
            case Property.Ice:
                keydownSkill = keydownSkillPrefab[1];
                Ac_KeydownSkill += Keydown_Ice;
                skillUI.set_skills[1].sprite = skillUI.all_skills[5];
                break;
            case Property.Lightning:
                keydownSkill = keydownSkillPrefab[2];
                Ac_KeydownSkill += Keydown_Ele;
                skillUI.set_skills[1].sprite = skillUI.all_skills[6];
                break;
            case Property.Wind:
                keydownSkill = keydownSkillPrefab[3];
                Ac_KeydownSkill += Keydown_Wind;
                skillUI.set_skills[1].sprite = skillUI.all_skills[7];
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
                throwSkill = throwSkillPrefab[0];
                skillUI.set_skills[2].sprite = skillUI.all_skills[8];
                break;
            case Property.Ice:
                throwSkill = throwSkillPrefab[1];
                skillUI.set_skills[2].sprite = skillUI.all_skills[9];
                break;
            case Property.Lightning:
                throwSkill = throwSkillPrefab[2];
                skillUI.set_skills[2].sprite = skillUI.all_skills[10];
                break;
            case Property.Wind:
                throwSkill = throwSkillPrefab[3];
                skillUI.set_skills[2].sprite = skillUI.all_skills[11];
                break;
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
                Ac_ShowdownSkill += Showdown_Wind;
                skillUI.set_skills[3].sprite = skillUI.all_skills[12];
                break;
            case Property.Ice:
                ultimateSkill = ultimateSkillPrefab[1];
                Ac_ShowdownSkill += Showdown_Wind;
                skillUI.set_skills[3].sprite = skillUI.all_skills[13]  ;
                break;
            case Property.Lightning:
                ultimateSkill = ultimateSkillPrefab[2];
                Ac_ShowdownSkill += Showdown_Wind;
                skillUI.set_skills[3].sprite = skillUI.all_skills[14];
                break;
            case Property.Wind:
                ultimateSkill = ultimateSkillPrefab[3];
                Ac_ShowdownSkill += Showdown_Wind;
                skillUI.set_skills[3].sprite = skillUI.all_skills[15];
                break;
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
    //====================================
    public Transform[] rightFingerTr = new Transform[3]; //0 is palm center, 1 is indexFinger tip, 2 is middleFinger pad
    public Transform[] leftFingerTr = new Transform[3];
    //=========== GoStop=================
    #region Dash

    public Player player;
    private Transform handPos;
    private Vector3 targetPos;
    [SerializeField] private int ThreeGo = 3;
    [SerializeField] private int dashDistance = 6;
    [SerializeField] private int chargeTime = 3;
    //private Collider characterColl;
    public int threeGo
    {
        get { return ThreeGo; }
        set 
        { 
            if (value > 3)
            {
                ThreeGo = 3;
            }
            else if (value <= 0)
            {
                ThreeGo = 0;
            }
            else
            {
                ThreeGo = value; 
            }
        }
    }
    public float handDisDash = 0.02f;
    public void UseThreeGo()
    {
        if ((leftFingerTr[0].position - player.transform.position).magnitude < handDisDash)
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

    private IEnumerator ChargeDash()
    {
        if (threeGo < 3)
        {
            yield return new WaitForSeconds(chargeTime);
            threeGo++;
        }
        _a = true;
    }


    #endregion
    //===================================
    #region �̱�
    public void SingleSkill() //RPC
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

            // ��ų �������� �����ϰ� ������ ��ġ�� �����մϴ�. Quaternion.LookRotation(localForward)
            skillBox = Instantiate(SkillSet[0], rightFingerTr[0].position, Quaternion.LookRotation(hit.point - rightFingerTr[1].position));//����� ȣ��Ʈ ->Ŭ��


            Rigidbody skillRigidbody = skillBox.GetComponent<Rigidbody>();
            if (skillRigidbody != null)
            {
                // Rigidbody�� �ִٸ� ������ �������� ���� ���մϴ�.
                skillRigidbody.AddForce((hit.point - rightFingerTr[1].position).normalized * skillForce, ForceMode.Impulse); //����� ȣ��Ʈ ->Ŭ��
            }

            skillLaunched = true; //����� ȣ��Ʈ -> Ŭ��?
            StartCoroutine(DestroySkillAfterDuration()); //����� ȣ��Ʈ -> Ŭ��
        }
    }
    public void RESingleSkill(Property property) //�ʱ�ȭ��
    {
        SkillSet[0] = SingleSkill(property);
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
    #endregion
    //================================
    #region Ű�ٿ�
    //Ű�ٿ��� �̺�Ʈ �׼����� ó��
    private event Action Ac_KeydownSkill;
    public void UseKeydownSkill()
    {
        Ac_KeydownSkill();
    }
    public void REKeydown(Property property) // �ʱ�ȭ��
    {
        Ac_KeydownSkill = delegate { };
        SkillSet[1] = KeydownSkill(property);
    }

    [SerializeField] private float time_holding = 5f; //������
    [SerializeField] private float time_step = 0.2f; //���̽��� ��������
    private void Keydown_Fire()
    {
        if (keydownCount == 2 && skillLaunched == false &&
            Vector3.Distance(rightFingerTr[2].position, leftFingerTr[2].position) <= 0.1f)
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
        skillBox = Instantiate(SkillSet[1], rightFingerTr[2].position, Quaternion.LookRotation(rightFingerTr[1].right));
        skillBox.transform.SetParent(rightFingerTr[2]);
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
        if (keydownCount == 2 && skillLaunched == false &&
            Vector3.Distance(rightFingerTr[2].position, leftFingerTr[2].position) <= 0.1f)
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
            Vector3.Distance(rightFingerTr[2].position, leftFingerTr[2].position) <= 0.1f)
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
            Vector3.Distance(rightFingerTr[2].position, leftFingerTr[2].position) <= 0.1f)
        {
            skillLaunched = true;
            StartCoroutine(WindMake());
        }
    }
    private IEnumerator WindMake()
    {
        float _t = 0;
        print("�ٶ�2");
        skillBox = Instantiate(SkillSet[1], rightFingerTr[2].position, Quaternion.LookRotation(rightFingerTr[1].right));
        skillBox.transform.SetParent(rightFingerTr[2]);
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
    [SerializeField] private float throwForce = 80.0f;

    public void REThrow(Property property) // �ʱ�ȭ��
    {
        SkillSet[2] = ThrowSkill(property);
    }

    public void PreThrowSkill()
    {
        //������ �� ���� �յ��� ��ų
        bool cool = true;
        bool righttransform = true;
        if (cool && righttransform && skillLaunched == false)
        {
            skillBox = Instantiate(SkillSet[2], Vector3.Lerp(rightFingerTr[1].position, rightFingerTr[2].position, 0.5f), Quaternion.identity);
            skillBox.transform.SetParent(rightFingerTr[1]);
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
            Vector3 shotPos = Vector3.Lerp(rightFingerTr[1].position, rightFingerTr[2].position, 0.5f);
            skillBox.transform.SetParent(null);
            Rigidbody rb = skillBox.gameObject.GetComponent<Rigidbody>();
            Vector3 targetPos = (hit.point - shotPos).normalized;

            targetPos.y = 0;
            skillBox.transform.rotation = Quaternion.identity;
            rb.AddForce(targetPos * throwForce);
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
    [SerializeField] private float preshowDis = 0.2f;
    [SerializeField] private float showDis = 0.2f;
    public ParticleSystem showdownAfterEffect;
    public void UseShowdownSkill()
    {
        Ac_ShowdownSkill();
    }
    public void REShowdown(Property property) // �ʱ�ȭ��
    {
        Ac_ShowdownSkill = delegate { };
        SkillSet[3] = UltimateSkill(property);
    }
    public void PreShowdown()
    {
        if (skillLaunched == false && showdownCount == 2 &&
            (leftFingerTr[0].position - rightFingerTr[0].position).magnitude >= preshowDis)
        {
            skillLaunched = true;
            skillBox = Instantiate(SkillSet[0], Vector3.Lerp(leftFingerTr[0].position, rightFingerTr[0].position, 0.5f), Quaternion.identity);
            StartCoroutine(Showtime());
        }
    }
    private IEnumerator Showtime()
    {
        float _t = 0f;
        while (_t < showtimeDelay)
        {
            _t += Time.deltaTime;
            skillBox.transform.position = Vector3.Lerp(leftFingerTr[0].position, rightFingerTr[0].position, 0.5f);
            skillBox.transform.localScale = Vector3.Lerp(Vector3.zero,Vector3.one * 0.3f, _t/ showtimeDelay);
            yield return null;
        }
        if ((leftFingerTr[0].position - rightFingerTr[0].position).magnitude <= showDis)
        {
            makeShowdownkill = true;
            Destroy(skillBox);
            StartCoroutine(ShowtimeAfterEffect());
        }
        else
        {
            Destroy(skillBox);
            skillLaunched = false;
        }
    }
    private IEnumerator ShowtimeAfterEffect()
    {
        GameObject _box1, _box2;
        while (makeShowdownkill)
        {
            _box1 = Instantiate(showdownAfterEffect, leftFingerTr[0].position, Quaternion.identity, leftFingerTr[0]).gameObject;
            _box2 = Instantiate(showdownAfterEffect, rightFingerTr[0].position, Quaternion.identity, rightFingerTr[0]).gameObject;
            yield return new WaitForSeconds(1);
            Destroy(_box1);
            Destroy(_box2);
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
            skillBox = Instantiate(SkillSet[3], rightFingerTr[0].position, Quaternion.identity);
            skillBox.transform.rotation = Quaternion.Euler(-90, 0, -45);
            StartCoroutine(Showdown_EleEffect());
        }
        makeShowdownkill = false;
        skillLaunched = false;
    }
    private IEnumerator Showdown_EleEffect()
    {
        float _t = 0f;
        Vector3 _origin = skillBox.transform.position;
        while (_t < 2f)
        {
            _t += Time.deltaTime;
            skillBox.transform.position = Vector3.Lerp(_origin - player.transform.right, _origin + player.transform.right, _t / 2f);
            skillBox.transform.rotation = Quaternion.Euler(-90, 0, -45 + 90 * (_t / 2f));
            yield return null;
        }
    }
    private void Showdown_Wind()
    {
        if (makeShowdownkill)
        {
            skillBox = Instantiate(SkillSet[3], Vector3.Lerp(leftFingerTr[0].position, rightFingerTr[0].position,0.5f) + player.transform.forward, Quaternion.identity);
            StartCoroutine(Showdown_WindEffect());
        }
        makeShowdownkill = false;
        skillLaunched = false;
    }
    private IEnumerator Showdown_WindEffect()
    {
        RaycastHit hit = crosshairray.hit;
        float _t = 0f;
        while (_t < 10f)
        {
            _t += Time.deltaTime;
            Vector3 toTarget = (hit.point - transform.position).normalized; // ���濡 �ø��� ũ�ν��� �ƴ϶� ��뿡�Է� �ٲپ����
            skillBox.GetComponent<Rigidbody>().velocity = toTarget * showdownForce/2;
            yield return null;
        }
    }

    #endregion
    //=================================

    public void DestroySkill()
    {
        Destroy(skillBox);
        skillLaunched = false;
    }

    IEnumerator DestroySkillAfterDuration()
    {
        // ��ų ���� �ð���ŭ ���
        yield return new WaitForSeconds(skillDuration);

        // �ı�
        skillLaunched = false;
        Destroy(skillBox);
    }
    #region ī��Ʈ

    [SerializeField] private int showdownCount = 0;
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