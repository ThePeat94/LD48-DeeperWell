using UnityEngine;

namespace WellWellWell.Util
{
    [System.Serializable]
    public class PopulationUnlockCondition
    {
        [SerializeField] private Resource m_populationResource;
        [SerializeField] private int m_neededAmount;

        public Resource PopulationResource => this.m_populationResource;
        public int NeededAmount => this.m_neededAmount;
    }
}