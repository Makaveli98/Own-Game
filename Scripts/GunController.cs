using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour {
    public bool isFiring;
    public BulletController bullet;
    // Rigidbody rbBullet;
    public float bulletSpeed;
    // float bulletForce = 20f;
    public float timeBetweenShots;
    private float shotCounter;
    public Transform firePoint;
    // Start is called before the first frame update
    void AWake() {
        // rbBullet = GameObject.FindGameObjectWithTag("Bullet").GetComponent<Rigidbody>();
    }
    void Start() {
        isFiring = true;
    }

    // Update is called once per frame
    void Update() {
        if(Input.GetMouseButton(0) && isFiring) {
            isFiring = false;
            BulletController newBullet = Instantiate(bullet, firePoint.position, firePoint.rotation) as BulletController;
            newBullet.speed = bulletSpeed;
            // rbBullet.AddForce(Vector3.forward * bulletForce, ForceMode.Impulse);
            StartCoroutine(CooldownShots());
        }
    }

    IEnumerator CooldownShots() {
        yield return new WaitForSeconds(timeBetweenShots);
        isFiring = true;
    }
}
