using System;
using TMPro;
using UnityEngine;
using WellWellWell.Util;

namespace WellWellWell
{
    [CreateAssetMenu(fileName = "Resource", menuName = "Data/Resource", order = 0)]
    public class Resource : ScriptableObject, IResourceData
    {
        [SerializeField] private int m_initMaxValue;
        [SerializeField] private int m_startValue;
        [SerializeField] private Sprite m_icon;
        [SerializeField] private string m_resourceName;

        private ResourceController m_resourceController;
        public int InitMaxValue => this.m_initMaxValue;
        public int StartValue => this.m_startValue;
        public ResourceController ResourceController => this.m_resourceController;
        public Sprite Icon => this.m_icon;
        public string Name => this.m_resourceName;

        private void OnValidate()
        {
            this.m_resourceController = new ResourceController(this);
        }
    }
}