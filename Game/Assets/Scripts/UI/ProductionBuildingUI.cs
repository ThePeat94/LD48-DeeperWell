using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace WellWellWell.UI
{
    public class ProductionBuildingUI : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI m_titleText;
        [SerializeField] private GameObject m_neededResourcesLayout;
        [SerializeField] private Image m_resultImage;
        [SerializeField] private GameObject m_neededResourcePrefab;
        [SerializeField] private Image m_buildingIcon;
        [SerializeField] private Button m_toggleWorkButton;

        [SerializeField] private Sprite m_pausedSprite;
        [SerializeField] private Sprite m_workingSprite;

        private ProductionBuilding m_currentDisplayedBuilding;

        public void DestructBuilding()
        {
            this.Hide();
            this.m_currentDisplayedBuilding.Destruct();
        }

        public void Hide()
        {
            this.gameObject.SetActive(false);
        }

        public void Show(ProductionBuilding building)
        {
            this.ClearNeededResources();
            this.m_currentDisplayedBuilding = building;
            this.m_titleText.text = this.m_currentDisplayedBuilding.Data.Name;
            var showTimePlus = false;

            if (this.m_currentDisplayedBuilding.Data.NeedsToProduce.Length > 0)
            {
                showTimePlus = true;
                NeededResourceRow last = null;
                foreach (var neededResource in this.m_currentDisplayedBuilding.Data.NeedsToProduce)
                {
                    var row = Instantiate(this.m_neededResourcePrefab, this.m_neededResourcesLayout.transform).GetComponent<NeededResourceRow>();
                    row.Show(neededResource);
                    row.SetPlusVisibility(last != null);
                    last = row;
                }
            }

            var timeRow = Instantiate(this.m_neededResourcePrefab, this.m_neededResourcesLayout.transform).GetComponent<NeededResourceRow>();
            timeRow.ShowTime(this.m_currentDisplayedBuilding.Data.SecondsToProduce, showTimePlus);

            this.m_resultImage.sprite = this.m_currentDisplayedBuilding.Data.Resource.Icon;
            this.m_buildingIcon.sprite = building.Data.Icon;
            this.m_toggleWorkButton.image.sprite = this.m_pausedSprite;
            this.gameObject.SetActive(true);
        }

        public void ToggleCurrentBuilding()
        {
            this.m_currentDisplayedBuilding.ToggleProduction();
            this.m_toggleWorkButton.image.sprite = this.m_currentDisplayedBuilding.IsPaused ? this.m_workingSprite : this.m_pausedSprite;
        }

        private void ClearNeededResources()
        {
            foreach (Transform child in this.m_neededResourcesLayout.transform)
                Destroy(child.gameObject);
        }
    }
}