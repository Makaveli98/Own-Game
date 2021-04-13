using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    float moveSpeed = 25f;
    public float ogMoveSpeed;
    float gravityModifier = 20f;
    int jumpForce;
    float healthUp = 1f;
    float invincibleTime = 6.0f;

    bool powerupLightning = false;
    bool powerupFire = false;
    bool powerupDiamond = false;
    bool powerupPotion = false;
    bool nuke = false;
    bool coroutineRunning;
    public bool isInvincible = false;

    Rigidbody rbPlayer;
    Vector3 moveInput;
    Vector3 moveVelocity;
    Camera mainCamera;
    BulletController bulletScript;
    Renderer renderr;
    Color originalColor;
    PlayerHealthManager healthScript;

    void Awake() {
        rbPlayer = GetComponent<Rigidbody>();
        mainCamera = FindObjectOfType<Camera>();
        renderr = GetComponent<Renderer>();
        healthScript = GameObject.Find("Player").GetComponent<PlayerHealthManager>();
    }
    // Start is called before the first frame update
    void Start() {
        originalColor = renderr.material.GetColor("_Color");
        Physics.gravity *= gravityModifier;
        ogMoveSpeed = moveSpeed;
    }

    // Update is called once per frame
    void Update() {
        moveInput = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical"));
        moveVelocity = moveInput * ogMoveSpeed;

        Ray cameraRay = mainCamera.ScreenPointToRay(Input.mousePosition);
        Plane groundPlane = new Plane(Vector3.up, Vector3.zero);
        float rayLenght;

        if(groundPlane.Raycast(cameraRay, out rayLenght)) {
            Vector3 pointToLook = cameraRay.GetPoint(rayLenght);
            // Debug.DrawLine(cameraRay.origin, pointToLook, Color.blue);
            transform.LookAt(new Vector3(pointToLook.x, transform.position.y, pointToLook.z));
        }
        if(Input.GetKeyDown(KeyCode.Space)) {
            rbPlayer.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }
    void FixedUpdate() {
        rbPlayer.velocity = moveVelocity;
    }
    
    public void SetInvincible() {
        isInvincible = true;
        Invoke("SetDamage", invincibleTime);
    }

    public void SetDamage() {
        isInvincible = false;
    }
    
    void OnTriggerEnter(Collider other) {
        //Lightning Powerup
        if (other.gameObject.tag == "Lightning") {
            powerupLightning = true;
            if (powerupLightning == true) {
                Destroy(other.gameObject);
                moveSpeed = 80f;
                renderr.material.SetColor("_Color", Color.black);
                StartCoroutine(LightingDuration());
            }
        }
        //Fire Powerup
        if (other.gameObject.tag == "Fire") {
            powerupFire = true;
            Destroy(other.gameObject);
            StartCoroutine(FireDuration());
        }

        //Diamond Powerup
        if (other.gameObject.tag == "Diamond") {
            powerupDiamond = true;
            if (powerupDiamond == true) {
                Destroy(other.gameObject);
                SetInvincible();
            }
        }
        //Potion Powerup
        if (other.gameObject.tag == "Potion") {
            powerupPotion = true;
            Destroy(other.gameObject);
            if (powerupPotion == true) {
                if (healthScript.currentHealth < healthScript.startingHealth) {
                healthScript.currentHealth += (int)healthUp;
                healthScript.healthBar.SetHealth(healthScript.currentHealth);
                }
                StartCoroutine(PotionDuration());

            }
        }
        //Nuke Powerup
        if (other.gameObject.tag == "Nuke") {
            nuke = true;
            Destroy(other.gameObject);
            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
            if (nuke == true) {
                for (int i = 0; i < enemies.Length; i++) {
                    Destroy(enemies[i]);
                }
            }
        }
        //Walk On Lava
        if (other.gameObject.tag == "Lava") {
            if(!powerupFire) {
                if (!coroutineRunning) {
                    StartCoroutine(BeingDMGed());
                }
            } 
        }
    
    }

    //The Duration For The Potion Powerup
    IEnumerator PotionDuration() {
        yield return new WaitForSeconds((float)0.5f);
        powerupPotion = false;
    }
    //The Duration For The Fire Powerup
    IEnumerator FireDuration() {
        yield return new WaitForSeconds(10);
        powerupFire = false;
    }
    IEnumerator BeingDMGed() {
        coroutineRunning = true;
        yield return new WaitForSeconds((float)0.5f);
        healthScript.currentHealth -= (int)healthUp;
        healthScript.healthBar.SetHealth(healthScript.currentHealth);
        coroutineRunning = false;
    }
    IEnumerator LightingDuration() {
        yield return new WaitForSeconds(10);
        powerupLightning = false;
        moveSpeed = ogMoveSpeed;
    }
}
