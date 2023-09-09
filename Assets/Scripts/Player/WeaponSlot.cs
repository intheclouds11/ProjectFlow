using System;
using HighlightPlus;
using HurricaneVR.Framework.Components;
using HurricaneVR.Framework.Core.Utils;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

namespace intheclouds
{
    public class WeaponSlot : MonoBehaviour
    {
        public HVRDamageProvider weapon;

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("PointerFingerTip"))
            {
                
            }
        }
    }
}