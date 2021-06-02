using UnityEngine;

public class PlayerWeaponHandler : MonoBehaviour
{
    public Transform GunPoint;
    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            ShootGun();
        }
    }

    private void ShootGun()
    {
        GameObject bullet = PoolManager.POOL.SpawnBullet();
        bullet.transform.position = GunPoint.position;
        bullet.transform.rotation = Quaternion.LookRotation(GunPoint.forward);
        
        UIManager.UIman.IncreaseBuleltCount();
    }
}
