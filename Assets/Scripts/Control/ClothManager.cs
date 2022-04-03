using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DogukanKarabiyik.StackGame.Control {

    public class ClothManager : MonoBehaviour {

        [SerializeField]
        public List<Transform> clothDestinations = new List<Transform>();

        public int freeSpaceIndex { get; set; } = 0;
        public int maxFreeSpace { get; private set; } = 4;
    }
}
    
