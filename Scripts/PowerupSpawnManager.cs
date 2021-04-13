using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupSpawnManager : MonoBehaviour {
    public GameObject[] powerup;
    public GameObject[] spawnLocation;
    public int powerupAmount;
    float intervalPowerup;

    // Start is called before the first frame update
    void Start() {
        SpawnPowerup(powerupAmount);
    }

    // Update is called once per frame
    void Update() {
        intervalPowerup = FindObjectsOfType<SpawnTimePowerup>().Length;
        if (intervalPowerup <= 0){
            SpawnPowerup(powerupAmount);
        }
    }

    void SpawnPowerup(int powerupToSpawn) {
        for (int i = 0; i < powerupToSpawn; i++) {
        int powerupIndex = Random.Range(0, powerup.Length);
        int spawnIndex = Random.Range(0, spawnLocation.Length);
        GameObject newPowerup = Instantiate(powerup[powerupIndex], spawnLocation[spawnIndex].transform.position, 
        spawnLocation[spawnIndex].transform.rotation) as GameObject;
        } 
    }
}
