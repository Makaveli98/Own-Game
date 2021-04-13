using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lava : MonoBehaviour {
    public GameObject[] lava;
    public Transform[] lavaPos;
    int lavaAmount = 6;
    // Start is called before the first frame update
    void Start() {
        LavaGround(lavaAmount);
        // for (int i = 0; i < length; i++) {
        //     int lavaPosIndex = Random.Range(0, lavaPos.Length);
        //     int lavaIndex = Random.Range(0, lava.Length);
        //     GameObject newLava = Instantiate(lava[lavaIndex],
        //     lavaPos[lavaPosIndex].transform.position,
        //     lavaPos[lavaPosIndex].transform.rotation) as GameObject;
        // } 
    }
    void LavaGround(int lavaa) {
            for (int i = 0; i < lavaa; i++) {
            int lavaPosIndex = Random.Range(0, lavaPos.Length);
            int lavaIndex = Random.Range(0, lava.Length);
            GameObject newLava = Instantiate(lava[lavaIndex],
            lavaPos[lavaPosIndex].transform.position,
            lavaPos[lavaPosIndex].transform.rotation) as GameObject;
        } 
        
    }
}
