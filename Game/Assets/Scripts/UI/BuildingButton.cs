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
        public void OnClick()
        {
            MouseController.Instance.StartBuilding(this.m_buildingData);
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            Debug.Log("Hovering button");
            // Show Tooltip
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            Debug.Log("Button is leaving");
            // Hide Tooltip
        }
    }
}