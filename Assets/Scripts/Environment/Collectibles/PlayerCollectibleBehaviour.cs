using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DogukanKarabiyik.StackGame.Environment.Collectibles {
   
    public class PlayerCollectibleBehaviour : MonoBehaviour {


        private Vector3 playerVector;
        public bool isTouched { get; private set; } = false;


        private void Update() {

            //if (isTouched)
            //    transform.Translate(playerVector);
        }


        private void OnTriggerEnter(Collider other) {

            if (other.tag == "Player") {

                playerVector = other.transform.localPosition;
                other.transform.position = new Vector3(other.transform.position.x, other.transform.localScale.y, other.transform.position.z);
                other.transform.rotation = Quaternion.identity;
                transform.parent = other.transform.GetChild(0).transform;
                gameObject.tag = "Player";
                isTouched = true;
            }
        }
    }
}

   
