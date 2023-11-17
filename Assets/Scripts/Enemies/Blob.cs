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
                var oldPlayerPos = LocalUserObjects.instance.PlayerController.transform.position;
                if (oldPlayerPos.y < transform.position.y)
                {
                    var newPlayerPos = new Vector3(oldPlayerPos.x, transform.position.y, oldPlayerPos.z);
                    LocalUserObjects.instance.Teleporter.Teleport(newPlayerPos);
                }

                HVRManager.Instance.PlayerController.verticalOverride = boost;
                OnDied();
                Destroy(gameObject);
            }
        }
    }
}