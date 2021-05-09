using TMPro;
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
        [SerializeField] private GameObject m_consumptionInfoLayout;
        [SerializeField] private GameObject m_consumptionInfoPrefab;
        [SerializeField] private Image m_extraInhabitantsImage;

        private CivilBuilding m_buildingToDisplay;
        private Coroutine m_currentShowRoutine;

        public void DestructBuilding()
        {
            this.Hide();
            this.m_buildingToDisplay.Destruct();
        }

        public void Hide()
        {
            if (this.m_buildingToDisplay != null)
                this.m_buildingToDisplay.Data.Resource.ResourceController.ResourceValueChanged -= this.PeasantsAmountChanged;
            this.gameObject.SetActive(false);
        }

        public void Show(CivilBuilding building)
        {
            this.gameObject.SetActive(true);
            this.m_buildingToDisplay = building;
            this.m_buildingToDisplay.Data.Resource.ResourceController.ResourceValueChanged += this.PeasantsAmountChanged;

            if (this.m_currentShowRoutine != null)
                this.StopCoroutine(this.m_currentShowRoutine);

            this.UpdateInfo();
        }


        private void ClearResourceInfos()
        {
            foreach (Transform child in this.m_resourceInfo.transform)
                Destroy(child.gameObject);
            
            foreach (Transform child in this.m_consumptionInfoLayout.transform)
                Destroy(child.gameObject);
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
            this.m_extraInhabitantsImage.sprite = this.m_buildingToDisplay.Data.ExtraInhabitantsIcon;
            foreach (var consumption in this.m_buildingToDisplay.Data.ConsumptionPerInhibitant)
            {
                var instantiatedResourceInfo = Instantiate(this.m_resourceInfoPrefab, this.m_resourceInfo.transform).GetComponent<PeasantResourceInfo>();
                instantiatedResourceInfo.ShowConsumption(this.m_buildingToDisplay, consumption);

                var instantiatedConsumptionInfo = Instantiate(this.m_consumptionInfoPrefab, this.m_consumptionInfoLayout.transform).GetComponent<PeasantConsumptionInfo>();
                instantiatedConsumptionInfo.Show(this.m_buildingToDisplay, consumption);
            }
        }
    }
}