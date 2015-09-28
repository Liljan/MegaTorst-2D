using UnityEngine;
using System.Collections;

public class Weapon : MonoBehaviour
{
    public float fireRate = 0.0f;
    public float damage = 10.0f;

    private float timeToSpawnEffect = 0.0f;
    public float effectSpawnRate = 10.0f;

    public Transform playerBulletPrefab;
  //  public Transform muzzleFlashPrefab;

    private float timeToFire = 0.0f;
    private Transform firePoint;

    public float bulletSpeed = 10.0f;

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
        if (Time.time >= timeToSpawnEffect)
        {
            SpawnBullet();
	}
    }

    private void SpawnBullet()
    {
        Transform bullet = Instantiate(playerBulletPrefab, firePoint.position, Quaternion.Inverse(firePoint.rotation) ) as Transform;
       // bullet.gameObject.GetComponent<Bullet>().SetVelocity(10.0f, 0.0f);
    }
}
