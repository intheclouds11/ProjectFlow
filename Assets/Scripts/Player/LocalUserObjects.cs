using HurricaneVR.Framework.ControllerInput;
using HurricaneVR.Framework.Core.Grabbers;
using HurricaneVR.Framework.Core.Player;
using UnityEngine;

namespace intheclouds
{
    public class LocalUserObjects : MonoBehaviour
    {
        public static LocalUserObjects instance;
        // public PlayerStats PlayerStats;
        public HVRPlayerController PlayerController;
        public HVRTeleporter Teleporter;
        public HVRPlayerInputs PlayerInputs;
        // public ITCPlayerInputs ITCPlayerInputs;
        // public PlayerMovementAP PlayerMovementAP;
        public HVRCameraRig HVRCameraRig;
        public Camera Camera;
        // public HUDController HUDController;
        public Transform leftController;
        public HVRHandGrabber leftHandGrabber;
        public GameObject leftHandAbilitySelectorSpawn;
        public Transform rightController;
        public HVRHandGrabber rightHandGrabber;
        public GameObject rightHandAbilitySelectorSpawn;
        public GameObject waist;
        public GameObject visorSocket;
        public GameObject turnOrderUI;
        // public SpiritWander spiritWander;
        // public HighlightEffect handAugmentHighlight;
        // public AbilitySystem abilitySystem;
        // public AbilityPointer leftAbilityPointer;
        // public AbilityPointer rightAbilityPointer;

        private void Awake()
        {
            instance = this;
        }
    }
}
