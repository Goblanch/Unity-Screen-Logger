using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UnityScreenLogger.UI
{
    public class USLLogger : MonoBehaviour
    {
        private struct LogMessage
        {
            public string Text;
            public float ExpirationTime;
            public Color MessageColor;
        }

        private readonly List<LogMessage> messages = new List<LogMessage>();
        private TextMeshProUGUI textComponent;

        void Awake()
        {
            SetupUI();
        }

        void Update()
        {
            float currentTime = Time.time;
            messages.RemoveAll(m => m.ExpirationTime <= currentTime);

            textComponent.text = "";
            foreach(var message in messages){
                textComponent.text += $"<color=#{ColorUtility.ToHtmlStringRGBA(message.MessageColor)}>{message.Text}</color>\n";
            }
        }

        public void AddMessage(string text, float duration, Color color)
        {
            messages.Add(new LogMessage
            {
                Text = text,
                ExpirationTime = duration,
                MessageColor = color
            });
        }

        private void SetupUI(){
            GameObject canvasObj = new GameObject("USLLLoggerCanvas");
            Canvas canvas = canvasObj.AddComponent<Canvas>();
            canvas.renderMode = RenderMode.ScreenSpaceOverlay;
            canvasObj.AddComponent<CanvasScaler>().uiScaleMode = CanvasScaler.ScaleMode.ScaleWithScreenSize;
            canvasObj.AddComponent<GraphicRaycaster>();

            GameObject textObj = new GameObject("USLLoggerText");
            textObj.transform.SetParent(canvasObj.transform);
            textComponent = textObj.AddComponent<TextMeshProUGUI>();
            textComponent.rectTransform.anchorMin = new Vector2(0, 0);
            textComponent.rectTransform.anchorMax = new Vector2(1, 0.2f);
            textComponent.rectTransform.offsetMin = new Vector2(10, 10);
            textComponent.rectTransform.offsetMax = new Vector2(-10, -10);
            textComponent.alignment = TextAlignmentOptions.Left;
            textComponent.fontSize = 18;
            textComponent.color = Color.white;
        }
    }
}

