using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace WellWellWell.UI
{
    public class ProductionBuildingUI : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI m_titleText;
        [SerializeField] private TextMeshProUGUI m_plusTimeText;
        [SerializeField] private TextMeshProUGUI m_neededTimeText;
        [SerializeField] private GameObject m_neededResources;
        [SerializeField] private Image m_resultImage;

        private ProductionBuilding m_currentDisplayedBuilding;

        public void Show(ProductionBuilding building)
        {
            this.ClearNeededResources();
            this.m_currentDisplayedBuilding = building;
            this.m_titleText.text = this.m_currentDisplayedBuilding.Data.Name;
            if (this.m_currentDisplayedBuilding.Data.NeedsToProduce.Length == 0)
            {
                this.m_plusTimeText.text = string.Empty;
            }
            else
            {
                for (var i = 0; i < this.m_currentDisplayedBuilding.Data.NeedsToProduce.Length; i++)
                {
                    var currentRessource = this.m_currentDisplayedBuilding.Data.NeedsToProduce[i];
                    var imageGo = new GameObject();
                    imageGo.transform.parent = this.m_neededResources.transform;
                    var image = imageGo.AddComponent<Image>();
                    image.sprite = currentRessource.Icon;

                    if (i < this.m_currentDisplayedBuilding.Data.NeedsToProduce.Length)
                    {
                        var plusTextGo = new GameObject();
                        plusTextGo.transform.parent = this.m_neededResources.transform;
                        var plusText = plusTextGo.AddComponent<TextMeshProUGUI>();
                        plusText.text = "+";
                        plusText.verticalAlignment = VerticalAlignmentOptions.Middle;
                    }
                }
                this.m_plusTimeText.text = "+";
            }

            this.m_resultImage.sprite = this.m_currentDisplayedBuilding.Data.Produces.Icon;
            this.m_neededTimeText.text = $"{this.m_currentDisplayedBuilding.CurrentProductionTimer:0}";
            this.gameObject.SetActive(true);
        }

        public void Hide()
        {
            this.gameObject.SetActive(false);
        }

        public void ToggleCurrentBuilding()
        {
            this.m_currentDisplayedBuilding.ToggleProduction();
        }

        private void ClearNeededResources()
        {
            foreach (Transform child in this.m_neededResources.transform)
            {
                Destroy(child.gameObject);
            }
        }
    }
}