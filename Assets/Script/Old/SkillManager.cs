using System.Collections.Generic;
using UnityEngine;
using Oculus.VR;
using Unity.VisualScripting;

namespace old
{

    //public class SkillManager : MonoBehaviour
    //{
    //    public List<SingleShotSkill> SetSkills = new List<SingleShotSkill>(); // ��ų�� ������ ����Ʈ
    //    public SingleShotSkill singleShotSkillAsset;
    //    public enum SkillProperty
    //    {
    //        Fire,
    //        ICE,
    //        LIGHTNING,
    //        None
    //    }

    //    //=============
    //    public delegate void ClickAction();
    //    public static event ClickAction OnClicked;
    //    public delegate void awef();
    //    public static event awef CastSkill0;
    //    public static event awef CastSkill1;
    //    public static event awef CastSkill2;
    //    public static event awef CastSkill3;
    //    public delegate void fewa();
    //    public static event fewa DamageCal;


    //    // �ܹ� ��ų ������ �޾ƿͼ� ���� �Ӽ��� �ο��ϰ� SetSkills ����Ʈ�� �߰��մϴ�.
    //    public void AddSkillFromAsset(SingleShotSkill skillAsset)
    //    {
    //        SingleShotSkill newSkill = Instantiate(skillAsset); // ������ �����Ͽ� ���ο� ��ų ����
    //        newSkill.skillProperty = GetRandomProperty(); // ���� �Ӽ� �ο�

    //        Debug.Log("���ο� �ܹ� ���� ��ų�� �����Ǿ����ϴ� �Ӽ�: " + newSkill.skillProperty);


    //        SetSkills.Insert(0, newSkill); // ����Ʈ�� ù ��° �ε����� �߰�
    //    }


    //    private SkillProperty GetRandomProperty()
    //    {
    //        return (SkillProperty)Random.Range(0, System.Enum.GetValues(typeof(SkillProperty)).Length);
    //    }


    //    private void Start()
    //    {
    //        //List<object> propertyList = new List<object>() { new Fire(), new Ice(), new Lightening(), new None() };

    //        AddSkillFromAsset(singleShotSkillAsset);
    //    }
    //    private void Update()
    //    {

    //        if (OVRInput.GetDown(OVRInput.Button.One))
    //        {
    //            // SetSkills ����Ʈ�� ����� ��ų�� �ִ��� Ȯ��
    //            if (SetSkills.Count > 0)
    //            {

    //                singleShotSkillAsset = SetSkills[0];


    //                singleShotSkillAsset.CastSkill(transform.position, Quaternion.identity);
    //            }

    //        }

    //    }

    //}
    //#region �Ӽ� (�Ⱦ�)
    ////public class Fire : MonoBehaviour
    ////{
    ////    //�߰� ƽ��
    ////}
    ////public class Ice : MonoBehaviour
    ////{
    ////    //��� ������(��Ÿ��) ��ȭ
    ////}
    ////public class Lightening : MonoBehaviour
    ////{
    ////    // �ڽ� ������(��Ÿ��) ����
    ////}
    ////public class None : MonoBehaviour
    ////{
    ////    // �� ��
    ////}
    //#endregion
}