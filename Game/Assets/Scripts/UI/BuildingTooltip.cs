using Scriptables;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace WellWellWell.UI
{
    public class BuildingTooltip : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI m_title;
        [SerializeField] private GameObject m_costGrid;
        [SerializeField] private GameObject m_resourceCostPrefab;

        [Header("Production Building Info")] [SerializeField]
        private GameObject m_productionInfo;

        [SerializeField] private Image m_productionIcon;
        [SerializeField] private TextMeshProUGUI m_productionTime;

        [Header("Civil Building Info")] [SerializeField]
        private GameObject m_civilBuildingInfo;

        [SerializeField] private Image m_peasantIcon;
        [SerializeField] private TextMeshProUGUI m_maxInhabitantsInfo;

        public void Hide()
        {
            this.gameObject.SetActive(false);
        }

        public void Show(ProductionBuildingData toShow)
        {
            this.ShowGeneralInfo(toShow);
            var workforce = Instantiate(this.m_resourceCostPrefab, this.m_costGrid.transform).GetComponent<ResourceCostUI>();
            workforce.Show(toShow.WorkforceConsumption);
            this.m_civilBuildingInfo.SetActive(false);
            this.m_productionInfo.SetActive(true);
            this.m_productionIcon.sprite = toShow.Icon;
            this.m_productionTime.text = $"{toShow.SecondsToProduce}";
        }

        public void Show(CivilBuildingData toShow)
        {
            this.ShowGeneralInfo(toShow);
            this.m_civilBuildingInfo.SetActive(true);
            this.m_productionInfo.SetActive(false);
            this.m_peasantIcon.sprite = toShow.Icon;
            this.m_maxInhabitantsInfo.text = $"{toShow.MaxInhibitants}";
        }

        private void ClearCostGrid()
        {
            foreach (Transform child in this.m_costGrid.transform)
                Destroy(child.gameObject);
        }

        private void ShowGeneralInfo(BuildingData toShow)
        {
            this.ClearCostGrid();
            this.gameObject.SetActive(true);
            this.m_title.text = toShow.Name;

            foreach (var buildingCost in toShow.Costs)
            {
                var resourceCostUi = Instantiate(this.m_resourceCostPrefab, this.m_costGrid.transform).GetComponent<ResourceCostUI>();
                resourceCostUi.Show(buildingCost);
            }
        }
    }
}