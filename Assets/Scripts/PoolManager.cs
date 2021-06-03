using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    #region Fields

    public static PoolManager POOL;
    public GameObject BulletPrefab;
    public GameObject ExplosionPrefab;

    private List<GameObject> _bulletPool;
    private int _bulletCapacity = 15;
    private int _bulletsInUSe = 0;

    private bool _bigBullets = false;
    private bool _redBullets = false;
    private bool _explosiveBullets = false;
    private int _explosionIndex = 0;

    private List<GameObject> _explosionPool;

    #endregion

    #region Unity Methods

    private void Awake()
    {
        POOL = this;

        _bulletPool = new List<GameObject>(_bulletCapacity);
        _explosionPool = new List<GameObject>(30);
    }

    private void Start()
    {
        FillBulletList();
        FillExplosionList();
    }

    #endregion

    #region Services

    public GameObject SpawnBullet()
    {
        if (_bulletsInUSe == _bulletCapacity) ExpandList();
        return FindInactiveBullet();
    }

    public void SpawnExplosion(Transform explosionSite)
    {
        GameObject explosion = _explosionPool[_explosionIndex];
        explosion.SetActive(true);
        explosion.transform.localPosition = explosionSite.position;

        _explosionIndex = ++_explosionIndex % 30;
    }

    public void ReturnBulletToPool(GameObject bullet)
    {
        _bulletsInUSe--;
        bullet.SetActive(false);
    }

    public void ToggleBigBullets()
    {
        _bigBullets = !_bigBullets;
        if (_bigBullets) ScaleUpBullets();
        else ScaleDownBullets();
    }

    public void ToggleRedBullets()
    {
        _redBullets = !_redBullets;
        if (_redBullets) PaintRedBullets();
        else PaintWhiteBullets();
    }

    public void ToggleExplosiveBullets()
    {
        _explosiveBullets = !_explosiveBullets;
        if (_explosiveBullets) ExplosiveBullets();
        else StandardBullets();
    }
    

    #endregion

    #region Internal Region

    private void ExpandList()
    {
        FillBulletList();
        _bulletCapacity *= 2;
    }

    private GameObject FindInactiveBullet()
    {
        foreach (GameObject bullet in _bulletPool)
        {
            if (!bullet.activeSelf)
            {
                bullet.SetActive(true);
                _bulletsInUSe++;
                return bullet;
            }
        }

        return null;
    }

    private void FillBulletList()
    {
        for (int i = 0; i < _bulletCapacity; i++) AddNewBulletToList();
    }

    private void FillExplosionList()
    {
        for (int i = 0; i < 30; i++) AddNewExplosionToList();
    }

    private void AddNewBulletToList()
    {
        var newBullet =Instantiate(BulletPrefab, transform);
        newBullet.SetActive(false);

        SetProjectileToggles(newBullet);
        
        _bulletPool.Add(newBullet);
    }

    private void AddNewExplosionToList()
    {
        var newExplosion =Instantiate(ExplosionPrefab, transform);
        newExplosion.SetActive(false);
        
        _explosionPool.Add(newExplosion);
    }

    private void ScaleUpBullets()
    {
        _bigBullets = true;
        RefreshBulletProperties();
    }

    private void ScaleDownBullets()
    {
        _bigBullets = false;
        RefreshBulletProperties();
    }

    private void PaintRedBullets()
    {
        _redBullets = true;
        RefreshBulletProperties();
    }

    private void PaintWhiteBullets()
    {
        _redBullets = false;
        RefreshBulletProperties();
    }

    private void ExplosiveBullets()
    {
        _explosiveBullets = true;
        RefreshBulletProperties();
    }

    private void StandardBullets()
    {
        _explosiveBullets = false;
        RefreshBulletProperties();
    }
    

    private void RefreshBulletProperties()
    {
        foreach (GameObject projectile in _bulletPool) SetProjectileToggles(projectile);
    }

    private void SetProjectileToggles(GameObject projectile)
    {
        Projectile iterator = projectile.GetComponent<Projectile>();
        iterator.ToggleBig(_bigBullets);
        iterator.ToggleRed(_redBullets);
        iterator.ToggleExplosion(_explosiveBullets);
    }

    #endregion
}