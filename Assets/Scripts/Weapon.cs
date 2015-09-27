using UnityEngine;
using System.Collections;

public class Weapon : MonoBehaviour
{
    public float fireRate = 0.0f;
    public float damage = 10.0f;
    public LayerMask whatToHit;

    public Transform bulletTrailPrefab;
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

        // Manual fire
        if (fireRate == 0)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                Shoot();
            }
            else
            {
                // Automatic fire
                if (Input.GetButtonDown("Fire1") && Time.time > timeToFire)
                {
                    timeToFire = Time.time + 1 / fireRate;
                    Shoot();
                }
            }
        }
    }

    private void Shoot()
    {
        Vector2 mousePosition = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
        Vector2 firePointPosition = new Vector2(firePoint.position.x, firePoint.position.y);
        RaycastHit2D hit = Physics2D.Raycast(firePointPosition, mousePosition - firePointPosition, 100, whatToHit);

        if (Time.time >= timeToSpawnEffect) { 
            Effect();
            timeToSpawnEffect = Time.time + 1 / effectSpawnRate;
        }

        Debug.DrawLine(firePointPosition, (mousePosition - firePointPosition) * 100, Color.magenta);

        if (hit.collider)
        {
            Debug.DrawLine(firePointPosition, hit.point, Color.green);
            Debug.Log("We hit" + hit.collider.name + "and did " + damage + " points of damage, sucka!");
        }
    }

    private void Effect()
    {
        Debug.Log("Spawned");
        Instantiate(bulletTrailPrefab, firePoint.position, firePoint.rotation);
        Transform clone = Instantiate(muzzleFlashPrefab, firePoint.position, firePoint.rotation) as Transform;
        clone.parent = firePoint;
        float size = Random.Range(0.6f, 1.0f);
        clone.localScale = new Vector3(size, size, 1.0f);
        Destroy(clone.gameObject,0.02f);
    }
}
