using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class EnemySpawnManager : MonoBehaviour {
    public GameObject[] enemies;
    public GameObject[] spawnLocation;
    int enemyCounter;
    int enemiesAmount = 20;
    int waveCounter = 1;
    TextMeshProUGUI waveText;
    TextMeshProUGUI enemyCountText;

    void Awake() {
        waveText = GameObject.Find("Wave_Counter").GetComponent<TextMeshProUGUI>();
        enemyCountText = GameObject.Find("Enemy_Counter").GetComponent<TextMeshProUGUI>();
    }
    // Start is called before the first frame update
    void Start() {
        SpawnEnemy(enemiesAmount);
    }

    // Update is called once per frame
    void Update() {
        enemyCounter = FindObjectsOfType<EnemyController>().Length;
        if (enemyCounter <= 0) {
            enemiesAmount += 10;
            waveCounter ++; 
            SpawnEnemy(enemiesAmount);
        } 
        waveText.text = "Wave: " + waveCounter;
        enemyCountText.text = "Enemies: " + enemyCounter;
    }

    public void SpawnEnemy(int enemiesToSpawn) {
        for (int i = 0; i < enemiesToSpawn; i++) {
            int enemyIndex = Random.Range(0, enemies.Length);
            int spawnIndex = Random.Range(0, spawnLocation.Length);
            GameObject newEnemy = Instantiate(enemies[enemyIndex], 
            spawnLocation[spawnIndex].transform.position, 
            spawnLocation[spawnIndex].transform.rotation) as GameObject;
        }
    }

    // changes
}
