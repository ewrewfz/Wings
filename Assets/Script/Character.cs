using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : Player
{
    private string characterName;
    public SkillUI skillUI;
    private Player myplayer;
    private void Start()
    {
        //characterName = ��޴��� �̸� �ޱ�
        myplayer = new Player();
        myplayer.CreateCharacter(characterName, 100, 90);
        skillUI.UpdateHPSlide(100);
        skillUI.UpdateMPSlide(90);
        StartCoroutine(ChargeMP());
    }

    private IEnumerator ChargeMP()
    {
        while (myplayer.HP > 0) //ĳ���Ͱ� ���������
        {
            yield return new WaitForSeconds(1);
            myplayer.MP++;
            skillUI.UpdateMPSlide(myplayer.MP);
        }
    }
}
