using UnityEngine;

public class Pistol: IGun
{

    public void ShotGun(Transform gunPoint)
    {
        GameObject bullet = PoolManager.POOL.SpawnBullet();
        bullet.transform.position = gunPoint.position;
        bullet.transform.rotation = Quaternion.LookRotation(gunPoint.forward);
        
        UIManager.UIman.IncreaseBuleltCount();
    }
}