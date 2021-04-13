using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
    public TextMeshProUGUI gameOverText;
    public Button restartButton;
    public bool isGameActive;
    PlayerHealthManager playerHealthBar;

    void Start() {
        playerHealthBar = GameObject.Find("Player").GetComponent<PlayerHealthManager>();
    }

    public void Update() {
    
    }

    public void GameOver() {
        restartButton.gameObject.SetActive(true);
        gameOverText.gameObject.SetActive(true);
        playerHealthBar.gameObject.SetActive(false);
        isGameActive = false;
    }

    public void RestartGame() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
