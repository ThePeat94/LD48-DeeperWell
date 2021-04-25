using TMPro;
using UnityEngine;
using UnityEngine.UI;
using WellWellWell.Util;

namespace WellWellWell.UI
{
    public class ResourceCostUI : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI m_amountText;
        [SerializeField] private Image m_icon;

        public void Show(BuildingCost toShow)
        {
            this.m_amountText.text = $"{toShow.Cost}";
            this.m_icon.sprite = toShow.Type.Icon;
        }

        public void Show(WorkforceConsumption toShow)
        {
            this.m_amountText.text = $"{toShow.Amount}";
            this.m_icon.sprite = toShow.HumanResource.Icon;
        }
    }
}