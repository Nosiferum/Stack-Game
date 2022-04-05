using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DogukanKarabiyik.StackGame.Control;

namespace DogukanKarabiyik.StackGame.Environment.Flags {

    public class FlagChecker : MonoBehaviour {

        private void OnTriggerEnter(Collider other) {

            if (other.tag == "Player") {

                var player = other.GetComponent<PlayerController>();

                player.isWon = true;
                player.isMoving = false;
                
                               
            }
        }
    }
}

   
