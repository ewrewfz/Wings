using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialSkillSwitch : MonoBehaviour
{
    [SerializeField] private Character player;
    [SerializeField] private SkillUI skillUI;
    [SerializeField] private SkillsManager skillsManager;

    public GameObject[] buttons;
    public SkillsManager.Property[] Propertys;
    private void FixedUpdate()
    {
        if (player != null) { return; }
        player = FindObjectOfType<Character>();
        skillUI = player.skillUI;
        skillsManager = player.GetComponentInChildren<SkillsManager>();
    }

    public GameObject SelfReturn()
    {
        return gameObject;
        
    }

    public void ChangeSingle()
    {
        skillsManager.RESingleSkill(GetComponent<CurrentProperty>().property);
    }

    public void FireSingle()
    {
        skillsManager.RESingleSkill(SkillsManager.Property.Fire);
    }public void IceSingle()
    {
        skillsManager.RESingleSkill(SkillsManager.Property.Ice);
    }public void LightenSingle()
    {
        skillsManager.RESingleSkill(SkillsManager.Property.Lightning);
    }public void WindSingle()
    {
        skillsManager.RESingleSkill(SkillsManager.Property.Wind);
    }

    public void FireKeydown()
    {
        skillsManager.REKeydown(SkillsManager.Property.Fire);
    }public void IceKeydown()
    {
        skillsManager.REKeydown(SkillsManager.Property.Ice);
    }public void LightenKeydown()
    {
        skillsManager.REKeydown(SkillsManager.Property.Lightning);
    }public void WidnKeydown()
    {
        skillsManager.REKeydown(SkillsManager.Property.Wind);
    }

    public void FireThrow()
    {
        skillsManager.REThrow(SkillsManager.Property.Fire);
    }public void IceThrow()
    {
        skillsManager.REThrow(SkillsManager.Property.Ice);
    }public void LightenThrow()
    {
        skillsManager.REThrow(SkillsManager.Property.Lightning);
    }public void WindThrow()
    {
        skillsManager.REThrow(SkillsManager.Property.Wind);
    }

    public void FireShowdown()
    {
        skillsManager.REShowdown(SkillsManager.Property.Fire);
    }
    public void IceShowdown()
    {
        skillsManager.REShowdown(SkillsManager.Property.Ice);
    }
    public void LightenShowdown()
    {
        skillsManager.REShowdown(SkillsManager.Property.Lightning);
    }
    public void WindShowdown()
    {
        skillsManager.REShowdown(SkillsManager.Property.Wind);
    }

    
}
