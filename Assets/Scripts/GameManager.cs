using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Gm;
    public GameObject player;
    public int shotgunPellets = 10;

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
        WeaponPickup(WeaponType.Pistol);
    }

    public void WeaponPickup(WeaponType weapon)
    {
        _playerWeaponHandler.RegisterGun(WeaponPicker(weapon));
    }

    private IGun WeaponPicker(WeaponType type)
    {
        IGun gun = null;
        switch (type)
        {
            case WeaponType.Pistol:
                gun = new Pistol();
                break;
            case WeaponType.Shotgun:
                gun = new Shotgun(shotgunPellets);
                break;
        }

        return gun;
    }
}