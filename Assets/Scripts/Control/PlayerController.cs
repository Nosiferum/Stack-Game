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

        [SerializeField]
        public List<Transform> clothDestinations  = new List<Transform>();

        private Touch touch;
        private float deadZone = 0.8f;
        private float dragBoundary = 1.5f;
        private Vector3 eulerAngleVelocity;
       
        public int freeSpace { get; set; } = 0;
        public int maxFreeSpace { get; private set; } = 4;
        public Rigidbody rb { get; private set; }
        public bool isMoving { get; set; } = false;
        
        private void Awake() {

            rb = GetComponent<Rigidbody>();        
        }

        private void Start() {
            
            eulerAngleVelocity = new Vector3(0, rotatingSpeed, 0);
        }

        private void FixedUpdate() {

            if (isMoving) {

                rb.MovePosition(transform.position + (Vector3.forward * runnigSpeed * Time.fixedDeltaTime));

                //Quaternion deltaRotation = Quaternion.Euler(eulerAngleVelocity * Time.fixedDeltaTime);
                //rotatingRigidBody.MoveRotation(rb.rotation * deltaRotation);

                //physics based rotation discarded due to design and camera constraints
                transform.GetChild(0).Rotate(Vector3.up * rotatingSpeed * Time.deltaTime);

                //transform.GetChild(2).Rotate(Vector3.up * rotatingSpeed * Time.deltaTime);

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

