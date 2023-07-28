using System.Collections;
using UnityEngine;

public class Clicker : MonoBehaviour
{
    public static int Clicks = 0;
    public static int Money = 0;
    public static int Upgrades = 0;
    public static float TimeForAutoClick = 3f;

    public static int CostUpgrade = 5;
    public static int CostTime = 15;

    private float time = 0f;

    public delegate void DelegateAutoClick();
    public static event DelegateAutoClick OnAutoClick;

    private void Update()
    {
        if (Upgrades <= 0) return;

        if (time < TimeForAutoClick)
        {
            time += Time.deltaTime;
        }
        else
        {
            time = 0f;
            AddClicks(Upgrades);
            OnAutoClick();
        }
    }

    public void AddClicks( int add = 1 )
    {
        Clicks += add;

        AddMoney(add);
        Debug.Log("Add Click and Money");
    }

    public void AddUpgrades( int add = 1 )
    {
        Upgrades += add;

        MultiplyCostUpgrade();
    }

    public void AddTime( float add = -0.1f )
    {
        TimeForAutoClick += add;

        MultiplyCostTime();
    }

    public void AddMoney( int add = 1 )
    {
        Money += add;
    }

    public void MultiplyCostUpgrade( int multiply = 2 )
    {
        CostUpgrade *= multiply;
    }

    public void MultiplyCostTime(int multiply = 2)
    {
        CostTime *= multiply;
    }
}
