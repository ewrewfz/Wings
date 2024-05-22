//using System;
//using UnityEngine;

//namespace old
//{

//    public enum SkillProperty
//    {
//        Fire,
//        ICE,
//        LIGHTNING,
//        None
//    }
//    [CreateAssetMenu(fileName = "NewSkill", menuName = "Skills/SingleShotSkill ")]
//    public class SingleShotSkill : ScriptableObject
//    {
//        public string skillName;
//        public int damage;
//        public float cooldown;
//        public float Mana;

//        public GameObject[] skillPrefabsByProperty;

//        [HideInInspector] public SkillProperty skillProperty;

//        private void OnEnable()
//        {
//            //SkillManager.CastSkill0 += CastSkill;
//            //SkillManager.DamageCal0 += damageCal;

//        }

//        public void CastSkill(Vector3 position, Quaternion rotation)
//        {
//            // 해당 스킬의 프리팹을 생성하여 발사
//            if (skillPrefabsByProperty != null && skillPrefabsByProperty.Length > 0)
//            {
//                GameObject skillPrefab = skillPrefabsByProperty[(int)skillProperty];
//                if (skillPrefab != null)
//                {
//                    GameObject skillInstance = Instantiate(skillPrefab, position, rotation);
//                    Destroy(skillInstance, 2f);
//                }
//                else
//                {
//                    Debug.LogError("스킬 프리팹이 설정되지 않았습니다.");
//                }
//            }
//            //데미지 식
//        }
//    }
//}