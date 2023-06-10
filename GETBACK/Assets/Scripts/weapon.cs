using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class weapon : MonoBehaviour
{
    public Transform target;
    private bool isFlipped = false;

    public GameObject bulletPrefab;
   
    public Transform spawnPoint;
    public int bulletSpeed;

    public int currentAmmo, maxAmmo, clipSize;
    public float reloadTime = 2f;
    private bool isReloading = false;

    public float fireDelta = 0.5F;

    private float nextFire = 0.5F;
    private GameObject newProjectile;
    private float myTime = 0.0F;

    public Slider mainSlider;


    void Start()
    {
        mainSlider.gameObject.SetActive(false); 
        
    }

    void Update()
    {

        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 direction = mousePos - transform.position;
        direction.Normalize();

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // Rotate gun
        if (Mathf.Abs(angle) > 90f)
        {
            if (!isFlipped)
            {
                isFlipped = true;
                transform.localScale = new Vector3(transform.localScale.x, -transform.localScale.y, transform.localScale.z);
            }
        }
        else
        {
            if (isFlipped)
            {
                isFlipped = false;
                transform.localScale = new Vector3(transform.localScale.x, Mathf.Abs(transform.localScale.y), transform.localScale.z);
            }
        }

        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        // Shoot bullet
        myTime = myTime + Time.deltaTime;

        if (Input.GetButton("Fire1") && myTime > nextFire && currentAmmo > 0 && isReloading == false)
        {
            nextFire = myTime + fireDelta;
            Shoot();

            nextFire = nextFire - myTime;
            myTime = 0.0F;
            currentAmmo -= 1;

        }

        // Reload
        if (currentAmmo == 0 && maxAmmo > 0)
        {
            Reload();
        }
    }

      


    void Shoot()
    {
        // Instantiate the bullet prefab at the spawn point
        GameObject bullet = Instantiate(bulletPrefab, spawnPoint.position, spawnPoint.rotation);

        // Get the Rigidbody2D component of the bullet
        Rigidbody2D bulletRigidbody = bullet.GetComponent<Rigidbody2D>();

        // Apply an initial velocity to the bullet in the forward direction
        bulletRigidbody.velocity = spawnPoint.right * bulletSpeed; // Adjust bulletSpeed as needed
    }


    void Reload()
    {
        isReloading = true;
        reloadTime -= Time.deltaTime;
        mainSlider.value += Time.deltaTime;
        mainSlider.gameObject.SetActive(true);

        if (reloadTime <= 0)
        {
            currentAmmo = clipSize;
            maxAmmo -= clipSize;
            isReloading = false;
            reloadTime = 1f;
            mainSlider.value = 0;
            mainSlider.gameObject.SetActive(false);

        }
    }


}
