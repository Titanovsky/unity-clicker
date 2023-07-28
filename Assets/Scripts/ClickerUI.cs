using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

public class ClickerUI : Clicker
{
    public TMP_Text textClicks;
    public TMP_Text textMoney;
    public TMP_Text textUpgradesTime;
    public TMP_Text textCostUpgrade;
    public TMP_Text textCostTime;

    public AudioSource audioSrc;
    public AudioClip audioClick;
    public AudioClip audioError;

    private void Start()
    {
        textClicks.text = "";
        textMoney.text = "";

        RefreshCosts();
        RefreshTime();

        OnAutoClick += RefreshMoneyAndClicks;
    }

    private void RefreshMoneyAndClicks()
    {
        textClicks.text = $"Clicks: {Clicks}";
        textMoney.text = $"{Money}$";
    }

    private void RefreshTime()
    {
        double time = Math.Round(TimeForAutoClick, 1);
        textUpgradesTime.text = $"Upgrades: {Upgrades} / {time}";
    }

    private void RefreshCosts()
    {
        textCostTime.text = $"Buy Time {CostTime}$";
        textCostUpgrade.text = $"Buy Upgrade {CostUpgrade}$";
    }

    public void ButtonClick()
    {
        AddClicks();

        textClicks.text = $"Clicks: {Clicks}";
        textMoney.text = $"{Money}$";

        RefreshMoneyAndClicks();

        audioSrc.PlayOneShot(audioClick);
    }

    public void BuyTime()
    {
        if (Money < CostTime)
        {
            audioSrc.PlayOneShot(audioError);
            return;
        }

        AddMoney(-CostTime);

        AddTime();

        RefreshTime();
        RefreshCosts();

        RefreshMoneyAndClicks();
    }

    public void BuyUpgrade()
    {
        if (Money < CostUpgrade)
        {
            audioSrc.PlayOneShot(audioError);
            return;
        }
        
        AddMoney(-CostUpgrade);

        AddUpgrades();

        RefreshTime();
        RefreshCosts();

        RefreshMoneyAndClicks();
    }
}
