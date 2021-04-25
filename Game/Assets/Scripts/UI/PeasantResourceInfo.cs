using TMPro;
using UnityEngine;
using UnityEngine.UI;
using WellWellWell.Util;

namespace WellWellWell.UI
{
    public class PeasantResourceInfo : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI m_currentExtraPesantsAmount;
        [SerializeField] private Image m_resourceIcon;
        [SerializeField] private TextMeshProUGUI m_consumptionPerMinute;

        public void ShowConsumption(int extraAmount, Sprite resourceIcon, float consumptionPerMinute)
        {
            this.m_currentExtraPesantsAmount.text = $"{extraAmount:+#;-#;0}";
            this.m_resourceIcon.sprite = resourceIcon;
            this.m_consumptionPerMinute.text = $"{consumptionPerMinute:F}";
        }
    }
}