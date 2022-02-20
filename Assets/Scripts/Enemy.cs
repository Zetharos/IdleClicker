using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public int curHp;
    public int maxHp;
    public int goldToGive;
    public Image healthBarFill;
    public Animation anim;

    public static Enemy instance;

    private void Awake()
    {
        instance = this;
    }

    public void Damage()
    {
        curHp--;
        healthBarFill.fillAmount = (float)curHp / (float)maxHp;

        anim.Stop();
        anim.Play();

        if (curHp < 0)
        {
            Defeated();
        }
    }

    public void Defeated()
    {
        EnemyManager.instance.DefeatEnemy(gameObject);
        GameManager.instance.AddGold(goldToGive);
    }
}
