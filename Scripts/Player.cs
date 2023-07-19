using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField] private float moveSpeed = 5.0f;

    [SerializeField] private float rotateSpeed = 360.0f;
    private Vector3 position;

    [SerializeField] private Vector3 _rotation;


    [SerializeField] public float health = 100.0f;
    [SerializeField] public float maxHealth = 100.0f;
    

    // Coins
    [SerializeField] public float coins;
    //[SerializeField] private float coinValue = 1.0f;

    public GameObject deathEffect;

    public bool isDestroyed = false;
    public bool coinAbsorbed = false;


    // Update is called once per frame
    void Update()
    {
        MovePlayer();

    }

    // Player Input Controls
    private void MovePlayer()
    {
        // Forward & Backward Movement
        if (Input.GetKey(KeyCode.W)) transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
        if (Input.GetKey(KeyCode.S)) transform.Translate(Vector3.back * moveSpeed * Time.deltaTime);

        // Left and Right Rotation
        if (Input.GetKey(KeyCode.D)) _rotation = Vector3.up;
        else if (Input.GetKey(KeyCode.A)) _rotation = Vector3.down;
        else _rotation = Vector3.zero;
        transform.Rotate(_rotation * rotateSpeed * Time.deltaTime);
    }


    public void SpendCoin(float coin)
    {
        coins -= coin;
    }

    public void CoinRevive()
    {
        if (coins > 1 && health < maxHealth)
        {
            SpendCoin(2);
            health = maxHealth;
        }
    }



    public void TakeDamage(float damage)
    {
        health -= damage;

        if (health <= 0)
        {
            GameObject effect = Instantiate(deathEffect, transform.position, transform.rotation);
            Destroy(effect, 1.0f);
            Debug.Log("about to get destroyed");
            isDestroyed = true;
            // Destroy(this.gameObject);
        }
    }



    // Add GetCoin function based off of TakeDamage
    public void GetCoin(float coin)
    {
        coins += coin;

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Coin")
        {
            //this.GetCoin(coinValue);
            //GameManager.instance.AddCoins((int)coinValue);
            //Destroy(other.gameObject);
            //other.gameObject.GetComponent<Coin>().wasAbsorbed = true;
        }
        //coinAbsorbed = false;

        if (other.transform.tag == "Enemy")
        {
            other.GetComponent<Enemy>().TakeDamage(other.GetComponent<Enemy>().health);
        }
    }


}
