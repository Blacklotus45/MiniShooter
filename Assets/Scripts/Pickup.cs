using UnityEngine;

public class Pickup : MonoBehaviour
{
    public WeaponType weaponType;
    
    private void OnTriggerEnter(Collider other)
    {
        GameManager.Gm.WeaponPickup(weaponType);
        Destroy(gameObject);
    }
}

public enum WeaponType
{
    Pistol,
    Shotgun
}
