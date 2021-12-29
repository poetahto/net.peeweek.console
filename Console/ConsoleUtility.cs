using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ConsoleUtility
{
    static class ConsoleUtility
    {

        const string kDefaultPrefix = "Default_";
#if ENABLE_LEGACY_INPUT_MANAGER
        const string kPrefabName = "Console_LegacyInput";
#elif ENABLE_INPUT_SYSTEM
        const string kPrefabName = "Console_NewInputSystem";
#endif

        [RuntimeInitializeOnLoadMethod]
        static void CreateConsole()
        {
            Console prefab = Resources.Load<Console>(kPrefabName);

            if (prefab == null)
                prefab = Resources.Load<Console>(kDefaultPrefix+kPrefabName);

            if (prefab == null)
            {
                Debug.LogWarning("Could not load Console: Prefab not found");
                return;
            }

            if (prefab.autoGenerate)
            {
                Console instance = GameObject.Instantiate(prefab);
                instance.name = "Console";

                if (prefab.dontDestroyOnLoad)
                    GameObject.DontDestroyOnLoad(instance);
            }
        }
    }
}

