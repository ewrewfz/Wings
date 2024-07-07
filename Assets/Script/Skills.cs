using UnityEngine;

public class Skills : MonoBehaviour
{
    public string skillName;
    public float damage;
    public float manaCost;
    public float cooldown;
    public SkillsManager.Property property;
    public SkillsManager.Type type;
    protected ISpecialEffect specialEffect;
    public string ownerName;

    public void Initialize(SkillsManager.Property property, SkillsManager.Type type, string ownerName)
    {
        this.property = property;
        this.type = type;
        this.ownerName = ownerName;

        switch (property)
        {
            case SkillsManager.Property.Fire:
                specialEffect = new SkillSpecialEffect.FireEffect(1.0f, 3f);
                break;
            case SkillsManager.Property.Ice:
                specialEffect = new SkillSpecialEffect.IceEffect(2.5f);
                break;
            case SkillsManager.Property.Lightning:
                specialEffect = new SkillSpecialEffect.LightningEffect(2.0f);
                break;
            case SkillsManager.Property.Wind:
                specialEffect = new SkillSpecialEffect.WindEffect(5.0f, 5f);
                break;
        }

        switch (type)
        {
            case SkillsManager.Type.Single:
                skillName = $"{property} Single";
                damage = 5f;
                manaCost = 5f;
                cooldown = 5.0f;
                break;
            case SkillsManager.Type.KeyDown:
                skillName = $"{property} KeyDown";
                damage = 40f;
                manaCost = 15f;
                cooldown = 4.0f;
                break;
            case SkillsManager.Type.Throw:
                skillName = $"{property} Throw";
                damage = 60f;
                manaCost = 25f;
                cooldown = 6.0f;
                break;
            case SkillsManager.Type.Showdown:
                skillName = $"{property} Showdown";
                damage = 70f;
                manaCost = 30f;
                cooldown = 7.0f;
                break;
        }
    }

    public void Use()
    {
        Debug.Log($"{skillName} used! Deals {damage} damage and costs {manaCost} mana.");
        Rigidbody rb = GetComponent<Rigidbody>();  
        if (rb != null)
        {
            rb.AddForce(transform.forward * 10f, ForceMode.Impulse); // 예시로 앞으로 발사
        }
    }

    protected void OnCollisionEnter(Collision collision)
    {
        Character enemy = collision.gameObject.GetComponent<Character>();
        if (enemy != null && enemy.PlayerName != ownerName)
        {
            ApplyDamage(enemy.gameObject);
            specialEffect?.ApplyEffect();
            //Destroy(gameObject); // 스킬 오브젝트 파괴
        }
    }

    protected void ApplyDamage(GameObject target)
    {
        Character enemy = target.GetComponent<Character>();
        if (enemy != null)
        {
            enemy.OnDamage(damage);
        }
    }


}
