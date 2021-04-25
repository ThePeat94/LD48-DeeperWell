using System;
using UnityEngine;
using WellWellWell;
using WellWellWell.Util;

namespace Scriptables
{
    [CreateAssetMenu(fileName = "Production Building", menuName = "Data/Production Building", order = 0)]
    public class ProductionBuildingData : BuildingData
    {
        [SerializeField] private Resource m_produces;
        [SerializeField] private Resource[] m_needsToProduce;
        [SerializeField] private float m_secondsToProduce;
        [SerializeField] private WorkforceConsumption m_workforceConsumption;
        public Resource Produces => this.m_produces;
        public Resource[] NeedsToProduce => this.m_needsToProduce;
        public float SecondsToProduce => this.m_secondsToProduce;
        public WorkforceConsumption WorkforceConsumption => this.m_workforceConsumption;
    }
}