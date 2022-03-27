using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DogukanKarabiyik.StackGame.Control {

    public class PlayerController : MonoBehaviour {

        [SerializeField]
        private float runnigSpeed = 5f;

        [SerializeField]
        private float movingSpeed = 5f;

        private Touch touch;
        private float deadZone = 0.8f;
        private float dragBoundary = 1.5f;
     
        public Rigidbody rb { get; private set; }
        public bool isMoving { get; set; } = false;

        private void Awake() {

            rb = GetComponent<Rigidbody>();
        }

        private void FixedUpdate() {

            if (isMoving) {

                rb.MovePosition(transform.position + (Vector3.forward * runnigSpeed * Time.fixedDeltaTime));
                          
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
            }
        }

        private void Update() {

            if (!isMoving) 
                if (Input.touchCount > 0) 
                    isMoving = true;
        }
    }
}

