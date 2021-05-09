using UnityEngine;

namespace WellWellWell.Util
{
    [System.Serializable]
    public class BuildingCost
    {
        [SerializeField] private Resource m_type;
        [SerializeField] private int m_cost;
        
        public Resource Type => this.m_type;
        public int Cost => this.m_cost;
    }
}