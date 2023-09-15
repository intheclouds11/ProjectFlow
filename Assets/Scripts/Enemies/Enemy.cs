using System;
using HighlightPlus;
using HurricaneVR.Framework.Components;
using HurricaneVR.Framework.Core.Utils;
using UnityEngine;
using UnityEngine.UI;

namespace intheclouds
{
    public class Enemy : MonoBehaviour
    {
        public enum EnemyType
        {
            Blob,
            Runt,
        }

        public EnemyType enemyType;
        public AudioClip damagedSFX;
        public AudioClip diedSFX;
        public GameObject weaponDrop;
        public Slider healthBar;

        protected HVRDamageHandler _damageHandler;
        protected HVRDestructible _destructible;
        protected HighlightEffect _highlightEffect;

        protected virtual void Awake()
        {
            _damageHandler = GetComponent<HVRDamageHandler>();
            _destructible = GetComponent<HVRDestructible>();
            _highlightEffect = GetComponent<HighlightEffect>();

            if (_damageHandler)
            {
                _damageHandler.damaged += OnDamaged;
            }
        }

        protected virtual void Start()
        {
            EnemyManager.instance.AddEnemy(this);
        }

        protected virtual void OnDestroy()
        {
            SFXPlayer.Instance.PlaySFX(diedSFX, transform.position, 1f, 1.5f);
            EnemyManager.instance.RemoveEnemy(this);
            if (weaponDrop)
            {
                Instantiate(weaponDrop, transform.position, Quaternion.identity);
            }
        }

        protected virtual void OnDamaged()
        {
            SFXPlayer.Instance.PlaySFX(damagedSFX, transform.position, 1f, 1.5f);
            _highlightEffect.HitFX();
            healthBar.value = (float) _damageHandler.Life / _damageHandler.StartingLife;
        }
    }
}