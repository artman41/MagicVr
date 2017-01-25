using UnityEngine;
using System.Collections;

namespace Assets.Scripts.Character.Player {
    public class Gravity : MonoBehaviour {
        public float speed = 6.0F;
        public float jumpSpeed = 8.0F;
        public float gravity = 20.0F;
        public Vector3 moveDirection = Vector3.zero;
        public CharacterController controller;

        void Start() {
            controller = GetComponent<CharacterController>();
        }
    }
}