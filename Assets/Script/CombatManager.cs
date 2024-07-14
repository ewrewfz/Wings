using System.Collections.Generic;
using UnityEngine;

public class CombatManager : MonoBehaviour
{
<<<<<<< Updated upstream
    public List<Character> characterList;
=======
    public List<Character> characterList; //ĳ���Ϳ��� �غ���¸� ��� �޾ƿ��� �����ؾ� ��
>>>>>>> Stashed changes
    public bool[] playerReady;
    private float readyTime = 60f; //ù �غ���� �ð�, ��æƮ�ϰ� ���� ��Ʋ���� ��ٷ��ִ� �ð�
    private float battleTime = 120f; // ��Ʋ�ð�
    public bool isBattle;
    public bool isFinish;
<<<<<<< Updated upstream

    private void Start()
    {
        // ����UI���� (�÷��̾� ui ũ�� ���߾��ֱ�)
        // 120�� ��ٷ��ְ�(������ ü���� 0�� �Ǵ°� ����)(������ ���������� �˻�?)
        // ���� ������
        // ��ȭUI ����ֱ�
        // ��ȭ�� ����� ��ųDic�� �÷��̾� ��ų�¿� �̰�
        // �ٽ� �ο�� �ݺ�
        // �ǴϽ�UI
=======

    //����ui ����
    //���� �����ϱ�
    //���� ������
    //��ȭ ui ����
    //�ݺ��ϱ�
    //finish ui�� ���
    //���۾����� ����������

    private void OpenStartUI()
    {
        isBattle = false;
        isFinish = false;
        //�÷��̾��� ��� Ȯ��
        StartCoroutine(CheckReady());
    }

    private IEnumerator CheckReady() //60�� ��ٷ��ְ� ����
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
        foreach (Character character in characterList) //���߿� setFull�̶�� �Լ��� character ��ũ��Ʈ�� �ű��
        {
            character.HP = 100;
            character.MP = 100;
            character.skillUI.UpdateHPSlide(100);
            character.skillUI.UpdateMPSlide(100);
            //��ų�� ��Ÿ�� ǥ�Ⱑ �ִٸ� �װ͵� �ʱ�ȭ �ϱ�
        }
        isBattle = true;
        StartCoroutine(CheckWinner());
    }

    private IEnumerator CheckWinner() //����� üũ..
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
            { //���ڰ� 1������ ������
                isBattle = false;
                break;
            }
            else 
            {
                losers.Clear();
                yield return null;
            }
        }
        //2�� ���Ŀ� ü�¿� ���� ���ڸ� ������ ��Ŀ���� �߰� �ؾ� ��
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