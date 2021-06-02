using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    #region Fields

    public static PoolManager POOL;
    public GameObject BulletPrefab;

    private List<GameObject> _bulletPool;
    private int _bulletCapacity = 15;
    private int _bulletsInUSe = 0;

    #endregion

    #region Unity Methods

    private void Awake()
    {
        POOL = this;

        _bulletPool = new List<GameObject>(_bulletCapacity);
    }

    private void Start()
    {
        FillBulletList();
    }

    #endregion

    #region Services

    public GameObject SpawnBullet()
    {
        if (_bulletsInUSe == _bulletCapacity) ExpandList();
        return FindInactiveBullet();
    }

    public void ReturnBulletToPool(GameObject bullet)
    {
        _bulletsInUSe--;
        bullet.SetActive(false);
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

    private void AddNewBulletToList()
    {
        var newBullet =Instantiate(BulletPrefab, transform);
        newBullet.SetActive(false);
        _bulletPool.Add(newBullet);
    }

    #endregion
}