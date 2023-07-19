using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    // Default Enemy stats
    [SerializeField] private float moveSpeed = 15.0f;
    [SerializeField] public float health = 100.0f;

    [SerializeField] private float damageToPlayer = 20.0f;
    [SerializeField] private float damageRate = 0.2f;
    [SerializeField] private float damageTime;

    public GameObject deathEffect;

    // Make it drop a coin
    [SerializeField] private GameObject droppedCoin;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Awake()
    {
        health = GameManager.instance.spawner.GetComponent<EnemySpawner>().updatedHealth;
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        
    }



    private void Movement()
    {
        if (GameManager.instance.player) //null reference check
        {
            transform.LookAt(GameManager.instance.player.transform.position); //Look at the player
            transform.position += transform.forward * moveSpeed * Time.deltaTime;
        }
    }



    public void TakeDamage(float damage)
    {
        Debug.Log(health);
        health -= damage;

        if (health <= 0)
        {
            GameObject effect = Instantiate(deathEffect, transform.position, transform.rotation);
            Instantiate(droppedCoin, transform.position, transform.rotation);
            Destroy(effect, 1.0f);
            Destroy(this.gameObject);
            GameManager.instance.AddPoints(1);
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.transform.tag == "Player" && Time.time > damageTime)
        {
            other.transform.GetComponent<Player>().TakeDamage(damageToPlayer);
            damageTime = Time.time + damageRate;
        }
    }
}
