using UnityEngine;

public interface ISpecialEffect
{
    void ApplyEffect();
}

public class SkillSpecialEffect : MonoBehaviour
{
    public class FireEffect : ISpecialEffect
    {
        private float burnDuration;
        private float burnDamage;

        public FireEffect(float _duration, float _damage)
        {
            burnDuration = _duration;
            burnDamage = _damage;
        }

        public void ApplyEffect()
        {
            
        }
    }

    public class IceEffect : ISpecialEffect
    {
        private float addCool;

        public IceEffect(float _addCool)
        {
            addCool = _addCool;
        }

        public void ApplyEffect()
        {
            
        }
    }

    public class LightningEffect : ISpecialEffect
    {
        private float substractCool;

        public LightningEffect(float _substractCool)
        {
            substractCool = _substractCool;
        }

        public void ApplyEffect()
        {
            
        }
    }

    public class WindEffect : ISpecialEffect
    {
        private float burnDuration;
        private float manaburn;

        public WindEffect(float _duration, float _manaburn)
        {
            burnDuration = _duration;
            manaburn = _manaburn;
        }

        public void ApplyEffect()
        {

        }
    }
}
