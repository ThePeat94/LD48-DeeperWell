using System;
using System.Collections;
using System.Linq;
using Scriptables;
using UnityEngine;
using WellWellWell.UI;

namespace WellWellWell
{
    public class ProductionBuilding : Building
    {
        [SerializeField] private ProductionBuildingData m_data;

        private WaitForSeconds m_waitForSeconds;
        private Coroutine m_productionRoutine;
        private bool m_isPaused;
        
        protected float m_currentProductionTimer;

        public bool IsPaused => this.m_isPaused;
        public ProductionBuildingData Data => this.m_data;

        public float CurrentProductionTimer => this.m_currentProductionTimer;

        private void Awake()
        {
            this.m_waitForSeconds = new WaitForSeconds(this.m_data.SecondsToProduce);
            this.m_currentProductionTimer = this.m_data.SecondsToProduce;
        }

        private void Update()
        {
            if (this.m_productionRoutine == null && !this.m_isPaused)
            {
                this.m_productionRoutine = this.StartCoroutine(this.Produce());
            }
        }

        public override void ShowUI()
        {
            GameHUD.Instance.ShowProductionBuildingUI(this);
        }

        public void ToggleProduction()
        {
            if(this.m_isPaused)
                this.Continue();
            else
                this.Pause();
        }
        
        public void Pause()
        {
            this.m_isPaused = true;
            this.StopCoroutine(this.m_productionRoutine);
            this.m_productionRoutine = null;
            var workforceConsumption = this.m_data.WorkforceConsumption;
            workforceConsumption.HumanResource.ResourceController.CalulateDelta(workforceConsumption.Amount);
        }

        public void Continue()
        {
            this.m_isPaused = false;
            var workforceConsumption = this.m_data.WorkforceConsumption;
            workforceConsumption.HumanResource.ResourceController.CalulateDelta(-workforceConsumption.Amount);
        }

        private IEnumerator Produce()
        {
            if (this.m_data.NeedsToProduce.Length > 0)
            {
                if (!this.m_data.NeedsToProduce.All(r => r.ResourceController.CanAfford(1)))
                {
                    this.m_productionRoutine = null;
                    yield break;
                }
                foreach (var consuming in this.m_data.NeedsToProduce)
                {
                    consuming.ResourceController.TryUseResource(1);
                }
            }

            yield return this.m_waitForSeconds;
            this.m_data.Produces.ResourceController.Add(1);
            this.m_productionRoutine = null;
        }
    }
}