//using Oculus.Interaction.Editor.Generated;
//using System;
//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class EnemyManager : MonoBehaviour
//{
//    //���� ���� ��� �Լ�
//    //���Ͱ� ������ �޴� �Լ�
//    public void OnDamage(int _attackType, int _damage, Monster _target)
//    {
//        //if (_target.mon < _attackType)
//    }

//}

//public class Monster :MonoBehaviour
//{
//    public string monName;
//    public monType mon;
//    public enum monType
//    {
//        None, Fire, Ice, Lightening
//    }
//    public float monHP;
//    public float monMP; //**
//    public float monDamage;

//    public Monster(string _name, int _montype, float _hp, float _mp, float _damage)
//    {
//        monName = _name;
//        mon = (monType)_montype;
//        monHP = _hp;
//        monMP = _mp;
//        monDamage = _damage;
//    }
//}