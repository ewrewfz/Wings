using UnityEngine;

public interface ISpecialEffect
{
    void ApplyEffect();
    void ChangeValue(float _duration, float _value);

    float ReturnDuration();
    float ReturnValue();
}

public class SkillSpecialEffect : MonoBehaviour
{
    public class FireEffect : ISpecialEffect
    {
        public float burnDuration;
        public float burnDamage;

        public FireEffect(float _duration, float _damage)
        {
            burnDuration = _duration;
            burnDamage = _damage;
        }

        public void ApplyEffect()
        {

        }
        public void ChangeValue(float _duration, float _damage)
        {
            burnDuration = _duration;
            burnDamage = _damage;
        }
        public float ReturnDuration()
        {
            return burnDuration;
        }
        public float ReturnValue()
        {
            return burnDamage;
        }
    }

    public class IceEffect : ISpecialEffect
    {
        public float addDuration;
        public float addCool;

        public IceEffect(float _duration, float _addCool)
        {
            addDuration = _duration;
            addCool = _addCool;
        }

        public void ApplyEffect()
        {

        }
        public void ChangeValue(float _duration, float _addCool)
        {
            addDuration = _duration;
            addCool = _addCool;
        }
        public float ReturnDuration()
        {
            return addDuration;
        }
        public float ReturnValue()
        {
            return addCool;
        }
    }

    public class LightningEffect : ISpecialEffect
    {
        public float substractDuration;
        private float substractCool;

        public LightningEffect(float _substractDuration, float _substractCool)
        {
            substractDuration = _substractDuration;
            substractCool = _substractCool;
        }

        public void ApplyEffect()
        {

        }
        public void ChangeValue(float _substractDuration, float _substractCool)
        {
            substractDuration = _substractDuration;
            substractCool = _substractCool;
        }
        public float ReturnDuration()
        {
            return substractDuration;
        }
        public float ReturnValue()
        {
            return substractCool;
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
        public void ChangeValue(float _duration, float _manaburn)
        {
            burnDuration = _duration;
            manaburn = _manaburn;
        }
        public float ReturnDuration()
        {
            return burnDuration;
        }
        public float ReturnValue()
        {
            return manaburn;
        }
    }
}
