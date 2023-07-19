using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{

    [SerializeField] private float moveSpeed = 10.0f;
    [SerializeField] private float coinValue = 1.0f;

    private bool isTriggered = false;
    public bool wasAbsorbed = false;

    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //transform.position = Vector3.MoveTowards(transform.position, GameManager.instance.player.transform.position, Time.deltaTime * moveSpeed); 
        
        
        if (Vector3.Distance(transform.position, GameManager.instance.player.transform.position) < .1f)
        {
            GameManager.instance.player.GetComponent<Player>().GetCoin(coinValue);
            GameManager.instance.AddCoins((int)coinValue);
            Destroy(this.gameObject);
        }
        
        if (isTriggered==true)
        {
            Debug.Log("movement triggered");
            Movement();
            
        }



        if (wasAbsorbed)
        {
            Destroy(this.gameObject);
        }
        // Movement();
        //if (this.transform.position.x == GameManager.instance.player.transform.position.x)
        //{
        //    GameManager.instance.player.GetComponent<Player>().GetCoin(coinValue);
        //    GameManager.instance.AddCoins((int)coinValue);
        //    Destroy(this.gameObject);
        //}


    }

    private void Movement()
    {
        if (GameManager.instance.player) //null reference check
        {
            //Debug.Log("spaghett");
            //transform.LookAt(GameManager.instance.player.transform.position); //Look at the player
            //transform.position += transform.forward * moveSpeed * Time.deltaTime;

            transform.position = Vector3.MoveTowards(transform.position, GameManager.instance.player.transform.position, Time.deltaTime * moveSpeed);
        }
       
    }

    //void OnTriggerEnter(Collider other)
    //{
    //    Collider colliderA = GetComponent<BoxCollider>();

    //    if (other.transform.tag == "Player")
    //    {
    //        //if (GetComponent<Collider>().GetType() == typeof(SphereCollider)) print("Sphere");
    //        if (this.GetComponent<Collider>().GetType() == colliderA.GetType())
    //        {
    //            Debug.Log("BoxCollider Hit");
    //            other.GetComponent<Player>().GetCoin(coinValue);
    //            GameManager.instance.AddCoins((int)coinValue);
    //            Destroy(this.gameObject);
    //        }
    //    }
    //}

    void OnTriggerStay(Collider other)
    {

        Collider colliderB = GetComponent<SphereCollider>();

        if (other.transform.tag == "Player")
        {
            isTriggered = true;

            /* if (other.GetComponent<Collider>().GetType() == typeof(SphereCollider)) print("Sphere");
            {
                isTriggered = true;
                Debug.Log("Sphere triggered");
                Debug.Log(isTriggered);
            } */
            //if (GetComponent<Collider>().GetType() == typeof(BoxCollider)) print("Box");
            //{
            //    Debug.Log("Box triggered");
            //    other.GetComponent<Player>().GetCoin(coinValue);
            //    GameManager.instance.AddCoins((int)coinValue);
            //    Destroy(this.gameObject);
            //}
            
            //if (this.GetComponent<Collider>().GetType() == colliderA.GetType())
            //{
            //    Debug.Log("Box triggered");
            //    other.GetComponent<Player>().GetCoin(coinValue);
            //    GameManager.instance.AddCoins((int)coinValue);
            //    Destroy(this.gameObject);
            //}

            if (this.GetComponent<Collider>().GetType() == colliderB.GetType())
            {
                Debug.Log("Sphere triggered");
               
                //Movement();
                //if (this.transform.position == GameManager.instance.player.transform.position)
                //{
                //    other.GetComponent<Player>().GetCoin(coinValue);
                //    GameManager.instance.AddCoins((int)coinValue);
                //    Destroy(this.gameObject);
                //}
            }
        }
    }

    /*void OnCollisionEnter(Collision collision)
    {
        if (collision.contacts[0])
        {
            Debug.Log("Collision Enter");
        }
    }*/

    // AddForce



}
