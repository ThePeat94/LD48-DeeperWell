using TMPro;
using UnityEngine;
using UnityEngine.UI;
using WellWellWell.EventArgs;

namespace WellWellWell.UI
{
    public class WellUI : MonoBehaviour
    {
        [SerializeField] private GameObject m_unlockConditionsGrid;
        [SerializeField] private GameObject m_unlockConditionPrefab;
        [SerializeField] private Button m_unlockButton;
        [SerializeField] private TextMeshProUGUI m_productionTimeText;
        [SerializeField] private TextMeshProUGUI m_levelText;
        
        private Well m_well;
        
        public void Show(Well well)
        {
            this.gameObject.SetActive(true);
            this.m_well = well;
            if (this.m_well.CurrentUpgradeInfo != null)
            {
                this.SubscribeToResourceChanges();
                this.UpdateUpgradeInfo();
            }

            this.UpgradeWellInfo();
        }

        public void Hide()
        {
            this.UnsubscribeToResourceChanges();
            this.gameObject.SetActive(false);
        }

        public void ClearUnlockConditions()
        {
            foreach (Transform child in this.m_unlockConditionsGrid.transform)
            {
                Destroy(child.gameObject);
            }
        }

        public void OnUpgradeClick()
        {
            this.UnsubscribeToResourceChanges();
            this.m_well.UpgradeToNextLevel();
            this.UpgradeWellInfo();
            if (this.m_well.CurrentUpgradeInfo == null)
                return;
            
            this.SubscribeToResourceChanges();
            this.UpdateUpgradeInfo();
        }

        private void UpdateUpgradeInfo()
        {
            this.ClearUnlockConditions();
            foreach (var resourceUnlockCondition in this.m_well.CurrentUpgradeInfo.ResourceUnlockConditions)
            {
                var unlockConditionRow = Instantiate(this.m_unlockConditionPrefab, this.m_unlockConditionsGrid.transform).GetComponent<UnlockConditionRow>();
                unlockConditionRow.Show(resourceUnlockCondition);
            }
            
            foreach (var populationUnlockCondition in this.m_well.CurrentUpgradeInfo.PopulationUnlockConditions)
            {
                var unlockConditionRow = Instantiate(this.m_unlockConditionPrefab, this.m_unlockConditionsGrid.transform).GetComponent<UnlockConditionRow>();
                unlockConditionRow.Show(populationUnlockCondition);
            }

            this.m_unlockButton.interactable = this.m_well.CanUpgrade();
        }

        private void UpgradeWellInfo()
        {
            if (this.m_well.CurrentUpgradeInfo == null)
            {
                this.m_unlockButton.gameObject.SetActive(false);
                this.ClearUnlockConditions();
            }

            this.m_levelText.text = $"Level {this.m_well.CurrentLevel}";
            this.m_productionTimeText.text = $"{this.m_well.CurrentProductionTimer:F}";
        }

        private void SubscribeToResourceChanges()
        {
            if (this.m_well?.CurrentUpgradeInfo == null)
                return;
            
            foreach (var resourceUnlockCondition in this.m_well.CurrentUpgradeInfo.ResourceUnlockConditions)
            {
                resourceUnlockCondition.Resource.ResourceController.ResourceValueChanged += this.ResourceValueChanged;
            }
            
            foreach (var resourceUnlockCondition in this.m_well.CurrentUpgradeInfo.PopulationUnlockConditions)
            {
                resourceUnlockCondition.PopulationResource.ResourceController.ResourceValueChanged += this.ResourceValueChanged;
            }
        }
        
        private void UnsubscribeToResourceChanges()
        {
            if (this.m_well?.CurrentUpgradeInfo == null)
                return;
            
            foreach (var unlockCondition in this.m_well.CurrentUpgradeInfo.ResourceUnlockConditions)
            {
                unlockCondition.Resource.ResourceController.ResourceValueChanged -= this.ResourceValueChanged;
            }
            
            foreach (var unlockCondition in this.m_well.CurrentUpgradeInfo.PopulationUnlockConditions)
            {
                unlockCondition.PopulationResource.ResourceController.ResourceValueChanged -= this.ResourceValueChanged;
            }
        }

        private void ResourceValueChanged(object sender, ResourceValueChangedEvent args)
        {
            this.UpdateUpgradeInfo();
        }
    }
}