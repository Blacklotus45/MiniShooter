using System;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeaponHandler : MonoBehaviour
{
    public Transform GunPoint;

    private IGun _activeGun;

    private List<IGun> _guns;

    private void Awake()
    {
        _guns = new List<IGun>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0)) _activeGun?.ShotGun(GunPoint);
    }

    #region Gun Inventory Management

    public void RegisterGun(IGun newGun)
    {
        _guns.Add(newGun);
        _activeGun ??= newGun;
    }

    public void SwitchGun(int index)
    {
        
    }

    public void NextGun()
    {
        
    }

    public void PreviousGun()
    {
        
    }

    #endregion
}
