using System;
using System.Collections;
using System.Collections.Generic;
using HurricaneVR.Framework.Core;
using HurricaneVR.Framework.Core.Player;
using UnityEngine;

public class Blob : Enemy
{
    public float boost = 10;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            // Vector3 vel = HVRManager.Instance.PlayerController.xzVelocity;
            // vel.y += 1;
            HVRManager.Instance.PlayerController.blobJumpBoost = boost;
            destructible.Destroy();
        }
    }
}
