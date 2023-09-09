using System.Collections;
using HurricaneVR.Framework.Components;
// using HighlightPlus;
using HurricaneVR.Framework.Core;
using HurricaneVR.Framework.Core.Grabbers;
using HurricaneVR.Framework.Shared;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

namespace intheclouds
{
    public class AbilitySystem : MonoBehaviour
    {
        public GameObject weaponSlots;
        
        private HVRController _leftController;
        private HVRController _rightController;
        private HVRController _selectorHand;
        private LocalUserObjects _localUserObjects;

        
        private void Awake()
        {
            _localUserObjects = LocalUserObjects.instance;

            if (weaponSlots.activeInHierarchy)
            {
                weaponSlots.SetActive(false);
            }
        }

        private void Start()
        {
            _leftController = _localUserObjects.PlayerInputs.LeftController;
            _rightController = _localUserObjects.PlayerInputs.RightController;
        }

        void Update()
        {
            SelectorUpdate();
        }

        private void SelectorUpdate()
        {
            if (!weaponSlots.activeSelf)
            {
                if (!_localUserObjects.leftHandGrabber.IsGrabbing && _localUserObjects.PlayerInputs.isLeftAbilitySelectorActivated)
                {
                    ShowSelector(_localUserObjects.leftHandAbilitySelectorSpawn.transform, _leftController);
                }
                else if (!_localUserObjects.rightHandGrabber.IsGrabbing && _localUserObjects.PlayerInputs.isRightAbilitySelectorActivated)
                {
                    ShowSelector(_localUserObjects.rightHandAbilitySelectorSpawn.transform, _rightController);
                }

                return;
            }

            if (_selectorHand == _leftController && _localUserObjects.PlayerInputs.isLeftAbilitySelectorActivated)
            {
                HideSelector();
            }
            else if (_selectorHand == _rightController && _localUserObjects.PlayerInputs.isRightAbilitySelectorActivated)
            {
                HideSelector();
            }
        }

        public void ShowSelector(Transform spawnPoint, HVRController hand)
        {
            _selectorHand = hand;
            transform.position = spawnPoint.position;
            var newEulerAngles = spawnPoint.eulerAngles;
            newEulerAngles = new Vector3(30, newEulerAngles.y, 0);
            transform.eulerAngles = newEulerAngles;

            weaponSlots.SetActive(true);
        }

        public void HideSelector()
        {
            weaponSlots.SetActive(false);
        }
    }
}