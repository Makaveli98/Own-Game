// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class Player : MonoBehaviour {
//     float movementX;
//     float movementZ;
//     float mousePosX;
//     float mousePosY;
//     public float movementSpeed = 10f; 
//     public float rotationSpeed = 2f;

//     // Start is called before the first frame update
//     void Start() {
     
//     }

//     // Update is called once per frame
//     void Update() {
//         PlayerMovement();
//     }

//     void PlayerMovement() {
//         movementX = Input.GetAxis("Horizontal");
//         movementZ = Input.GetAxis("Vertical");
//         // mousePosX = Input.GetAxis("Mouse X");
//         mousePosY = Input.GetAxis("Mouse Y");
   
//         transform.Translate(Vector3.right * movementX * movementSpeed * Time.deltaTime);
//         transform.Translate(Vector3.forward * movementZ * movementSpeed * Time.deltaTime);

//         // transform.rotation *= Quaternion.Slerp(Quaternion.identity, Quaternion.LookRotation(mousePosX < 0 ? Vector3.left : Vector3.right), Mathf.Abs(mousePosX) * rotationSpeed * Time.deltaTime);
//         transform.rotation *= Quaternion.Slerp(Quaternion.identity, Quaternion.LookRotation(mousePosY < 0 ? Vector3.back : Vector3.forward), Mathf.Abs(mousePosY) * rotationSpeed * Time.deltaTime);



//         if (transform.position.x < -49) {
//             transform.position = new Vector3(-49, transform.position.y, transform.position.z);
//         } else if (transform.position.x > 49) {
//             transform.position = new Vector3(49, transform.position.y, transform.position.z);
//         }
//         if (transform.position.z < -49) {
//             transform.position = new Vector3(transform.position.x, transform.position.y, -49);
//         } else if (transform.position.z > 49) {
//             transform.position = new Vector3(transform.position.x, transform.position.y, 49); 
//         }

//     }
// }
