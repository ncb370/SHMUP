using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{

    [SerializeField] private float lifeTime = 5.0f;
    [SerializeField] private float moveSpeed = 30.0f;
    [SerializeField] public float damage = 50.0f;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(this.gameObject, lifeTime);
    }

    // Update is called once per frame
    void Update()
    {
        MoveProjectile();
    }

    private void MoveProjectile()
    {
   
        transform.position += transform.forward * moveSpeed * Time.deltaTime;
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.transform.tag == "Enemy")
        {
            Debug.Log("Enemy destroyed");
            other.GetComponent<Enemy>().TakeDamage(damage);
            Debug.Log(damage);
            Destroy(this.gameObject);
        }
    }
}
