using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthManager : MonoBehaviour {
    public int startingHealth;
    public int currentHealth;

    public float flashLenght = 0.2f;
    public float flashCounter;

    Renderer render;
    Color ogColor;
    GameManager gameManager;

    public HealthBar healthBar;

    void Awake() {
        gameManager = GameObject.Find("Game_Manager").GetComponent<GameManager>();
    }
    // Start is called before the first frame update
    void Start() {
        currentHealth = startingHealth;
        healthBar.SetMaxHealth(currentHealth);
        render = GetComponent<Renderer>();
        ogColor = render.material.GetColor("_Color");
    }

    // Update is called once per frame
    void Update() {
        if(currentHealth <= 0) {
            gameObject.SetActive(false);
            gameManager.GameOver();
        }
        if(flashCounter > 0) {
            flashCounter -= Time.deltaTime;
            if(flashCounter <= 0) {
                render.material.SetColor("_Color", Color.white);
            }
        }
    }

    public void HurtPlayer(int damageAmount) {
        currentHealth -= damageAmount;
        healthBar.SetHealth(currentHealth);
        flashCounter = flashLenght;
        render.material.SetColor("_Color", Color.red);
    }
}
