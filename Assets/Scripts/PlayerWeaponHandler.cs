using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerWeaponHandler : MonoBehaviour
{
    public Transform GunPoint;

    public Image PistolOverlay;
    public Image ShotgunOverlay;

    private IGun _activeGun;

    private List<IGun> _guns;
    private LockUpdate _locker;

    private void Awake()
    {
        _guns = new List<IGun>();
        _locker = new LockUpdate();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) _locker.ToggleLock();
        if (_locker.Lock) return;
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
        HandleGunUI(index);
    }

    #endregion

    private void HandleGunUI(int activeGunIndex)
    {
        Color activeElement = Color.white;
        activeElement.a = 0f;
        Color deactivateElement = Color.black;
        deactivateElement.a = 0.6f;
        
        switch (activeGunIndex)
        {
            case 0:
                PistolOverlay.color = activeElement;
                ShotgunOverlay.color = deactivateElement;
                break;
            case 1:
                PistolOverlay.color = deactivateElement;
                ShotgunOverlay.color = activeElement;
                break;
        }
    }
}
