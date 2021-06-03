using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float Velocity = 1f;
    public float KillTimer = 5f;
    public GameObject _meshHolder;

    private Vector3 _smallScale = new Vector3(0.1f,0.5f,0.1f);
    private Vector3 _bigScale = new Vector3(0.25f,0.75f,0.25f);

    private MeshRenderer _meshRenderer;
    private Transform _cacheTransform;
    private float timer;
    private bool _isExplosive = false;

    private void Awake()
    {
        _cacheTransform = transform;
        _meshRenderer = _meshHolder.GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        float cacheDeltaTime = Time.deltaTime;
        timer += cacheDeltaTime;

        Vector3 delta = Velocity * cacheDeltaTime * _cacheTransform.forward;
        _cacheTransform.position = delta + _cacheTransform.position;
        
        CheckEOL();
    }

    private void OnEnable()
    {
        Fire();
    }

    private void CheckEOL()
    {
        if (timer > KillTimer)
        {
            PoolManager.POOL.ReturnBulletToPool(gameObject);
            if (_isExplosive) PoolManager.POOL.SpawnExplosion(transform);
        }
    }

    private void Fire()
    {
        timer = _isExplosive ? KillTimer - 1f + Random.Range(-0.5f,0.5f) : 0f;
    }

    public void ToggleBig(bool isBig)
    {
        _meshHolder.transform.localScale = isBig ? _bigScale : _smallScale;
    }

    public void ToggleRed(bool isRed)
    {
        _meshRenderer.material.color = isRed ? Color.red : Color.white;
    }

    public void ToggleExplosion(bool isExplosive)
    {
        _isExplosive = isExplosive;
    }
    
}
