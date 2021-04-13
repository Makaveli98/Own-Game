using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NukeScript : MonoBehaviour {
    public GameObject nuke;
    public Transform[] spawnLoc;
    float intervalNuke;
    public int nukeAmount;
    public float sphereRadius;


    void Update () {
        intervalNuke = FindObjectsOfType<SpawnTimeNuke>().Length;
        if (intervalNuke <= 0) {
            SpawnNuke(nukeAmount);   
        }
    }


    void SpawnNuke (int nukeToSpawn) {
        for (int i = 0; i < nukeToSpawn; i++) {
            int spawnIndexNuke = Random.Range(0, spawnLoc.Length);
            GameObject newNuke = Instantiate(nuke, spawnLoc[spawnIndexNuke].transform.position, 
            spawnLoc[spawnIndexNuke].transform.rotation) as GameObject;   
        }
    }

    // IEnumerator TimeBeforeNewSpawn() {
    //     yield

    // }
}
