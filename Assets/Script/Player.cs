using UnityEngine;

public class Player : MonoBehaviour
{
    private string playerName;
    private int playerID;
    private float hp;
    private float mp;

    public string PlayerName
    {
        get { return playerName; }
        set { playerName = value; }
    }
    public float HP
    {
        get 
        {
            if (hp <= 0) return 0;
            else if (hp >= 100) return 100;
            else return hp; 
        }
        set 
        {
            //if (hp <= 0) 게임 오버
            hp = value; 
        }
    }
    public float MP
    {
        get
        {
            if (mp <= 0) return 0;
            else if (mp >= 100)
            {
                return 100;
            }

            else return mp;
        }
        set { mp = value; }
    }

    public void CreateCharacter(string _name, float _hp, float _mp)
    {
        PlayerName = _name;
        HP = _hp;
        MP = _mp;
    }
}