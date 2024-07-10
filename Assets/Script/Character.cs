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
        //characterName = 룸메니저 이름 받기
        myplayer = new Player();
        myplayer.CreateCharacter(characterName, 100, 90);
        skillUI.UpdateHPSlide(100);
        skillUI.UpdateMPSlide(90);
        StartCoroutine(ChargeMP());
    }

    private IEnumerator ChargeMP()
    {
        while (myplayer.HP > 0) //캐릭터가 살아있으면
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
            if (skill.property == SkillsManager.Property.Fire) //파이어일때만 적용됨
            {
                new SkillSpecialEffect.FireEffect(skill.duration, skill.value).ApplyEffect();
            }
        }
    }
}
