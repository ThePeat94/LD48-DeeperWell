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

        public void ShowConsumption(CivilBuilding building, ResourceConsumption consumption)
        {
            var extraAmount = building.GetCurrentExtraInhabitantsForResource(consumption.ResourceToConsume);
            this.m_currentExtraPesantsAmount.text = $"{extraAmount:+#;-#;0}/+{consumption.ExtraInhibitants}";
            this.m_resourceIcon.sprite = consumption.ResourceToConsume.Icon;
        }
    }
}