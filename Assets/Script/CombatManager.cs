using System.Collections.Generic;
using UnityEngine;

public class CombatManager : MonoBehaviour
{
    public List<Character> characterList;
    public bool[] playerReady;
    private float readyTime = 60f; //ù �غ���� �ð�, ��æƮ�ϰ� ���� ��Ʋ���� ��ٷ��ִ� �ð�
    private float battleTime = 120f; // ��Ʋ�ð�
    public bool isBattle;
    public bool isFinish;

    private void Start()
    {
        // ����UI���� (�÷��̾� ui ũ�� ���߾��ֱ�)
        // 120�� ��ٷ��ְ�(������ ü���� 0�� �Ǵ°� ����)(������ ���������� �˻�?)
        // ���� ������
        // ��ȭUI ����ֱ�
        // ��ȭ�� ����� ��ųDic�� �÷��̾� ��ų�¿� �̰�
        // �ٽ� �ο�� �ݺ�
        // �ǴϽ�UI
    }
}