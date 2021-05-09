using System.Collections;
using System.Linq;
using Scriptables;
using UnityEngine;
using WellWellWell.UI;

namespace WellWellWell
{
    public class Well : ProductionBuilding
    {
        [SerializeField] private WellUpgradeData m_wellUpgradeData;

        public WellUpgradeData CurrentUpgradeInfo => this.m_wellUpgradeData;
        public int CurrentLevel { get; private set; }

        public bool CanUpgrade()
        {
            var canAffordResources = this.m_wellUpgradeData.ResourceUnlockConditions.All(r => r.Resource.ResourceController.CanAfford(r.Amount));
            var populationReached = this.m_wellUpgradeData.PopulationUnlockConditions.All(r => HouseManager.Instance.GetInhabitantsForResource(r.PopulationResource) >= r.NeededAmount);
            return canAffordResources && populationReached;
        }

        public override void Destruct()
        {
        }

        public override void ShowUI()
        {
            GameHUD.Instance.ShowWellUI(this);
        }

        public void UpgradeToNextLevel()
        {
            if (this.CanUpgrade())
                foreach (var resourceUnlockCondition in this.m_wellUpgradeData.ResourceUnlockConditions)
                    resourceUnlockCondition.Resource.ResourceController.TryUseResource(resourceUnlockCondition.Amount);

            this.m_currentProductionTimer = this.m_wellUpgradeData.NewProductionTime;

            foreach (var buildingToUnlock in this.m_wellUpgradeData.BuildingsToUnlock)
                buildingToUnlock.Unlock();

            this.CurrentLevel++;
            this.m_wellUpgradeData = this.m_wellUpgradeData.FollowingUpgrade;

            if (this.m_wellUpgradeData == null)
            {
                GameHUD.Instance.ShowWinScreen();
            }
        }

        protected override IEnumerator Produce()
        {
            yield return new WaitForEndOfFrame();
            this.m_data.Resource.ResourceController.Add(1f/this.m_currentProductionTimer * Time.deltaTime);
            this.m_productionRoutine = null;
        }
    }
}