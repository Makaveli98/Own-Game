using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTimeNuke : MonoBehaviour {
    public float nukeInterval; 

    void Update() {
        if (nukeInterval > 0) {
            nukeInterval -=  Time.deltaTime;
        } else {
            // enabled = false;
            Destroy(gameObject);
        } 
    }
}
