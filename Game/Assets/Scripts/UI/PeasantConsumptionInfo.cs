using TMPro;
using UnityEngine;
using UnityEngine.UI;
using WellWellWell.Util;

namespace WellWellWell.UI
{
    public class PeasantConsumptionInfo : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI m_consumptionPerMinute;
        [SerializeField] private Image m_resourceIcon;

        public void Show(CivilBuilding building, ResourceConsumption consumption)
        {
            this.m_resourceIcon.sprite = consumption.ResourceToConsume.Icon;
            this.m_consumptionPerMinute.text = $"{building.CurrentInhabitants * consumption.ConsumptionPerMinute}/min";
        }
    }
}