using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Gm;
    public GameObject player;

    private GameObject _player;
    private PlayerWeaponHandler _playerWeaponHandler; 
    private void Awake()
    {
        Gm = this;
        _player = player;
        _playerWeaponHandler = _player.GetComponent<PlayerWeaponHandler>();
    }

    private void Start()
    {
        WeaponPickup(new Pistol());
    }

    public void WeaponPickup(IGun weapon)
    {
        _playerWeaponHandler.RegisterGun(weapon);
    }
}