using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DogukanKarabiyik.StackGame.Environment.Collectibles {
    
    public class CollectibleBehaviour : MonoBehaviour {

        [SerializeField]
        private Transform destination;

        private bool isTouched = false;
        private Vector3 destinationVector;

        private void Start() {

            destinationVector = new Vector3(destination.localPosition.x, destination.localPosition.y, destination.localPosition.z);
        }
    

        private void Update() {

            if (isTouched)
                transform.localPosition = Vector3.Lerp(transform.localPosition, destinationVector, 8f * Time.deltaTime);
        }

        
        private void OnTriggerEnter(Collider other) {

            if (other.tag == "Player") {
                
                isTouched = true;
                transform.parent = other.transform.GetChild(2).transform;
            }
        }
    }
}


