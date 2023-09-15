using HurricaneVR.Framework.Components;
using HurricaneVR.Framework.Core.Utils;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace intheclouds
{
    public class PlayerHealth : MonoBehaviour
    {
        [SerializeField]
        private int startingHealth = 30;
        [SerializeField]
        private HVRDamageHandler _hvrDamageHandler;
        [SerializeField]
        private AudioClip damagedSFX;
        [SerializeField]
        private AudioClip diedSFX;

        private void Awake()
        {
            SceneManager.sceneLoaded += OnSceneLoaded;
            _hvrDamageHandler.damaged += OnDamaged;
            _hvrDamageHandler.lifeReachedZero += OnDied;
        }

        private void OnDamaged()
        {
            SFXPlayer.Instance.PlaySFX(damagedSFX, LocalUserObjects.instance.Camera.transform);
            HUDController.instance.UpdateHealthUI(_hvrDamageHandler.Life);
        }

        private void OnDied()
        {
            SFXPlayer.Instance.PlaySFX(diedSFX, LocalUserObjects.instance.Camera.transform);
            HUDController.instance.UpdateHealthUI(0);
            UserMenu.instance.ToggleMenu(true);
        }

        private void OnSceneLoaded(Scene arg0, LoadSceneMode arg1)
        {
            Initialize();
        }

        private void Initialize()
        {
            _hvrDamageHandler.Life = startingHealth;
            HUDController.instance.ResetHealthUI();
        }
    }
}
