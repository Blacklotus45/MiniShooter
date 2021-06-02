using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float Velocity = 1f;
    public float KillTimer = 5f;

    private Transform _cacheTransform;
    private float timer;

    private void Awake()
    {
        _cacheTransform = transform;
    }

    // Update is called once per frame
    void Update()
    {
        float cacheDeltaTime = Time.deltaTime;
        timer += cacheDeltaTime;
        if (timer > KillTimer) ReturnToPool();

        Vector3 delta = Velocity * cacheDeltaTime * _cacheTransform.forward;
        _cacheTransform.position = delta + _cacheTransform.position;
    }

    private void OnEnable()
    {
        Fire();
    }

    private void ReturnToPool()
    {
        PoolManager.POOL.ReturnBulletToPool(gameObject);
    }

    private void Fire()
    {
        timer = 0f;
    }
}
