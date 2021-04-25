using Scriptables;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace WellWellWell.UI
{
    public class RewardRow : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI m_rewardText;
        [SerializeField] private Image m_image;
        [SerializeField] private Sprite m_timerIcon;

        public void Show(BuildingData toShow)
        {
            this.m_rewardText.text = toShow.Name;
            this.m_image.sprite = toShow.Icon;
        }

        public void ShowProductionTime(WellUpgradeData toShow)
        {
            this.m_rewardText.text = $"{toShow.NewProductionTime}";
            this.m_image.sprite = this.m_timerIcon;
        }
    }
}