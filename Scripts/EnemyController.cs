using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {
    // Rigidbody rbEnemy;
    UnityEngine.AI.NavMeshAgent nav;
    // public float moveSpeed;
    private PlayerController thePlayer;
    // Start is called before the first frame update
    void Start() {
        // rbEnemy = GetComponent<Rigidbody>();
        nav = GetComponent<UnityEngine.AI.NavMeshAgent>();
        thePlayer = FindObjectOfType<PlayerController>();
    }

    void FixedUpdate() {
        // rbEnemy.velocity = (transform.forward * moveSpeed);
    }

    // Update is called once per frame
    void Update() {
        nav.SetDestination(thePlayer.transform.position);
        transform.LookAt(thePlayer.transform.position);

    }
}

