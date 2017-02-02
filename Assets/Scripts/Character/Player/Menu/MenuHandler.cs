using Leap;
using Leap.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Character.Player.Menu {
    class MenuHandler : MonoBehaviour {

        GameObject[] hands;
        GameObject handLeft;
        GameObject handRight;
        LeapProvider provider;

        PalmDirectionDetector lpd;
        PalmDirectionDetector rpd;

        ExtendedFingerDetector lefd;
        ExtendedFingerDetector refd;

        bool fingersExtendedLeft;
        bool palmFacingLeft;

        Canvas canvas;

        void Start() {
            provider = FindObjectOfType<LeapProvider>() as LeapProvider;
                switch (this.transform.parent.gameObject.name) {
                    case "CapsuleHand_L":
                    handLeft = this.transform.parent.gameObject;
                    break;
                    default:
                    handRight = this.transform.parent.gameObject;
                    break;
                }

            if (handLeft != null) {
                lpd = handLeft.GetComponent<PalmDirectionDetector>();
                lefd = handLeft.GetComponent<ExtendedFingerDetector>();
            }

            if (handRight != null) {
                rpd = handRight.GetComponent<PalmDirectionDetector>();
                refd = handRight.GetComponent<ExtendedFingerDetector>();
            }

            canvas = GetComponent<Canvas>();
        }

        void Update() {
            if (handLeft != null) {
                //Debug.Log(string.Format("fingersExtendedLeft :: {0} [{1} {2} {3} {4} {5}]", fingersExtendedLeft, lefd.Index, lefd.Middle, lefd.Pinky, lefd.Ring, lefd.Thumb));
                //Debug.Log(string.Format("PalmFacingLeft :: {0}", palmFacingLeft));
                if (fingersExtendedLeft && palmFacingLeft) {

                    //Frame frame = provider.CurrentFrame;
                    //foreach (Hand hand in frame.Hands) {
                    //    if (hand.IsLeft) {
                    //    }
                    //}

                    canvas.enabled = true;
                    //Debug.Log("Canvas Enabled");
                } else {
                    canvas.enabled = false;
                }
            }
        }

        public void PalmFacingLeft() {
            palmFacingLeft = true;
        }

        public void PalmAwayLeft() {
            palmFacingLeft = false;
        }

        public void ExtendFingersLeft() {
            fingersExtendedLeft = true;
        }

        public void RetractFingersLeft() {
            fingersExtendedLeft = false;
        }

        public void ButtonClicked(GameObject sender) {
            Debug.Log(string.Format("Button clicked by {0}", sender.name));
        }

    }
}
