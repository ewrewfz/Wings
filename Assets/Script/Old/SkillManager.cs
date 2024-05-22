using System.Collections.Generic;
using UnityEngine;
using Oculus.VR;
using Unity.VisualScripting;

namespace old
{

    //public class SkillManager : MonoBehaviour
    //{
    //    public List<SingleShotSkill> SetSkills = new List<SingleShotSkill>(); // 스킬을 저장할 리스트
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


    //    // 단발 스킬 에셋을 받아와서 랜덤 속성을 부여하고 SetSkills 리스트에 추가합니다.
    //    public void AddSkillFromAsset(SingleShotSkill skillAsset)
    //    {
    //        SingleShotSkill newSkill = Instantiate(skillAsset); // 에셋을 복제하여 새로운 스킬 생성
    //        newSkill.skillProperty = GetRandomProperty(); // 랜덤 속성 부여

    //        Debug.Log("새로운 단발 공격 스킬이 생성되었습니다 속성: " + newSkill.skillProperty);


    //        SetSkills.Insert(0, newSkill); // 리스트의 첫 번째 인덱스에 추가
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
    //            // SetSkills 리스트에 저장된 스킬이 있는지 확인
    //            if (SetSkills.Count > 0)
    //            {

    //                singleShotSkillAsset = SetSkills[0];


    //                singleShotSkillAsset.CastSkill(transform.position, Quaternion.identity);
    //            }

    //        }

    //    }

    //}
    //#region 속성 (안씀)
    ////public class Fire : MonoBehaviour
    ////{
    ////    //추가 틱뎀
    ////}
    ////public class Ice : MonoBehaviour
    ////{
    ////    //상대 움직임(쿨타임) 둔화
    ////}
    ////public class Lightening : MonoBehaviour
    ////{
    ////    // 자신 움직임(쿨타임) 가속
    ////}
    ////public class None : MonoBehaviour
    ////{
    ////    // 개 쎔
    ////}
    //#endregion
}