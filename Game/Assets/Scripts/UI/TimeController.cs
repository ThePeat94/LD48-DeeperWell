using UnityEngine;
using UnityEngine.UI;

namespace WellWellWell.UI
{
    public class TimeController : MonoBehaviour
    {
        [SerializeField] private Button m_normalSpeedButton;
        [SerializeField] private Button m_doubleSpeedButton;
        [SerializeField] private Button m_quadrupleSpeedButton;

        private Button m_currentActiveTimeButton;

        private void Awake()
        {
            this.ChangeActiveButtonTo(this.m_normalSpeedButton);
        }

        public void OnDoubleSpeedClicked()
        {
            Time.timeScale = 2;
            this.ChangeActiveButtonTo(this.m_doubleSpeedButton);
        }


        public void OnNormalSpeedClicked()
        {
            Time.timeScale = 1;
            this.ChangeActiveButtonTo(this.m_normalSpeedButton);
        }

        public void OnQuadrupleSpeedClicked()
        {
            Time.timeScale = 4;
            this.ChangeActiveButtonTo(this.m_quadrupleSpeedButton);
        }


        private void ChangeActiveButtonTo(Button newActive)
        {
            if (this.m_currentActiveTimeButton != null)
                this.m_currentActiveTimeButton.interactable = true;
            this.m_currentActiveTimeButton = newActive;
            this.m_currentActiveTimeButton.interactable = false;
        }
    }
}