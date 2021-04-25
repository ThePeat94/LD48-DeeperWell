using Scriptables;
using UnityEngine;

namespace WellWellWell.UI
{
    public class GameHUD : MonoBehaviour
    {
        private static GameHUD s_instance;
        [SerializeField] private ProductionBuildingUI m_productionBuildingUI;
        [SerializeField] private CivilBuildingUI m_civilBuildingUI;
        [SerializeField] private WellUI m_wellUI;
        [SerializeField] private BuildingTooltip m_buildingTooltip;

        public static GameHUD Instance
        {
            get
            {
                if (s_instance == null)
                    s_instance = FindObjectOfType<GameHUD>();

                return s_instance;
            }
        }

        private void Awake()
        {
            if (s_instance == null)
            {
                s_instance = this;
            }
            else
            {
                Destroy(this);
            }
        }

        public void HideBuildingToolTip()
        {
            this.m_buildingTooltip.Hide();
        }

        public void ShowBuildingToolTip(ProductionBuildingData toShow)
        {
            this.m_buildingTooltip.Show(toShow);
        }

        public void ShowBuildingToolTip(CivilBuildingData toShow)
        {
            this.m_buildingTooltip.Show(toShow);
        }

        public void ShowCivilBuildingUI(CivilBuilding toShow)
        {
            this.m_productionBuildingUI.Hide();
            this.m_wellUI.Hide();
            this.m_civilBuildingUI.Show(toShow);
        }

        public void ShowProductionBuildingUI(ProductionBuilding toShow)
        {
            this.m_civilBuildingUI.Hide();
            this.m_wellUI.Hide();
            this.m_productionBuildingUI.Show(toShow);
        }

        public void ShowWellUI(Well well)
        {
            this.m_productionBuildingUI.Hide();
            this.m_civilBuildingUI.Hide();
            this.m_wellUI.Show(well);
        }
    }
}