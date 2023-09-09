using HurricaneVR.Framework.Core;
using UnityEngine;

namespace intheclouds
{
    public class Blob : Enemy
    {
        public float boost = 7f;
    
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
            {
                HVRManager.Instance.PlayerController.verticalModifier = boost;
                destructible.Destroy();
            }
        }
    }
}