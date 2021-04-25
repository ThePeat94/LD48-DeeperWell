using System;
using TMPro;
using UnityEngine;
using WellWellWell.EventArgs;

namespace WellWellWell.UI
{
    public class ResourceUI : MonoBehaviour
    {
        [SerializeField] private Resource m_resourceToDisplay;
        [SerializeField] private TextMeshProUGUI m_text;

        private void Awake()
        {
            this.m_resourceToDisplay.ResourceController.ResourceValueChanged += this.ResourceValueChanged;
        }

        private void Start()
        {
            this.m_text.text = $"{this.m_resourceToDisplay.ResourceController.CurrentValue:0}";
        }

        private void ResourceValueChanged(object sender, ResourceValueChangedEvent args)
        {
            this.m_text.text = $"{args.NewValue:0}";
        }
    }
}