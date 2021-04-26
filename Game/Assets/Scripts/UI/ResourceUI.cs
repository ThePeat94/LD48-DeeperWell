using TMPro;
using UnityEngine;
using UnityEngine.UI;
using WellWellWell.EventArgs;

namespace WellWellWell.UI
{
    public class ResourceUI : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI m_text;
        [SerializeField] private Image m_icon;


        public void Show(Resource toShow)
        {
            this.m_text.text = $"{toShow.ResourceController.CurrentValue:0}";
            this.m_icon.sprite = toShow.Icon;
            toShow.ResourceController.ResourceValueChanged += this.ResourceValueChanged;
        }

        private void ResourceValueChanged(object sender, ResourceValueChangedEvent args)
        {
            this.m_text.text = $"{args.NewValue:0}";
        }
    }
}