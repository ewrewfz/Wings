using System.Collections.Generic;
using UnityEngine;

public class CombatManager : MonoBehaviour
{
<<<<<<< Updated upstream
    public List<Character> characterList;
=======
    public List<Character> characterList; //캐릭터에서 준비상태를 어떻게 받아올지 생각해야 함
>>>>>>> Stashed changes
    public bool[] playerReady;
    private float readyTime = 60f; //첫 준비까지 시간, 인챈트하고 다음 배틀까지 기다려주는 시간
    private float battleTime = 120f; // 배틀시간
    public bool isBattle;
    public bool isFinish;
<<<<<<< Updated upstream

    private void Start()
    {
        // 시작UI띄우기 (플레이어 ui 크게 비추어주기)
        // 120초 기다려주고(누군가 체력이 0이 되는걸 감지)(데미지 받을때마다 검사?)
        // 승자 가리기
        // 강화UI 띄어주기
        // 강화후 변경된 스킬Dic을 플레이어 스킬셋에 이관
        // 다시 싸우기 반복
        // 피니쉬UI
=======

    //시작ui 띄우기
    //전투 시작하기
    //승패 가리기
    //강화 ui 띄우기
    //반복하기
    //finish ui띄 우기
    //시작씬으로 돌려보내기

    private void OpenStartUI()
    {
        isBattle = false;
        isFinish = false;
        //플레이어의 대기 확인
        StartCoroutine(CheckReady());
    }

    private IEnumerator CheckReady() //60초 기다려주고 시작
    {
        float _time = 0f;
        while (playerReady.Contains<bool>(false) && _time < readyTime)
        {
            _time += Time.deltaTime;
            yield return null;
        }
        StartBattle();
    }

    private void StartBattle()
    {
        foreach (Character character in characterList) //나중에 setFull이라는 함수로 character 스크립트에 옮기기
        {
            character.HP = 100;
            character.MP = 100;
            character.skillUI.UpdateHPSlide(100);
            character.skillUI.UpdateMPSlide(100);
            //스킬의 쿨타임 표기가 있다면 그것도 초기화 하기
        }
        isBattle = true;
        StartCoroutine(CheckWinner());
    }

    private IEnumerator CheckWinner() //진사람 체크..
    {
        float _time = 0f;
        List<Character> losers = new List<Character>();
        Character winner = null;
        while (_time < battleTime)
        {
            _time += Time.deltaTime;
            foreach(Character character in characterList)
            {
                if(character.HP == 0)
                {
                    losers.Add(character);
                }
                else
                {
                    winner = character;
                }
            }

            if (losers.Count == characterList.Count - 1)
            { //승자가 1명으로 정해짐
                isBattle = false;
                break;
            }
            else 
            {
                losers.Clear();
                yield return null;
            }
        }
        //2분 이후에 체력에 따라 승자를 가리는 메커니즘 추가 해야 함
        if (!isBattle)
            OpenEnchantUI();
    }

    private void OpenEnchantUI()
    {

    }

    private void OpenFinishUI()
    {

    }
    private void ReturnLobby()
    {

    }

    private IEnumerator WaitTime(float _time)
    {
        float _t = 0;
        while (_t < _time)
        {
            _t += Time.deltaTime;
            yield return null;
        }
>>>>>>> Stashed changes
    }
}