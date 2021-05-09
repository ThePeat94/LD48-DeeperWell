using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace WellWellWell.UI
{
    public class NeededResourceRow : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI m_plusText;
        [SerializeField] private TextMeshProUGUI m_amountText;
        [SerializeField] private Image m_resourceIcon;

        [SerializeField] private Sprite m_timeSprite;

        public void SetPlusVisibility(bool show)
        {
            this.m_plusText.gameObject.SetActive(show);
        }

        public void Show(Resource toShow)
        {
            this.m_amountText.text = string.Empty;
            this.m_resourceIcon.sprite = toShow.Icon;
        }

        public void ShowTime(float time, bool showPlus)
        {
            this.m_amountText.text = $"{time:0}s";
            this.m_plusText.text = showPlus ? "+" : string.Empty;
            this.m_resourceIcon.sprite = this.m_timeSprite;
        }
    }
}