using System;
using UnityEngine;
using WellWellWell.Util;

namespace Scriptables
{
    public class BuildingData : ScriptableObject
    {       
        private EventHandler m_unlocked;
        
        [SerializeField] private string m_name;
        [SerializeField] private Sprite m_icon;
        [SerializeField] private BuildingCost[] m_costs;
        [SerializeField] private GameObject m_toPlace;
        [SerializeField] private bool m_isInitiallyLocked;
        
        public string Name => this.m_name;
        public Sprite Icon => this.m_icon;
        public BuildingCost[] Costs => this.m_costs;
        public GameObject ToPlace => this.m_toPlace;

        public bool IsInitiallyLocked => this.m_isInitiallyLocked;

        public void Unlock()
        {
            this.m_unlocked?.Invoke(this, EventArgs.Empty);
        }
        
        public event EventHandler Unlocked
        {
            add => this.m_unlocked += value;
            remove => this.m_unlocked -= value;
        }
    }
}