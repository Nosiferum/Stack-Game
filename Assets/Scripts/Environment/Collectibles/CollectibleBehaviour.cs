using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DogukanKarabiyik.StackGame.Control;

namespace DogukanKarabiyik.StackGame.Environment.Collectibles {
    
    public class CollectibleBehaviour : MonoBehaviour {

        [SerializeField]
        private Transform destination;

        private bool isTouched = false;
        private Vector3 destinationVector;
        private float lerpTime = 8f;
                      
        private void Start() {

            //  destinationVector = new Vector3(destination.localPosition.x, destination.localPosition.y, destination.localPosition.z);
          
        }
    
        private void Update() {

            if (isTouched) 
                transform.localPosition = Vector3.Lerp(transform.localPosition, destinationVector, lerpTime * Time.deltaTime);          
        }

        
        private void OnTriggerEnter(Collider other) {

            if (other.tag == "Player") {
                                                          
                if (other.GetComponent<ClothManager>().freeSpaceIndex < other.GetComponent<ClothManager>().maxFreeSpace) {

                    transform.parent = other.transform.GetChild(2).transform;
                    Transform destinationTrasform = other.GetComponent<ClothManager>().clothDestinations[other.GetComponent<ClothManager>().freeSpaceIndex++];
                    destinationVector = new Vector3(destinationTrasform.localPosition.x, destinationTrasform.localPosition.y, destinationTrasform.localPosition.z);
                    isTouched = true;
                }             
            }
        }
    }
}


