using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour {
    public float speed = 50f;
    public float lifeTime;
    public int damageToGive;
    Rigidbody rbBullet;

    // Start is called before the first frame update
    void Awake() {
        rbBullet = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update() {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        lifeTime -= Time.deltaTime;
        if(lifeTime <= 0) {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Enemy") {
            other.gameObject.GetComponent<EnemyHealthManager>().HurtEnemy(damageToGive);
            Destroy(gameObject);
        }
        if (other.gameObject.tag == "Barrier") {
            Destroy(gameObject);
        }
        if (other.gameObject.tag == "Building") {
            Destroy(gameObject);
        }
        if (other.gameObject.tag == "Spool") {
            Destroy(gameObject);
        }
        if (other.gameObject.tag == "Rock") {
            Destroy(gameObject);
        }
        if (other.gameObject.tag == "Barrel") {
            Destroy(gameObject);
        }
        if (other.gameObject.tag == "Stair") {
            Destroy(gameObject);
        }
        if (other.gameObject.tag == "Crate") {
            Destroy(gameObject);
        }
    }
}
