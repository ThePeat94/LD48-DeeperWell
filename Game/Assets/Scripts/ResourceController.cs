using System;
using UnityEngine;
using WellWellWell.EventArgs;

namespace WellWellWell
{
    public class ResourceController
    {
        private readonly object m_lock;
        private EventHandler<ResourceValueChangedEvent> m_maxValueChanged;
        private EventHandler<ResourceValueChangedEvent> m_resourceValueChanged;

        public ResourceController(IResourceData data)
        {
            this.MaxValue = data.InitMaxValue;
            this.CurrentValue = data.StartValue;
            this.m_lock = new object();
        }

        public float CurrentValue { get; private set; }
        public float MaxValue { get; private set; }

        public void Add(float value)
        {
            if (value < 0)
                throw new ArgumentException($"{nameof(value)} is less than 0");

            lock (this.m_lock)
            {
                this.CurrentValue = Mathf.Clamp(this.CurrentValue + value, 0, this.MaxValue);
            }

            this.m_resourceValueChanged?.Invoke(this, new ResourceValueChangedEvent(this.CurrentValue));
        }

        public void CalulateDelta(float amount)
        {
            lock (this.m_lock)
            {
                this.CurrentValue += amount;
            }

            this.m_resourceValueChanged?.Invoke(this, new ResourceValueChangedEvent(this.CurrentValue));
        }

        public bool CanAfford(float amount)
        {
            if (amount < 0)
                throw new ArgumentException($"{nameof(amount)} is less than 0");

            lock (this.m_lock)
            {
                return this.CurrentValue >= 0 && amount <= this.CurrentValue;
            }
        }

        public void IncreaseMaximum(float value)
        {
            if (value < 0)
                throw new ArgumentException($"{nameof(value)} is less than 0");

            lock (this.m_lock)
            {
                this.MaxValue += value;
            }

            this.m_maxValueChanged?.Invoke(this, new ResourceValueChangedEvent(this.MaxValue));
        }

        public void ResetValue()
        {
            this.CurrentValue = this.MaxValue;
            this.m_resourceValueChanged?.Invoke(this, new ResourceValueChangedEvent(this.CurrentValue));
        }

        public void SetValue(float value)
        {
            if (value < 0)
                throw new ArgumentException($"{nameof(value)} is less than 0");

            lock (this.m_lock)
            {
                this.CurrentValue = Mathf.Clamp(value, 0, this.MaxValue);
            }

            this.m_resourceValueChanged?.Invoke(this, new ResourceValueChangedEvent(this.CurrentValue));
        }

        public bool TryUseResource(float amount)
        {
            if (amount < 0)
                throw new ArgumentException($"{nameof(amount)} is less than 0");

            lock (this.m_lock)
            {
                if (amount > this.CurrentValue)
                    return false;
                this.CurrentValue -= amount;
            }

            this.m_resourceValueChanged?.Invoke(this, new ResourceValueChangedEvent(this.CurrentValue));
            return true;
        }

        public event EventHandler<ResourceValueChangedEvent> ResourceValueChanged
        {
            add => this.m_resourceValueChanged += value;
            remove => this.m_resourceValueChanged -= value;
        }

        public event EventHandler<ResourceValueChangedEvent> MaxValueChanged
        {
            add => this.m_maxValueChanged += value;
            remove => this.m_maxValueChanged -= value;
        }
    }
}