using UnityEngine;

public class Skills : MonoBehaviour
{
    public string skillName;
    public GameObject skillPrefab;
    public float damage;
    public float manaCost;
    public float cooldown;
    public SkillsManager.Property property;
    public SkillsManager.Type type;
    public ISpecialEffect specialEffect;
    public string ownerName;

    public Skills(string _skillName, GameObject _skillPrefab, float _damage, float _manaCost, float _cooldown, SkillsManager.Property _property, SkillsManager.Type _type, ISpecialEffect _specialEffect)
    {
        skillName = _skillName;
        skillPrefab = _skillPrefab;
        damage = _damage;
        manaCost = _manaCost;
        cooldown = _cooldown;
        property = _property;
        type = _type;
        specialEffect = _specialEffect;
    }


}
