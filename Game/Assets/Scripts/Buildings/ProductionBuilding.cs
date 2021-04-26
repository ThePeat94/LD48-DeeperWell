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

        protected float m_currentProductionTimer;
        private Coroutine m_productionRoutine;

        private WaitForSeconds m_waitForSeconds;

        public bool IsPaused { get; private set; }

        public ProductionBuildingData Data => this.m_data;

        public float CurrentProductionTimer => this.m_currentProductionTimer;

        private void Awake()
        {
            this.m_waitForSeconds = new WaitForSeconds(this.m_data.SecondsToProduce);
            this.m_currentProductionTimer = this.m_data.SecondsToProduce;
        }

        private void Update()
        {
            if (this.m_productionRoutine == null && !this.IsPaused)
                this.m_productionRoutine = this.StartCoroutine(this.Produce());
        }

        public void Continue()
        {
            this.IsPaused = false;
            var workforceConsumption = this.m_data.WorkforceConsumption;
            workforceConsumption.HumanResource.ResourceController.CalulateDelta(-workforceConsumption.Amount);
        }

        public override void Destruct()
        {
            foreach (var cost in this.m_data.Costs)
                cost.Type.ResourceController.Add(cost.Cost);

            this.StopCoroutine(this.m_productionRoutine);
            this.m_data.WorkforceConsumption.HumanResource.ResourceController.Add(this.m_data.WorkforceConsumption.Amount);
            Destroy(this.gameObject);
        }

        public void Pause()
        {
            this.IsPaused = true;
            this.StopCoroutine(this.m_productionRoutine);
            this.m_productionRoutine = null;
            var workforceConsumption = this.m_data.WorkforceConsumption;
            workforceConsumption.HumanResource.ResourceController.CalulateDelta(workforceConsumption.Amount);
        }

        public override void ShowUI()
        {
            GameHUD.Instance.ShowProductionBuildingUI(this);
        }

        public void ToggleProduction()
        {
            if (this.IsPaused)
                this.Continue();
            else
                this.Pause();
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
                    consuming.ResourceController.TryUseResource(1);
            }

            yield return this.m_waitForSeconds;
            this.m_data.Resource.ResourceController.Add(1);
            this.m_productionRoutine = null;
        }
    }
}