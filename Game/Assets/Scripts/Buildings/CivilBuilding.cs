using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Scriptables;
using UnityEditor;
using UnityEngine;
using WellWellWell.UI;
using WellWellWell.Util;

namespace WellWellWell
{
    public class CivilBuilding : Building
    {
        [SerializeField] private CivilBuildingData m_data;
        private int m_currentInhabitants;
        
        private Dictionary<Resource, int> m_currentExtraInhibitantsPerResource;
        private Coroutine m_consumptionCoroutine;

        public int CurrentInhabitants => this.m_currentInhabitants;
        public CivilBuildingData Data => this.m_data;


        private void Awake()
        {
            this.m_currentExtraInhibitantsPerResource = this.m_data.ConsumptionPerInhibitant.ToDictionary(c => c.ResourceToConsume, c => 0);
        }

        private void Start()
        {
            this.StartCoroutine(this.Consume());
        }

        public override void ShowUI()
        {
            GameHUD.Instance.ShowCivilBuildingUI(this);
        }

        public int GetCurrentExtraInhabitantsForResource(Resource resource)
        {
            return this.m_currentExtraInhibitantsPerResource[resource];
        }

        private IEnumerator Consume()
        {
            while (true)
            {
                yield return new WaitForSeconds(1f);
                foreach (var consumption in this.m_data.ConsumptionPerInhibitant)
                {
                    this.Consume(consumption);
                }
            }
        }

        private void Consume(ResourceConsumption consumption)
        {
            var consumptionAmount = (consumption.ConsumptionPerMinute * this.m_currentInhabitants)/60f;
            var oldAmount = this.m_currentInhabitants;
            if (consumption.ResourceToConsume.ResourceController.CanAfford(consumptionAmount))
            {
                consumption.ResourceToConsume.ResourceController.TryUseResource(consumptionAmount);
                if (this.m_currentExtraInhibitantsPerResource[consumption.ResourceToConsume] <= consumption.ExtraInhibitants)
                {
                    this.m_currentInhabitants -= this.m_currentExtraInhibitantsPerResource[consumption.ResourceToConsume];
                    this.m_currentExtraInhibitantsPerResource[consumption.ResourceToConsume] = consumption.ExtraInhibitants;
                    this.m_currentInhabitants += this.m_currentExtraInhibitantsPerResource[consumption.ResourceToConsume];
                }
            }
            else
            {
                this.m_currentInhabitants -= this.m_currentExtraInhibitantsPerResource[consumption.ResourceToConsume];
                this.m_currentExtraInhibitantsPerResource[consumption.ResourceToConsume] = 0;
            }
            this.m_currentInhabitants = Mathf.Clamp(this.m_currentInhabitants, 0, this.m_data.MaxInhibitants);
            this.m_data.GlobalHumanResource.ResourceController.CalulateDelta(this.m_currentInhabitants - oldAmount);
        }
    }
}