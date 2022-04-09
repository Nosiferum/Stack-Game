using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DogukanKarabiyik.StackGame.Control {

    public class PlayerController : MonoBehaviour {

        [SerializeField]
        private float runnigSpeed = 5f;

        [SerializeField]
        private float movingSpeed = 5f;

        [SerializeField]
        private float rotatingSpeed = 50f;
       
        private Touch touch;
        private float deadZone = 0.8f;
        private float dragBoundary = 1.5f;
                  
        public Rigidbody rb { get; private set; }
        public bool isMoving { get; set; } = false;
        public bool isWon { get; set; } = false;
        
        private void Awake() {

            rb = GetComponent<Rigidbody>();        
        }
        
        private void FixedUpdate() {

            if (isMoving && gameObject.tag == "Player") {

                rb.MovePosition(transform.position + (Vector3.forward * runnigSpeed * Time.fixedDeltaTime));
               
                //physics based rotation discarded due to design and camera constraints
                transform.GetChild(1).Rotate(Vector3.up * rotatingSpeed * Time.deltaTime);
             
                if (Input.touchCount > 0) {

                    touch = Input.GetTouch(0);
                 
                    if (Input.GetTouch(0).phase == TouchPhase.Moved) {

                        if (touch.deltaPosition.x > deadZone) {

                            Vector3 rightVector = new Vector3(touch.deltaPosition.x - deadZone, 0, 0);

                            if (touch.deltaPosition.x > dragBoundary)
                                rightVector = new Vector3(dragBoundary, 0, 0);

                            rb.MovePosition(transform.position + (Vector3.forward * runnigSpeed * Time.fixedDeltaTime) + (rightVector * movingSpeed * Time.fixedDeltaTime));
                        }
                            
                        else if (touch.deltaPosition.x < -deadZone) {

                            Vector3 leftVector = new Vector3(touch.deltaPosition.x + deadZone, 0, 0);

                            if (touch.deltaPosition.x < -dragBoundary)
                                leftVector = new Vector3(-dragBoundary, 0, 0);

                            rb.MovePosition(transform.position + (Vector3.forward * runnigSpeed * Time.fixedDeltaTime) + (leftVector * movingSpeed * Time.fixedDeltaTime));
                        }                                                 
                    }
                }

                else if (Input.GetKey(KeyCode.Mouse1))
                    rb.MovePosition(transform.position + (Vector3.forward * runnigSpeed * Time.fixedDeltaTime) + (Vector3.right * movingSpeed * Time.fixedDeltaTime));

                else if (Input.GetKey(KeyCode.Mouse0))
                    rb.MovePosition(transform.position + (Vector3.forward * runnigSpeed * Time.fixedDeltaTime) + (Vector3.left * movingSpeed * Time.fixedDeltaTime));
            }
        }

        private void Update() {

            if (!isMoving && !isWon) 
                if (Input.touchCount > 0 || Input.GetKey(KeyCode.Mouse0)) 
                    isMoving = true;
        }
    }
}

