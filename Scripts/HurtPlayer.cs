using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtPlayer : MonoBehaviour {
    public int damageToGive;
    PlayerController setPlayerInvincible;

    public void Start() {
        setPlayerInvincible = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    public void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "Player") {
            if(!setPlayerInvincible.isInvincible) {
                other.gameObject.GetComponent<PlayerHealthManager>().HurtPlayer(damageToGive);
            }
        }
    }  
}
