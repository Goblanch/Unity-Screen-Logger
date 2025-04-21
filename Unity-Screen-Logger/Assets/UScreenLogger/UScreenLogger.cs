using UnityEngine;

namespace UnityScreenLogger.Core
{
    using UnityScreenLogger.UI;

    public static class USLDebug
    {
        private static USLLogger loggerInstance;

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        private static void InitializeLogger()
        {
            if (loggerInstance == null)
            {
                GameObject loggerObj = new GameObject("USSLLogger");
                loggerInstance = loggerObj.AddComponent<USLLogger>();
                GameObject.DontDestroyOnLoad(loggerObj);
            }
        }

        #region Public API for Logging
        
        public static void Log(string message, float duration = 5f, Color? color = null)
        {
            loggerInstance?.AddMessage(message, duration, color ?? Color.white);
        }

        public static void Warning(string message, float duration = 5f)
        {
            loggerInstance?.AddMessage(message, duration, Color.yellow);
        }

        public static void Error(string message, float duration = 5f)
        {
            loggerInstance?.AddMessage(message, duration, Color.red);
        }

        #endregion
    }
}


