using TMPro;
using UnityEngine;
using UnityEngine.UI;
using WellWellWell.Util;

namespace WellWellWell.UI
{
    public class UnlockConditionRow : MonoBehaviour
    {
        [SerializeField] private Image m_image;
        [SerializeField] private TextMeshProUGUI m_unlockCondition;

        public void Show(ResourceUnlockCondition condition)
        {
            this.m_image.sprite = condition.Resource.Icon;
            this.m_unlockCondition.text = $"{condition.Resource.ResourceController.CurrentValue:0} / {condition.Amount:0}";
        }
        
        public void Show(PopulationUnlockCondition condition)
        {
            this.m_image.sprite = condition.PopulationResource.Icon;
            this.m_unlockCondition.text = $"{condition.PopulationResource.ResourceController.CurrentValue:0} / {condition.NeededAmount:0}";
        }
    }
}