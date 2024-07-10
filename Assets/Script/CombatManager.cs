using System.Collections.Generic;
using UnityEngine;

public class CombatManager : MonoBehaviour
{
    public List<Character> characterList;
    public bool[] playerReady;
    private float readyTime = 60f; //첫 준비까지 시간, 인챈트하고 다음 배틀까지 기다려주는 시간
    private float battleTime = 120f; // 배틀시간
    public bool isBattle;
    public bool isFinish;

    private void Start()
    {
        // 시작UI띄우기 (플레이어 ui 크게 비추어주기)
        // 120초 기다려주고(누군가 체력이 0이 되는걸 감지)(데미지 받을때마다 검사?)
        // 승자 가리기
        // 강화UI 띄어주기
        // 강화후 변경된 스킬Dic을 플레이어 스킬셋에 이관
        // 다시 싸우기 반복
        // 피니쉬UI
    }
}