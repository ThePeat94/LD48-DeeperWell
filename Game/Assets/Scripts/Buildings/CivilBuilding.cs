using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Scriptables;
using UnityEngine;
using WellWellWell.UI;
using WellWellWell.Util;

namespace WellWellWell
{
    public class CivilBuilding : Building
    {
        [SerializeField] private CivilBuildingData m_data;
        private bool m_consume = true;
        private Coroutine m_consumptionCoroutine;

        private Dictionary<Resource, int> m_currentExtraInhibitantsPerResource;

        public int CurrentInhabitants { get; private set; }

        public CivilBuildingData Data => this.m_data;


        private void Awake()
        {
            this.m_currentExtraInhibitantsPerResource = this.m_data.ConsumptionPerInhibitant.ToDictionary(c => c.ResourceToConsume, c => 0);
        }

        private void Start()
        {
            this.StartCoroutine(this.Consume());
            HouseManager.Instance.AddBuilding(this);
        }

        public override void Destruct()
        {
            foreach (var cost in this.m_data.Costs)
                cost.Type.ResourceController.Add(cost.Cost);

            this.m_data.Resource.ResourceController.CalulateDelta(-this.CurrentInhabitants);
            this.m_consume = false;
            HouseManager.Instance.Remove(this);
            Destroy(this.gameObject);
        }

        public int GetCurrentExtraInhabitantsForResource(Resource resource)
        {
            return this.m_currentExtraInhibitantsPerResource[resource];
        }

        public int GetMaxExtraInhabitantsForResource(Resource resource)
        {
            return this.m_data.ConsumptionPerInhibitant.First(r => r.ResourceToConsume == resource).ExtraInhibitants;
        }

        public override void ShowUI()
        {
            GameHUD.Instance.ShowCivilBuildingUI(this);
        }

        private IEnumerator Consume()
        {
            while (this.m_consume)
            {
                yield return new WaitForSeconds(1f);
                foreach (var consumption in this.m_data.ConsumptionPerInhibitant)
                {
                    this.Consume(consumption);
                    yield return new WaitForEndOfFrame();
                }
            }

            this.m_consumptionCoroutine = null;
        }

        private void Consume(ResourceConsumption consumption)
        {
            var consumptionAmount = consumption.ConsumptionPerMinute * this.CurrentInhabitants / 60f;
            var oldAmount = this.CurrentInhabitants;
            if (consumption.ResourceToConsume.ResourceController.CanAfford(consumptionAmount))
            {
                consumption.ResourceToConsume.ResourceController.TryUseResource(consumptionAmount);
                if (this.m_currentExtraInhibitantsPerResource[consumption.ResourceToConsume] <= consumption.ExtraInhibitants)
                {
                    this.CurrentInhabitants -= this.m_currentExtraInhibitantsPerResource[consumption.ResourceToConsume];
                    this.m_currentExtraInhibitantsPerResource[consumption.ResourceToConsume] = consumption.ExtraInhibitants;
                    this.CurrentInhabitants += this.m_currentExtraInhibitantsPerResource[consumption.ResourceToConsume];
                }
            }
            else
            {
                this.CurrentInhabitants -= this.m_currentExtraInhibitantsPerResource[consumption.ResourceToConsume];
                this.m_currentExtraInhibitantsPerResource[consumption.ResourceToConsume] = 0;
            }

            this.CurrentInhabitants = Mathf.Clamp(this.CurrentInhabitants, 0, this.m_data.MaxInhibitants);
            this.m_data.Resource.ResourceController.CalulateDelta(this.CurrentInhabitants - oldAmount);
        }
    }
}