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
//            // �ش� ��ų�� �������� �����Ͽ� �߻�
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
//                    Debug.LogError("��ų �������� �������� �ʾҽ��ϴ�.");
//                }
//            }
//            //������ ��
//        }
//    }
//}