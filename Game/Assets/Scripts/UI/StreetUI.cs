using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace WellWellWell.UI
{
    public class StreetUI : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI m_streetName;
        [SerializeField] private Image m_icon;

        private StreetBuilding m_street;

        public void Destruct()
        {
            this.Hide();
            this.m_street.Destruct();
        }

        public void Hide()
        {
            this.gameObject.SetActive(false);
        }

        public void Show(StreetBuilding toShow)
        {
            this.gameObject.SetActive(true);
            this.m_streetName.text = toShow.Data.Name;
            this.m_icon.sprite = toShow.Data.Icon;
            this.m_street = toShow;
        }
    }
}