using UnityEngine;
using System.Collections;

public class Weapon : MonoBehaviour
{
    public float fireRate = 0.0f;
    public float damage = 10.0f;
    public LayerMask whatToHit;

    public Transform playerBulletPrefab;
    private float timeToSpawnEffect = 0.0f;
    public float effectSpawnRate = 10.0f;

    public Transform muzzleFlashPrefab;

    float timeToFire = 0.0f;
    Transform firePoint;

    void Start()
    {
        try
        {
            firePoint = transform.FindChild("FirePoint");
        }
        catch (System.Exception)
        {
            Debug.LogError("No firepoint. This is sum bullshiet.");
            throw;
        }

    }

    void Update()
    {

        // if the primary fire button is pressed

        if (Input.GetButtonDown("Fire1"))
        {
            if (fireRate == 0)
            {
                Shoot();
            }
            else if (Time.time > timeToFire)
            {
                timeToFire = Time.time + 1 / fireRate;
                Shoot();
            }
        }
    }

    private void Shoot()
    {
        Vector2 firePointPosition = new Vector2(firePoint.position.x, firePoint.position.y);

        if (Time.time >= timeToSpawnEffect)
        {
            Effect();
            timeToSpawnEffect = Time.time + 1 / effectSpawnRate;
        }
    }

    private void Effect()
    {
      
        Instantiate(playerBulletPrefab, firePoint.position, firePoint.rotation);
        Transform clone = Instantiate(muzzleFlashPrefab, firePoint.position, firePoint.rotation) as Transform;
        clone.parent = firePoint;
        float size = Random.Range(0.6f, 1.0f);
        clone.localScale = new Vector3(size, size, 1.0f);
        Destroy(clone.gameObject, 0.02f);
    }
}
