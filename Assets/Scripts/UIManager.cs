using System;
using TMPro;
using UnityEditor;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager UIman;
    public TextMeshProUGUI BulletCounterText;
    public GameObject EscMenu;
    
    private int _bulletCount;
    
    void Awake()
    {
        UIman = this;
        _bulletCount = 0;
        PrintBulletCount();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) ToggleEscMenu();
    }

    private void ToggleEscMenu()
    {
        EscMenu.SetActive(!EscMenu.activeSelf);
    }

    private void PrintBulletCount()
    {
        BulletCounterText.text = _bulletCount.ToString();
    }

    public void IncreaseBuleltCount()
    {
        _bulletCount++;
        PrintBulletCount();
    }

    public void ExitApplication()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
#if UNITY_STANDALONE
        Application.Quit();
#endif
    }
}
