using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class SkillUI : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] private SkillsManager skillsManager;
    [SerializeField] private Slider slideHP, slideMP;
    [SerializeField] private Slider imaginHP, imaginMP;
    public Sprite[] all_skills;
    public List<Image> set_skills;
    public Sprite[] dashState;
    public List<Image> dashIcon;

    private void Update()
    {
        UpdateDashicon();
    }
    private void UpdateDashicon()
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
    Coroutine _corMP = null;
    Coroutine _corHP = null;
    public void UpdateHPSlide(float targethp) // 데미지 받으면 불러오기
    {
        if (_corHP != null) StopCoroutine(_corHP);
        _corHP = StartCoroutine(MoveHPSlides(targethp));
    }
    
    public void UpdateMPSlide(float targetmp) // 마나쓰거나 찰때 불러오기, 실제 mp는 이미 움직이고 이 스크립트는 오직 슬라이드만 움직인다.
    {
        if (_corMP != null) StopCoroutine(_corMP);
        _corMP = StartCoroutine(MoveMPSlides(targetmp));
    }
    private IEnumerator MoveMPSlides(float targetmp)
    {
        if (targetmp >= imaginMP.value) { imaginMP.value = targetmp; }
        else
        {
            float _t = 0f;
            float currentMP = imaginMP.value;
            while (_t < 0.5f)
            {
                _t += Time.deltaTime;
                imaginMP.value = Mathf.Lerp(currentMP, targetmp, _t / 0.5f);
                yield return null;
            }
            imaginMP.value = targetmp;
        }
        if (targetmp >= slideMP.value)
        {
            float _t = 0f;
            float currentMP = slideMP.value;
            while (_t < 0.5f) 
            {
                _t += Time.deltaTime;
                slideMP.value = Mathf.Lerp(currentMP, targetmp, _t / 0.5f);
                yield return null;
            }
            slideMP.value = targetmp;
        }
        else { slideMP.value = targetmp; }

    }
    private IEnumerator MoveHPSlides(float targethp)
    {
        if (targethp >= imaginHP.value) { imaginHP.value = targethp; }
        else
        {
            float _t = 0f;
            float currentHP = imaginHP.value;
            while (_t < 0.5f)
            {
                _t += Time.deltaTime;
                imaginHP.value = Mathf.Lerp(currentHP, targethp, _t / 0.5f);
                yield return null;
            }
            imaginHP.value = targethp;
        }
        if (targethp >= slideHP.value)
        {
            float _t = 0f;
            float currentHP = slideHP.value;
            while (_t < 0.5f)
            {
                _t += Time.deltaTime;
                slideHP.value = Mathf.Lerp(currentHP, targethp, _t / 0.5f);
                yield return null;
            }
            slideHP.value = targethp;
        }
        else { slideHP.value = targethp; }

    }
}
