using System.Collections.Generic;
using UnityEngine;

namespace WellWellWell
{
    public class PreviewBuilding : MonoBehaviour
    {
        [SerializeField] private Material m_availableMaterial;
        [SerializeField] private Material m_unavailableMaterial;
        private MeshRenderer[] m_renderer;

        private Dictionary<MeshRenderer, Material[]> m_rendererMaterialMap;

        public bool HitObstacles { get; private set; }

        private void Awake()
        {
            this.m_renderer = this.GetComponentsInChildren<MeshRenderer>();
            this.m_rendererMaterialMap = new Dictionary<MeshRenderer, Material[]>();
            foreach (var renderer in this.m_renderer)
                this.m_rendererMaterialMap.Add(renderer, renderer.materials);
        }

        private void Start()
        {
            this.SwapMaterials(new[] {this.m_availableMaterial});
        }

        private void OnDisable()
        {
            foreach (var renderMaterialMap in this.m_rendererMaterialMap)
                renderMaterialMap.Key.materials = renderMaterialMap.Value;
        }

        private void OnTriggerEnter(Collider other)
        {
            this.SwapMaterials(new[] {this.m_unavailableMaterial});
            this.HitObstacles = true;
        }

        private void OnTriggerExit(Collider other)
        {
            this.HitObstacles = false;
            this.SwapMaterials(new[] {this.m_availableMaterial});
        }

        private void OnTriggerStay(Collider other)
        {
            this.HitObstacles = true;
            this.SwapMaterials(new[] {this.m_unavailableMaterial});
        }

        public void TurnAvailable()
        {
            if (this.HitObstacles)
                return;

            this.SwapMaterials(new[] {this.m_availableMaterial});
        }

        public void TurnUnavailable()
        {
            this.SwapMaterials(new[] {this.m_unavailableMaterial});
        }

        private void SwapMaterials(Material[] materials)
        {
            foreach (var renderer in this.m_rendererMaterialMap.Keys)
                renderer.materials = materials;
        }
    }
}