using System.Collections;
using HurricaneVR.Framework.Core;
using HurricaneVR.Framework.Core.Player;
using HurricaneVR.Framework.Core.UI;
using UnityEngine;
using UnityEngine.InputSystem.UI;
using UnityEngine.XR.Management;

namespace intheclouds
{
    public class Startup : MonoBehaviour
    {
        public static Startup instance;
        
        [Header("Setup")]
        public InputSystemUIInputModule desktopModeInputModule;
        public HVRInputModule vrInputModule;
        
        [Header("Debug")]
        public bool isDesktopMode;
        [Tooltip("Debug mode enables kbm in VR, endAnyTurn, and spirit wander any time")]
        public bool debugMode;
        public bool loadPlayerSettings = true;
        // public bool kbmAllowedInVR;
        // public bool endAnyTurn;
        // public bool spiritWanderAnyTime;
        public const string SmoothRotationSettingKey = "SaveSmoothRotationSetting";
        public const string DebugSettingKey = "SaveDebugSetting";


        private void Awake()
        {
            instance = this;
            
            if (!isDesktopMode)
            {
                vrInputModule.enabled = true;
                // todo: uncomment when ready to work in desktop mode
                // if (!XRGeneralSettings.Instance.InitManagerOnStart)
                // {
                //     StartCoroutine(LoadVRMode());
                // }
            }
            else
            {
                desktopModeInputModule.enabled = true;
            }
        }

        private void Start()
        {
            if (loadPlayerSettings)
            {
                LoadPlayerSettings();
            }

            HVRManager.Instance.isDesktopMode = isDesktopMode;
        }

        private void Update()
        {
            HVRManager.Instance.debugMode = debugMode;
        }

        public static void SaveUserTurnSetting(int rotationEnumIndex)
        {
            // For reference. rotation == 0 ? smooth : snap
            PlayerPrefs.SetInt(SmoothRotationSettingKey, rotationEnumIndex);
            PlayerPrefs.Save();
        }
        
        public static void SaveDebugSetting(int debug)
        {
            // For reference. debug == 1 ? true : false
            PlayerPrefs.SetInt(DebugSettingKey, debug);
            PlayerPrefs.Save();
        }

        private void LoadPlayerSettings()
        {
            if (PlayerPrefs.HasKey(SmoothRotationSettingKey))
            {
                LocalUserObjects.instance.PlayerController.RotationType = (RotationType)PlayerPrefs.GetInt(SmoothRotationSettingKey);
            }
            if (PlayerPrefs.HasKey(DebugSettingKey))
            {
                debugMode = PlayerPrefs.GetInt(DebugSettingKey) == 1;
            }
        }

        // Uncomment this if want more granular debug options
        // private void CheckDebugMode()
        // {
        //     kbmAllowedInVR = debugMode;
        //     endAnyTurn = debugMode;
        //     spiritWanderAnyTime = debugMode;
        // }

        private IEnumerator LoadVRMode()
        {
            Debug.Log("Initializing XR...");
            yield return StartCoroutine(XRGeneralSettings.Instance.Manager.InitializeLoader());
            if (!XRGeneralSettings.Instance.Manager.activeLoader)
            {
                Debug.LogError("Initializing XR Failed. Check Editor or Player log for details.");
            }
            else
            {
                Debug.Log("Starting XR...");
                XRGeneralSettings.Instance.Manager.StartSubsystems();
            }
        }
    }
}
