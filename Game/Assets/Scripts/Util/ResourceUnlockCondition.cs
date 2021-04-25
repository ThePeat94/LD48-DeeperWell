using UnityEngine;

namespace WellWellWell.Util
{
    [System.Serializable]
    public class ResourceUnlockCondition
    {
        [SerializeField] private Resource m_resource;
        [SerializeField] private float m_amount;

        public Resource Resource => this.m_resource;
        public float Amount => this.m_amount;
    }
}