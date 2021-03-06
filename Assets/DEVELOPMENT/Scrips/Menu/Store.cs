using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Store : MonoBehaviour
{
    [SerializeField] Gun Rifle, Shotgun, Sniper;
    [SerializeField] Slider[] Sliders;
    [SerializeField] int[] Price;
    [SerializeField] TextMeshProUGUI[] TextPrice;
    [SerializeField] AudioClip sellClip;
    GameManager Manager;
    [SerializeField] int PriceX;


    private void Start()
    {
        Manager = FindObjectOfType<GameManager>();
        //LoadGuns();      
        LoadSliders();
        StartSlider();
        AsignPrice();
        AsignText();
      
    }

    public void UpgradeDamage(int Id)
    {
        switch (Id)
        {
            case 0:
                if (Price[Id] <= Manager.money)
                {
                    if (Sliders[Id].value >= 3) return;
                    Sliders[Id].value++;
                    Rifle.damage += 12.5f;
                    Manager.DownScore(Price[Id]);
                    Price[Id] = Price[Id] * PriceX;
                    AsignText();
                    AudioSource.PlayClipAtPoint(sellClip, Rifle.transform.position, 1);

                }


                break;

            case 1:
                if (Price[Id] <= Manager.money)
                {
                    if (Sliders[Id].value >= 3) return;
                    Sliders[Id].value++;
                    Shotgun.damage += 10;
                    Manager.DownScore(Price[Id]);
                    Price[Id] = Price[Id] * PriceX;
                    AsignText();
                    AudioSource.PlayClipAtPoint(sellClip, Rifle.transform.position, 1);
                }
                break;
            case 2:
                if (Price[Id] <= Manager.money)
                {
                    if (Sliders[Id].value >= 3) return;
                    Sliders[Id].value++;
                    Sniper.damage += 15;
                   
                    Manager.DownScore(Price[Id]);
                    Price[Id] = Price[Id] * PriceX;
                    AsignText();
                    AudioSource.PlayClipAtPoint(sellClip, Rifle.transform.position, 1);
                }
                break;
            default:
                break;               
        }
        
        PlayerPrefs.Save();
    }
    public void UpgradeReload(int Id)
    {

        switch (Id)
        {
            case 0:
                if (Price[Id+3] <= Manager.money)
                {
                    if (Sliders[Id + 3].value >= 3) return;
                    Sliders[Id + 3].value++;
                    int i1 = Id + 3;
                    Rifle.rechargerTime += 0.5f;
                    Manager.DownScore(Price[Id+3]);
                    Price[Id + 3] = Price[Id + 3] * PriceX;
                    AsignText();
                    AudioSource.PlayClipAtPoint(sellClip, Rifle.transform.position, 1);
                }
                break;

            case 1:
                if (Price[Id + 3] <= Manager.money)
                {
                    if (Sliders[Id + 3].value >= 3) return;
                    Sliders[Id + 3].value++;
                    int i2 = Id + 3;
                    Shotgun.rechargerTime += 0.5f;
                    Manager.DownScore(Price[Id + 3]);
                    Price[Id + 3] = Price[Id + 3] * PriceX;
                    AsignText();
                    AudioSource.PlayClipAtPoint(sellClip, Rifle.transform.position, 1);
                }
                break;

            case 2:
                if (Price[Id + 3] <= Manager.money)
                {
                    if (Sliders[Id + 3].value >= 3) return;
                    Sliders[Id + 3].value++;
                    int i3 = Id + 3;
                    Sniper.rechargerTime += 0.5f;
                    Manager.DownScore(Price[Id + 3]);
                    Price[Id + 3] = Price[Id + 3] * PriceX;
                    AsignText();
                    AudioSource.PlayClipAtPoint(sellClip, Rifle.transform.position, 1);
                }
                break;

            default:
                break;
        }
        PlayerPrefs.Save();
    }
    public void UpgradeSpecial(int Id)
    {

        switch (Id)
        {
            case 0:
                if (Price[Id + 6] <= Manager.money)
                {
                    if (Sliders[Id + 6].value >= 3) return;
                    Sliders[Id + 6].value++;
                    int i1 = Id + 6;
                    Rifle.numberOfShots += 1;

                    Manager.DownScore(Price[Id + 6]);
                    Price[Id + 6] = Price[Id + 6] * PriceX;
                    AsignText();
                    AudioSource.PlayClipAtPoint(sellClip, Rifle.transform.position, 1);
                }
                break;

            case 1:

                if (Price[Id + 6] <= Manager.money)
                {
                    if (Sliders[Id + 6].value >= 3) return;
                    Sliders[Id + 6].value++;
                    int i2 = Id + 6;
                    Shotgun.numberOfShots += 2;

                    Manager.DownScore(Price[Id + 6]);
                    Price[Id + 6] = Price[Id + 6] * PriceX;
                    AsignText();
                    AudioSource.PlayClipAtPoint(sellClip, Rifle.transform.position, 1);
                }
                break;
            case 2:
                if (Price[Id + 6] <= Manager.money)
                {
                    if (Sliders[Id + 6].value >= 3) return;
                    Sliders[Id + 6].value++;
                    int i3 = Id + 6;
                    Sniper.magazine += 1;
                    Manager.DownScore(Price[Id + 6]);
                    Price[Id + 6] = Price[Id + 6] * PriceX;
                    AsignText();
                    AudioSource.PlayClipAtPoint(sellClip, Rifle.transform.position, 1);
                }
                break;
            default:
                break;
        }
        PlayerPrefs.Save();
    }
  
    public void LoadSliders()
    {
        for (int i = 0; i < Sliders.Length; i++)
        {
            Sliders[i].value = PlayerPrefs.GetFloat("Slider" + i,0);
        }
    }
    public void ResetKeys()
    {
        PlayerPrefs.DeleteAll();
    }
    private void LoadGuns()
    {
        Rifle.damage = PlayerPrefs.GetFloat("DamageRifle", Rifle.damage);
        Shotgun.damage = PlayerPrefs.GetFloat("DamageShotgun", Shotgun.damage);
        Sniper.damage = PlayerPrefs.GetFloat("DamageSniper", Sniper.damage);
        Rifle.rechargerTime = PlayerPrefs.GetFloat("ReloadRifle", Rifle.rechargerTime);
        Shotgun.rechargerTime = PlayerPrefs.GetFloat("ReloadShotgun", Shotgun.rechargerTime);
        Sniper.rechargerTime = PlayerPrefs.GetFloat("ReloadSniper", Sniper.rechargerTime);
        Rifle.numberOfShots = PlayerPrefs.GetInt("SpecialRifle", Rifle.numberOfShots);
        Shotgun.numberOfShots = PlayerPrefs.GetInt("SpecialShotgun", Shotgun.numberOfShots);
        Sniper.magazine = PlayerPrefs.GetInt("SpecialSniper", Sniper.magazine);
    }
    void StartSlider()
    {
        foreach (var i in Sliders)
        {
         if(i.value == 0) i.value = 1;
        }
    }
    void AsignText()
    {
        for (int i = 0; i < Price.Length; i++)
        {
            if (Sliders[i].value >= 3) TextPrice[i].text = "Full";            
            else TextPrice[i].text = Price[i].ToString();
        }
    }
    void AsignPrice()
    {
        for (int i = 0; i < Price.Length; i++)
        {
            switch (Sliders[i].value)
            {
                case 1: 
                    break;

                case 2: Price[i] = Price[i] * PriceX;
                    break;

                case 3: TextPrice[i].text = "Full";
                    break;

                default:
                    break;
            }
        }
    }
    public void SaveSliders()
    {
        for (int i = 0; i < Sliders.Length; i++)
        {
            PlayerPrefs.SetFloat("Slider" + i, Sliders[i].value);
        }
    }
    public void SaveUpgrades()
    {
        PlayerPrefs.SetFloat("DamageRifle", Rifle.damage);
        PlayerPrefs.SetFloat("DamageShotgun", Shotgun.damage);
        PlayerPrefs.SetFloat("DamageSniper", Sniper.damage);
        PlayerPrefs.SetFloat("ReloadRifle", Rifle.rechargerTime);
        PlayerPrefs.SetFloat("ReloadShotgun", Shotgun.rechargerTime);
        PlayerPrefs.SetFloat("ReloadSniper", Sniper.rechargerTime);
        PlayerPrefs.SetInt("SpecialRifle", Rifle.numberOfShots);
        PlayerPrefs.SetInt("SpecialShotgun",Shotgun.numberOfShots);
        PlayerPrefs.SetInt("SpecialSniper", Sniper.magazine);
    }
}