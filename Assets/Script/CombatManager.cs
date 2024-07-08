using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CombatManager : MonoBehaviour
{
    public List<Character> characterList;
    public CombatState state;
    public bool[] playerReady;
    private float readyTime = 60f; //ù �غ���� �ð�, ��æƮ�ϰ� ���� ��Ʋ���� ��ٷ��ִ� �ð�
    private float battleTime = 120f; // ��Ʋ�ð�
    public bool isBattle;
    public bool isFinish;
    public enum CombatState
    {
        Ready,
        Battle,
        Enchant,
        Finish
    }

    private void Start()
    {
        state = CombatState.Ready;
        characterList.AddRange(FindObjectsOfType<Character>());
        //ȣ��Ʈ�� Ŭ���̾�Ʈ�� ã�� ��ȣ �� ���� or ȣ��Ʈ�� 0�� �������� �������� �ֱ�
        playerReady = new bool[characterList.Count]; //�÷��̾� ready�� ���� �ؾ���
        StartCoroutine(WaitReadyTime());


        
    }

    private void Update()
    {
        CheckState();
    }

    private IEnumerator WaitReadyTime()
    {
        while (readyTime >= 0)
        {
            readyTime -= Time.deltaTime;
            yield return null;
            if (playerReady.All(value => value) == true)
            {
                state = CombatState.Battle;
                yield break;
            }
            else // �غ� �ȵǵ� �ϴ� ����
            {
                state = CombatState.Battle;
                yield break;
            }
        }
    }

    private void CheckState()
    {
        switch (state)
        {
            case CombatState.Ready:
                //�Ұ� �ֳ�?
                isBattle = false;
                isFinish = false;
                break;
            case CombatState.Battle:
                isBattle = true;
                isFinish = false;
                break;
            case CombatState.Enchant:
                isBattle = false;
                isFinish = false;
                break;
            case CombatState.Finish:
                isBattle = false;
                isFinish = true;
                break;

        }
    }
}