using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DogukanKarabiyik.StackGame.Environment.Obstacles {

    public class VerticalObstacleBehaviour : MonoBehaviour {

        [SerializeField]
        private float movingSpeed = 5f;

        [SerializeField]
        Transform start;

        [SerializeField]
        Transform destination;

        private bool isReached = false;

        private void Start() {

            transform.position = start.position;
        }

        private void Update() {

            if (!isReached) {

                transform.Translate(Vector3.up * movingSpeed * Time.deltaTime);

                if (transform.position.y >= destination.position.y)
                    isReached = true;

            }

            else {

                transform.Translate(Vector3.down * movingSpeed * Time.deltaTime);

                if (transform.position.y <= start.position.y)
                    isReached = false;
            }
        }

        private void OnTriggerEnter(Collider other) {

            if (other.tag == "Player")
                UnityEngine.SceneManagement.SceneManager.LoadScene(0);
        }
    }
}
  
