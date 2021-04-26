using UnityEngine;

namespace WellWellWell
{
    public class CameraController : MonoBehaviour
    {
        [SerializeField] private InputProcessor m_inputProcessor;
        [SerializeField] private float m_normalSpeed;
        [SerializeField] private float m_sprintSpeed;

        private float m_currentSpeed;

        private void Awake()
        {
            this.m_currentSpeed = this.m_normalSpeed;
            this.m_inputProcessor.SprintStarted += (sender, args) => this.m_currentSpeed = this.m_sprintSpeed;
            this.m_inputProcessor.SprintEnded += (sender, args) => this.m_currentSpeed = this.m_normalSpeed;
        }

        private void Update()
        {
            if (this.m_inputProcessor.Movement != Vector2.zero)
            {
                var movement = new Vector3(this.m_inputProcessor.Movement.x, 0f, this.m_inputProcessor.Movement.y);
                var target = this.transform.position + movement * this.m_currentSpeed * Time.unscaledDeltaTime;
                this.transform.position = target;
            }
        }
    }
}