using UnityEngine;

public class Shotgun: IGun
{
    private int _pellets;
    private float _spread = 30f;
    
    public Shotgun(int pellets)
    {
        _pellets = pellets;
    }

    public void Shot(Transform gunPoint)
    {
        float spreadAngle = _spread / 180f;
        for (int i = 0; i < _pellets; i++)
        {
            GameObject bullet = PoolManager.POOL.SpawnBullet();
            bullet.transform.position = gunPoint.position;
            
            Vector3 pelletDirection = Vector3.Slerp(gunPoint.forward,Random.insideUnitSphere,spreadAngle);
            bullet.transform.rotation = Quaternion.LookRotation(pelletDirection);
        
            UIManager.UIman.IncreaseBuleltCount();
        }
    }
}