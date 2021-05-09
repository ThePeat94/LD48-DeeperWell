using UnityEngine;

namespace WellWellWell.Util
{
    [System.Serializable]
    public class ResourceConsumption
    {
        [SerializeField] private Resource m_resourceToConsume;
        [SerializeField] private float m_consumptionPerMinute;
        [SerializeField] private int m_extraInhibitants;

        public Resource ResourceToConsume => this.m_resourceToConsume;
        public float ConsumptionPerMinute => this.m_consumptionPerMinute;
        public int ExtraInhibitants => this.m_extraInhibitants;
    }
}