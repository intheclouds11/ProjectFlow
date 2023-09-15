using HurricaneVR.Framework.Weapons.Guns;
using UnityEngine;

namespace intheclouds
{
    public class EnemyAI : MonoBehaviour
    {
        private Enemy _enemy;
        private bool _playerDetected;
        private HVRGunBase _gunBase;

        
        private void Awake()
        {
            _enemy = GetComponent<Enemy>();
            _gunBase = GetComponent<HVRGunBase>();
        }

        private void Update()
        {
            if (_playerDetected && LocalUserObjects.instance.playerDamageHandler.Life > 0)
            {
                transform.LookAt(LocalUserObjects.instance.waist.transform);
                
                if (_enemy.enemyType == Enemy.EnemyType.Runt)
                {
                    _gunBase.EnemyFiring(true);
                }
            }
            else
            {
                _gunBase.EnemyFiring(false);
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
            {
                _playerDetected = true;
            }
        }

       
    }
}