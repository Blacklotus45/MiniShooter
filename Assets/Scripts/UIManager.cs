using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager UIman;
    public TextMeshProUGUI BulletCounterText;
    
    private int _bulletCount;
    
    void Awake()
    {
        UIman = this;
        _bulletCount = 0;
        PrintBulletCount();
    }

    public void IncreaseBuleltCount()
    {
        _bulletCount++;
        PrintBulletCount();
    }

    private void PrintBulletCount()
    {
        BulletCounterText.text = _bulletCount.ToString();
    }
}
