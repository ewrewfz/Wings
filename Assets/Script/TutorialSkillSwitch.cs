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
    private void Start()
    {
        player = FindObjectOfType<Character>();
        skillUI = player.skillUI;
        skillsManager = player.GetComponentInChildren<SkillsManager>();
    }

    public void ChangeSingle(SkillsManager.Property property)
    {
        skillsManager.RESingleSkill(property);
    }

    public void SelectProperty()
    {

    }
}
