using UnityEngine;
using WellWellWell.Util;

namespace Scriptables
{
    [CreateAssetMenu(fileName = "Well Upgrade", menuName = "Data/Well Upgrade", order = 0)]
    public class WellUpgradeData : ScriptableObject
    {
        [SerializeField] private WellUpgradeData m_followingUpgrade;
        [SerializeField] private ResourceUnlockCondition[] m_resourceUnlockConditions;
        [SerializeField] private PopulationUnlockCondition[] m_populationUnlockConditions;
        [SerializeField] private ProductionBuildingData[] m_buildingsToUnlock;
        [SerializeField] private float m_newProductionTime;

        public WellUpgradeData FollowingUpgrade => this.m_followingUpgrade;
        public ResourceUnlockCondition[] ResourceUnlockConditions => this.m_resourceUnlockConditions;
        public PopulationUnlockCondition[] PopulationUnlockConditions => this.m_populationUnlockConditions;
        public ProductionBuildingData[] BuildingsToUnlock => this.m_buildingsToUnlock;
        public float NewProductionTime => this.m_newProductionTime;
    }
}