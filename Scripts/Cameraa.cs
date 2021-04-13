using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cameraa : MonoBehaviour {
    public GameObject player;
    public Vector3 cameraPos = new Vector3(-7, 20, -46.5f);
    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        transform.position = player.transform.position + cameraPos;
    }
}
