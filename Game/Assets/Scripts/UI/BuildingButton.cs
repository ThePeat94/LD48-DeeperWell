using Scriptables;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace WellWellWell.UI
{
    public class BuildingButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        [SerializeField] private BuildingData m_buildingData;
        [SerializeField] private Button m_button;
        [SerializeField] private Image m_icon;

        private void Awake()
        {
            this.m_button = this.GetComponent<Button>();
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            if (this.m_buildingData.GetType() == typeof(ProductionBuildingData))
                GameHUD.Instance.ShowBuildingToolTip(this.m_buildingData as ProductionBuildingData);
            else if (this.m_buildingData.GetType() == typeof(CivilBuildingData))
                GameHUD.Instance.ShowBuildingToolTip(this.m_buildingData as CivilBuildingData);
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            GameHUD.Instance.HideBuildingToolTip();
        }

        public void OnClick()
        {
            MouseController.Instance.StartBuilding(this.m_buildingData);
        }

        public void Show(BuildingData buildingData)
        {
            this.m_buildingData = buildingData;
            this.m_icon.sprite = buildingData.Icon;
            this.m_buildingData.Unlocked += this.HandleUnlock;
            this.m_button.interactable = !this.m_buildingData.IsInitiallyLocked;
        }

        private void HandleUnlock(object sender, System.EventArgs args)
        {
            this.m_button.interactable = true;
        }
    }
}