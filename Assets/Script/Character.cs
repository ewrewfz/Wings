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

    public void OnDamage(float damage)
    {
        if (myplayer.HP <= 0)
            return;
            myplayer.HP -= damage;
            skillUI.UpdateHPSlide(myplayer.HP);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<SkillItem>() != null)
        {
            SkillItem skill = collision.gameObject.GetComponent<SkillItem>();
            OnDamage(skill.damage);
            if (skill.property == SkillsManager.Property.Fire) //���̾��϶��� �����
            {
                new SkillSpecialEffect.FireEffect(skill.duration, skill.value).ApplyEffect();
            }
        }
    }
}
