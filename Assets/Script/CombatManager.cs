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
    private float readyTime = 60f; //첫 준비까지 시간, 인챈트하고 다음 배틀까지 기다려주는 시간
    private float battleTime = 120f; // 배틀시간
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
        //호스트와 클라이언트를 찾아 번호 재 지정 or 호스트는 0번 나머지는 레인지로 넣기
        playerReady = new bool[characterList.Count]; //플레이어 ready와 연결 해야함
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
            else // 준비 안되도 일단 시작
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
                //할게 있나?
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