using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] private GameObject projectile;
    [SerializeField] private float fireRate = 0.1f;
    private float fireTime;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Shoot();
    }

    private void Shoot()
    {
        if (Input.GetKey(KeyCode.Space) && Time.time >= fireTime)
        {
            Instantiate(projectile, transform.position, transform.rotation);
            fireTime = Time.time + fireRate; // Set your rate cooldown
        }
    }
}
