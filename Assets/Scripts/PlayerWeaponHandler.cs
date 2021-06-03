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
        if (Input.GetKeyDown(KeyCode.Mouse0)) _activeGun?.Shot(GunPoint);
        if (Input.GetKeyDown(KeyCode.Alpha1)) SwitchGun(0);
        if (Input.GetKeyDown(KeyCode.Alpha2)) SwitchGun(1);
    }

    #region Gun Inventory Management

    public void RegisterGun(IGun newGun)
    {
        _guns.Add(newGun);
        _activeGun ??= newGun;
    }

    public void SwitchGun(int index)
    {
        if (_guns.Count < index + 1) return;
        _activeGun = _guns[index];
    }

    public void NextGun()
    {
        
    }

    public void PreviousGun()
    {
        
    }

    #endregion
}
