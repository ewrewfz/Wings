using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class SkillUI : MonoBehaviour
{
    [SerializeField] private SkillsManager skillsManager;
    [SerializeField] private Slider slideHP, slideMP;
    public Sprite[] all_skills;
    public List<Image> set_skills;
    public Sprite[] dashState;
    public List<Image> dashIcon;

    private void Update()
    {
        switch (skillsManager.threeGo)
        {
            case 3:
                dashIcon[0].sprite = dashState[1];
                dashIcon[1].sprite = dashState[1];
                dashIcon[2].sprite = dashState[1];
                break;
            case 2:
                dashIcon[0].sprite = dashState[0];
                dashIcon[1].sprite = dashState[1];
                dashIcon[2].sprite = dashState[1];
                break;
            case 1:
                dashIcon[0].sprite = dashState[0];
                dashIcon[1].sprite = dashState[0];
                dashIcon[2].sprite = dashState[1];
                break;
            case 0:
                dashIcon[0].sprite = dashState[0];
                dashIcon[1].sprite = dashState[0];
                dashIcon[2].sprite = dashState[0];
                break;
        }
    }
}
