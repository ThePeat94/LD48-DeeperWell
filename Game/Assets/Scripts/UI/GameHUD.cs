using Scriptables;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace WellWellWell.UI
{
    public class GameHUD : MonoBehaviour
    {
        private static GameHUD s_instance;
        [SerializeField] private ProductionBuildingUI m_productionBuildingUI;
        [SerializeField] private CivilBuildingUI m_civilBuildingUI;
        [SerializeField] private WellUI m_wellUI;
        [SerializeField] private BuildingTooltip m_buildingTooltip;
        [SerializeField] private BuildingData[] m_buildings;
        [SerializeField] private GameObject m_storageDisplayPrefab;
        [SerializeField] private GameObject m_storageLayout;
        [SerializeField] private GameObject m_separatorImagePrefab;
        [SerializeField] private StreetUI m_streetUI;
        [SerializeField] private GameObject m_winScreen;


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
                return;
            }

            foreach (var building in this.m_buildings)
                if (building.IsInitiallyLocked)
                    building.Unlocked += (sender, args) => this.ShowStorageDisplayForResource(building.Resource);
                else
                    this.ShowStorageDisplayForResource(building.Resource);
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

        public void ShowBuildingToolTip(BuildingData toShow)
        {
            this.m_buildingTooltip.Show(toShow);
        }

        public void ShowCivilBuildingUI(CivilBuilding toShow)
        {
            this.m_productionBuildingUI.Hide();
            this.m_wellUI.Hide();
            this.m_streetUI.Hide();
            this.m_civilBuildingUI.Show(toShow);
        }

        public void ShowProductionBuildingUI(ProductionBuilding toShow)
        {
            this.m_civilBuildingUI.Hide();
            this.m_wellUI.Hide();
            this.m_streetUI.Hide();
            this.m_productionBuildingUI.Show(toShow);
        }

        public void ShowStreetUI(StreetBuilding street)
        {
            this.m_productionBuildingUI.Hide();
            this.m_civilBuildingUI.Hide();
            this.m_wellUI.Hide();
            this.m_streetUI.Show(street);
        }

        public void ShowWellUI(Well well)
        {
            this.m_productionBuildingUI.Hide();
            this.m_civilBuildingUI.Hide();
            this.m_streetUI.Hide();
            this.m_wellUI.Show(well);
        }

        private void ShowStorageDisplayForResource(Resource toShow)
        {
            var newStorageDisplay = Instantiate(this.m_storageDisplayPrefab, this.m_storageLayout.transform).GetComponent<ResourceUI>();
            newStorageDisplay.Show(toShow);
            Instantiate(this.m_separatorImagePrefab, this.m_storageLayout.transform);
        }

        public void ShowWinScreen()
        {
            this.m_winScreen.SetActive(true);
        }

        public void CloseWinScreen()
        {
            this.m_winScreen.SetActive(false);
        }

        public void BackToMainMenu()
        {
            SceneManager.LoadScene(0);
        }

        public void CloseGame()
        {
            Application.Quit();
        }
    }
}