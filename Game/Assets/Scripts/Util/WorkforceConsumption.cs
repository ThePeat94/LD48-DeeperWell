using UnityEngine;

namespace WellWellWell.Util
{
    [System.Serializable]
    public class WorkforceConsumption
    {
        [SerializeField] private Resource m_humanResource;
        [SerializeField] private int m_amount;

        public Resource HumanResource => this.m_humanResource;
        public int Amount => this.m_amount;
    }
}