using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace WellWellWell.UI
{
    public class IntroductionUI : MonoBehaviour
    {
        [SerializeField] private List<GameObject> m_texts;
        [SerializeField] private TextMeshProUGUI m_nextButtonText;
        [SerializeField] private Button m_previousButton;

        private int m_currentIndex = 0;

        public void Close()
        {
            this.gameObject.SetActive(false);
        }
        
        public void Next()
        {
            if (this.m_currentIndex >= this.m_texts.Count - 1)
            {
                this.Close();
                return;
            }
            
            this.m_currentIndex++;
            this.m_texts[this.m_currentIndex - 1].SetActive(false);
            this.m_texts[this.m_currentIndex].SetActive(true);
            this.UpdateButtons();
        }

        private void UpdateButtons()
        {
            this.m_previousButton.gameObject.SetActive(this.m_currentIndex != 0);
            this.m_nextButtonText.text = this.m_currentIndex == this.m_texts.Count - 1 ? "Close" : "Next";
        }

        public void Previous()
        {
            if (this.m_currentIndex <= 0)
                return;
            
            this.m_currentIndex--;
            this.m_texts[this.m_currentIndex + 1].SetActive(false);
            this.m_texts[this.m_currentIndex].SetActive(true);
            this.UpdateButtons();
        }
    }
}