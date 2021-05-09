using UnityEngine;

namespace WellWellWell
{
    [CreateAssetMenu(fileName = "Resource", menuName = "Data/Resource", order = 0)]
    public class Resource : ScriptableObject, IResourceData
    {
        [SerializeField] private int m_initMaxValue;
        [SerializeField] private int m_startValue;
        [SerializeField] private Sprite m_icon;
        [SerializeField] private string m_resourceName;

        public ResourceController ResourceController { get; private set; }

        public Sprite Icon => this.m_icon;
        public string Name => this.m_resourceName;

        private void Awake()
        {
            this.ResourceController = new ResourceController(this);
        }

        private void OnValidate()
        {
            this.ResourceController = new ResourceController(this);
        }

        public int InitMaxValue => this.m_initMaxValue;
        public int StartValue => this.m_startValue;
    }
}