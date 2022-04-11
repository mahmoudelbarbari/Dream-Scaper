using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    public int health = 6;
    public int lives = 3;
    public float flickerDuration = 0.1f;
    public float flickerTime = 0f;
    private SpriteRenderer spriteRenderer;
    public bool isImmune = false;
    public float immunityDuaration = 1.5f;
    public float immunityTime = 0f;
    public int coinsCollected = 0;

    public Slider healthUI;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = this.gameObject.GetComponent<SpriteRenderer>();
        
    }
    public void CollectCoins(int coinValue)
    {
        coinsCollected = coinsCollected + coinValue;
    }

    // Update is called once per frame
    void Update()
    {
        healthUI.value = health;

        if (this.isImmune == true)
        {
            SpriteFlicker();
            immunityTime = immunityTime + Time.deltaTime;
            if (immunityTime >= immunityDuaration)
            {
                this.isImmune = false;
                this.spriteRenderer.enabled = true;
            }
        }

    }

    public void TakeDamage(int damage)
    {
        if(this.isImmune == false)
        {
            this.health = this.health - damage;
            if(this.health < 0f)
                this.health = 0;
            if(this.lives > 0f && this.health == 0f)
            {
                FindObjectOfType<LevelManager>().RespawnPlayer();
                this.health = 6;
                this.lives--;
            }
            else if(this.lives > 0 && this.health == 0)
            {
                Debug.Log("Gameover");
                Destroy(this.gameObject);
            }

            Debug.Log("Player Health:"+this.health.ToString());
            Debug.Log("Player Lives:" +this.lives.ToString());
        }
        PlayerHitReaction();
    }

    void PlayerHitReaction()
    {
        this.isImmune = true;
        this.immunityTime = 0f;
    }

    void SpriteFlicker()
    {
        if(this.flickerTime < this.flickerDuration)
        {
            this.flickerTime = this.flickerTime + Time.deltaTime;
        }
        else if(this.flickerTime >= this.flickerDuration)
        {
            spriteRenderer.enabled = !(spriteRenderer.enabled);
            this.flickerTime = 0;
        }

    }
}
