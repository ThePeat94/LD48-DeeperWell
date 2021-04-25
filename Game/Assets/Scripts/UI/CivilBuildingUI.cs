using System.Collections;
using TMPro;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.UI;
using WellWellWell.EventArgs;

namespace WellWellWell.UI
{
    public class CivilBuildingUI : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI m_title;
        [SerializeField] private Image m_inhabitantIcon;
        [SerializeField] private TextMeshProUGUI m_currentPeasants;
        [SerializeField] private GameObject m_resourceInfoPrefab;
        [SerializeField] private GameObject m_resourceInfo;

        private CivilBuilding m_buildingToDisplay;
        private Coroutine m_currentShowRoutine;

        public void Hide()
        {
            if(this.m_buildingToDisplay != null)
                this.m_buildingToDisplay.Data.GlobalHumanResource.ResourceController.ResourceValueChanged -= this.PeasantsAmountChanged;
            this.gameObject.SetActive(false);
        }

        public void Show(CivilBuilding building)
        {
            this.gameObject.SetActive(true);
            this.m_buildingToDisplay = building;
            this.m_buildingToDisplay.Data.GlobalHumanResource.ResourceController.ResourceValueChanged += this.PeasantsAmountChanged;

            if (this.m_currentShowRoutine != null)
            {
                this.StopCoroutine(this.m_currentShowRoutine);
            }
            
            this.UpdateInfo();
        }

        private void PeasantsAmountChanged(object sender, ResourceValueChangedEvent args)
        {
            this.UpdateInfo();
        }

        private void UpdateInfo()
        {
            this.ClearResourceInfos();
            this.m_title.text = this.m_buildingToDisplay.Data.Name;
            this.m_currentPeasants.text = $"{this.m_buildingToDisplay.CurrentInhabitants}/{this.m_buildingToDisplay.Data.MaxInhibitants}";
            this.m_inhabitantIcon.sprite = this.m_buildingToDisplay.Data.Icon;

            foreach (var consumption in this.m_buildingToDisplay.Data.ConsumptionPerInhibitant)
            {
                var currentConsumptionPerMinute = consumption.ConsumptionPerMinute * this.m_buildingToDisplay.CurrentInhabitants;
                var currentExtra = this.m_buildingToDisplay.GetCurrentExtraInhabitantsForResource(consumption.ResourceToConsume);

                var instantiatedInfo = Instantiate(this.m_resourceInfoPrefab, this.m_resourceInfo.transform).GetComponent<PeasantResourceInfo>();
                instantiatedInfo.ShowConsumption(currentExtra, consumption.ResourceToConsume.Icon, currentConsumptionPerMinute);
            }
        }

        private void ClearResourceInfos()
        {
            foreach (Transform child in this.m_resourceInfo.transform)
            {
                Destroy(child.gameObject);
            }
        }
    }
}