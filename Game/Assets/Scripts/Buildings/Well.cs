using System.Linq;
using Scriptables;
using UnityEngine;
using WellWellWell.UI;

namespace WellWellWell
{
    public class Well : ProductionBuilding
    {
        [SerializeField] private WellUpgradeData m_wellUpgradeData;

        private int m_currentLevel;

        public WellUpgradeData CurrentUpgradeInfo => this.m_wellUpgradeData;
        public int CurrentLevel => this.m_currentLevel;

        public void UpgradeToNextLevel()
        {
            if (this.CanUpgrade())
            {
                foreach (var resourceUnlockCondition in this.m_wellUpgradeData.ResourceUnlockConditions)
                {
                    resourceUnlockCondition.Resource.ResourceController.TryUseResource(resourceUnlockCondition.Amount);
                }
            }
            
            this.m_currentProductionTimer = this.m_wellUpgradeData.NewProductionTime;

            foreach (var buildingToUnlock in this.m_wellUpgradeData.BuildingsToUnlock)
            {
                buildingToUnlock.Unlock();
            }

            this.m_currentLevel++;
            this.m_wellUpgradeData = this.m_wellUpgradeData.FollowingUpgrade;
        }
        
        public override void ShowUI()
        {
            GameHUD.Instance.ShowWellUI(this);
        }

        public bool CanUpgrade()
        {
            var canAffordResources = this.m_wellUpgradeData.ResourceUnlockConditions.All(r => r.Resource.ResourceController.CanAfford(r.Amount));
            var populationReached  = this.m_wellUpgradeData.PopulationUnlockConditions.All(r => r.PopulationResource.ResourceController.CanAfford(r.NeededAmount));

            return canAffordResources && populationReached;
        }
    }
}