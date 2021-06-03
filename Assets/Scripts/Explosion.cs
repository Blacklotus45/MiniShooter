using UnityEngine;

public class Explosion: MonoBehaviour
{
    public float lifeTime = 5f;

    private float counter = 0f;

    private void OnEnable()
    {
        counter = 0f;
    }

    private void Update()
    {
        counter += Time.deltaTime;
        if (counter >= lifeTime) gameObject.SetActive(false);
    }
}