using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;

    public GameObject player;
    public GameObject spawner;
    public Canvas shopCanvas;
    public GameObject projectile;
    public Canvas reviveCanvas;
    public Canvas powerUpCanvas;

    // Score variables
    public Text scoreText;
    private int score = 0;

    // Coin variables
    public Text coinText;
    private int coinAmount;

    //Display canvas
    public bool showCanvas = false;

    // Starting scene
    private Scene scene;

    // Pop up variables
    //private Text revive;
    //private Text powerUp;aad   
    //private float rTimer;
    private float puTimer;
    //private Color rColor;
    private Color puColor;

    // ReviveText
    public Text reviveText;
    float r = 0.09811318f, g = 1.0f, b = 0.1212814f;
    float a;

    //PowerUpText
    public Text powerUpText;
    float pr = 0.8679245f, pg = 0.2195839f, pb = 0.06059093f;
    float pa;

    // Button effects
    //[SerializeField] private GameObject reviveEffect;
    //[SerializeField] private GameObject powerupEffect;


    void Start()
    {
        float a = 0.0f;
        float pa = 0.0f;
        SetScoreText();
        SetCoinText();
        projectile.GetComponent<Projectile>().damage = 50.0f;
        reviveText.color = new Color(r, g, b, a);
        powerUpText.color = new Color(pr, pg, pb, pa);
        //rTimer = 1f;
    }

    void Update()
    {
        
        // If player is destroyed restart scene
        if (player.GetComponent<Player>().isDestroyed)
        {
            Destroy(player.GetComponent<Player>());
            Debug.Log("yeeted");
            Debug.Log("Player is null");
            SceneManager.LoadScene("RealSHMUPPY");
        }



        if (score >= 10)
        {
            showCanvas = true;
            shopCanvas.gameObject.SetActive(showCanvas);
            reviveCanvas.gameObject.SetActive(showCanvas);
            powerUpCanvas.gameObject.SetActive(showCanvas);
            PauseGame();
        }

        if (showCanvas == true && a > 0.0f)
        {
            StartCoroutine(FadeTextToZeroAlpha(1f, reviveText.GetComponent<Text>()));
            a = 0.0f;
        }

        if (showCanvas == true && pa > 0.0f)
        {
            StartCoroutine(FadeTextToZeroAlpha(1f, powerUpText.GetComponent<Text>()));
            pa = 0.0f;
        }
        
        if (score <= 0)
        { 
            showCanvas = false;
            shopCanvas.gameObject.SetActive(showCanvas);
            reviveCanvas.gameObject.SetActive(showCanvas);
            powerUpCanvas.gameObject.SetActive(showCanvas);
            ResumeGame();
        }

        //if (reviveText.GetComponent<Text>().color.a > 0.0f)
        //{
        //    {
        //        a -= 0.001f;
        //    }
        //}


    }

    void PauseGame()
    {
        Time.timeScale = 0;
    }

    void ResumeGame()
    {
        Time.timeScale = 1;
    }

    // Display Score
    void SetScoreText()
    {
        scoreText.text = "Score: " + score.ToString();
    }

    // Display Coins
    void SetCoinText()
    {
        coinText.text = "Coins: " + coinAmount.ToString();
    }

    public void AddPoints(int scoreToAdd)
    {
        score += scoreToAdd;
        Debug.Log(score);
        //SetScoreText();
    }

    public void UpgradePower()
    {
        if (coinAmount >= 3)
        {
            projectile.GetComponent<Projectile>().damage += 10;
            //GameObject effect = Instantiate(powerupEffect, transform.position, transform.rotation);
            AddCoins(-3);
            pa = 1.0f;
            //PowerUp();
            //score = 0;
        }
    }

    public void IncreaseHealth()
    {
        if (coinAmount >= 2)
        {
            player.GetComponent<Player>().health = player.GetComponent<Player>().maxHealth;
            //GameObject effect = Instantiate(reviveEffect, transform.position, transform.rotation);
            AddCoins(-2);
            //Revive();
            a = 1.0f;
            //score = 0;
        }
    }

    // Make AddCoins function
    public void AddCoins(int coinsToAdd)
    {
        coinAmount += coinsToAdd;
        Debug.Log(coinAmount);
        SetCoinText();
    }

    public IEnumerator FadeTextToZeroAlpha(float t, Text i)
    {
        i.color = new Color(i.color.r, i.color.g, i.color.b, 1);
        while (i.color.a > 0.0f)
        {
            i.color = new Color(i.color.r, i.color.g, i.color.b, i.color.a - (Time.unscaledDeltaTime / t));
            yield return null;
        }
    }

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            scene = SceneManager.GetActiveScene();
            Debug.Log("Scene name: " + scene.name);
        }

        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    public void SetParent()
    {
        //revive.transform.SetParent(shopCanvas.transform);
    }

    public void Revive()
    {
        //a = 1.0f;
        //reviveText.GetComponent<Text>().color.a = 1.0f;
        //Instantiate(revive, transform.position, transform.rotation);
        //revive.transform.SetParent(shopCanvas.transform);

        //revive = shopCanvas.gameObject.AddComponent(typeof(Text)) as Text;



        //UnityEngineInternal.APIUpdaterRuntimeServices.AddComponent(shopCanvas.gameObject, "Assets/Scripts/GameManager.cs (162,9)", revive.text);

        //rColor = revive.color;
        //rTimer = 100f;
        //float rDisappear = 3f;
        //while (rTimer < 0)
        //{
        //    rColor.a -= rDisappear * rTimer;
        //    revive.color = rColor;
        //    rTimer -= 1f;
        //    if (rColor.a < 0)
        //    {
        //        Destroy(revive);
        //    }
        //}
    }

    //private void PowerUp()
    //{
    //    Instantiate(powerUp, transform.position, transform.rotation);
    //}

}
