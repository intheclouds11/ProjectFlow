using HurricaneVR.Framework.Components;
using HurricaneVR.Framework.Core.Utils;
using UnityEngine;

namespace intheclouds
{
    public class Enemy : MonoBehaviour
    {
        public AudioClip damagedSFX;
        public AudioClip diedSFX;
    
        protected HVRDamageHandler hvrDamageHandler;
        protected HVRDestructible destructible;

        protected void Awake()
        {
            hvrDamageHandler = GetComponent<HVRDamageHandler>();
            destructible = GetComponent<HVRDestructible>();

            if (hvrDamageHandler)
            {
                hvrDamageHandler.damaged += OnDamaged;
            }
        }

        private void OnDestroy()
        {
            SFXPlayer.Instance.PlaySFX(diedSFX, transform.position, 1f, 1.5f);
        }

        protected virtual void OnDamaged()
        {
            SFXPlayer.Instance.PlaySFX(damagedSFX, transform.position, 1f, 1.5f);
        }
    }
}