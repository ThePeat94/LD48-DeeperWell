// GENERATED AUTOMATICALLY FROM 'Assets/Input/PlayerInput.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;
using Object = UnityEngine.Object;

public class PlayerInput : IInputActionCollection, IDisposable
{
    // Actions
    private readonly InputActionMap m_Actions;
    private readonly InputAction m_Actions_CameraMovement;
    private readonly InputAction m_Actions_Click;
    private readonly InputAction m_Actions_Destroy;
    private readonly InputAction m_Actions_MousePosition;
    private readonly InputAction m_Actions_RightClick;
    private readonly InputAction m_Actions_Rotate;
    private readonly InputAction m_Actions_Sprint;
    private IActionsActions m_ActionsActionsCallbackInterface;

    public PlayerInput()
    {
        this.asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerInput"",
    ""maps"": [
        {
            ""name"": ""Actions"",
            ""id"": ""31318777-1404-478a-926d-2557c940dbe7"",
            ""actions"": [
                {
                    ""name"": ""Click"",
                    ""type"": ""Button"",
                    ""id"": ""e2457fdf-a9c2-4448-af1b-d803a105f268"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""RightClick"",
                    ""type"": ""Button"",
                    ""id"": ""47d8c7ab-3003-4839-af35-1955fcd19dda"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Rotate"",
                    ""type"": ""Button"",
                    ""id"": ""7050ec9a-2567-46a6-aeb4-9676a530f4fe"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Destroy"",
                    ""type"": ""Button"",
                    ""id"": ""6f8ec8cc-9422-42d0-addf-7058e70ff93f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""MousePosition"",
                    ""type"": ""Value"",
                    ""id"": ""48d6c548-3417-4a89-aada-5081b534e4bb"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""CameraMovement"",
                    ""type"": ""Value"",
                    ""id"": ""8a24e260-0279-48a8-a348-b090be1c395c"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Sprint"",
                    ""type"": ""Button"",
                    ""id"": ""f3612a7d-086e-4d14-86fe-d037e17ba2a2"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""b751fbfd-4d80-4afc-8f91-3064fc96c729"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Click"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""631e8ab8-44cd-4cd4-a1d2-195af7e04186"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RightClick"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6e0de6df-fd3a-49e4-affd-58efae8864a3"",
                    ""path"": ""<Mouse>/middleButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Rotate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""40fe16ba-2ec1-4e4b-8394-ed8e933f8ff1"",
                    ""path"": ""<Keyboard>/r"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Rotate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""fee52801-eb89-457b-9147-d2a020d8f643"",
                    ""path"": ""<Keyboard>/delete"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Destroy"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2d78edee-c205-46bd-a30e-161946df999e"",
                    ""path"": ""<Mouse>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MousePosition"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""627af984-e7b1-4609-bbbf-0732db908b4e"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""CameraMovement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""6c409f01-b6a9-45cd-825b-4dc7bfa49094"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""CameraMovement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""7b6e9ee2-09aa-40f9-979b-1c0a19b23962"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""CameraMovement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""70c221ed-7884-4644-b71e-d1fe3f826a11"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""CameraMovement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""297ae921-0c41-458a-ae3a-d185fb6e58d4"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""CameraMovement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""330abc6f-67b0-4675-b801-2e99c9e9d435"",
                    ""path"": ""<Keyboard>/shift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Sprint"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Actions
        this.m_Actions = this.asset.FindActionMap("Actions", true);
        this.m_Actions_Click = this.m_Actions.FindAction("Click", true);
        this.m_Actions_RightClick = this.m_Actions.FindAction("RightClick", true);
        this.m_Actions_Rotate = this.m_Actions.FindAction("Rotate", true);
        this.m_Actions_Destroy = this.m_Actions.FindAction("Destroy", true);
        this.m_Actions_MousePosition = this.m_Actions.FindAction("MousePosition", true);
        this.m_Actions_CameraMovement = this.m_Actions.FindAction("CameraMovement", true);
        this.m_Actions_Sprint = this.m_Actions.FindAction("Sprint", true);
    }

    public InputActionAsset asset { get; }
    public ActionsActions Actions => new ActionsActions(this);

    public void Dispose()
    {
        Object.Destroy(this.asset);
    }

    public InputBinding? bindingMask
    {
        get => this.asset.bindingMask;
        set => this.asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => this.asset.devices;
        set => this.asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => this.asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return this.asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return this.asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }

    public void Enable()
    {
        this.asset.Enable();
    }

    public void Disable()
    {
        this.asset.Disable();
    }

    public struct ActionsActions
    {
        private readonly PlayerInput m_Wrapper;

        public ActionsActions(PlayerInput wrapper)
        {
            this.m_Wrapper = wrapper;
        }

        public InputAction Click => this.m_Wrapper.m_Actions_Click;
        public InputAction RightClick => this.m_Wrapper.m_Actions_RightClick;
        public InputAction Rotate => this.m_Wrapper.m_Actions_Rotate;
        public InputAction Destroy => this.m_Wrapper.m_Actions_Destroy;
        public InputAction MousePosition => this.m_Wrapper.m_Actions_MousePosition;
        public InputAction CameraMovement => this.m_Wrapper.m_Actions_CameraMovement;
        public InputAction Sprint => this.m_Wrapper.m_Actions_Sprint;

        public InputActionMap Get()
        {
            return this.m_Wrapper.m_Actions;
        }

        public void Enable()
        {
            this.Get().Enable();
        }

        public void Disable()
        {
            this.Get().Disable();
        }

        public bool enabled => this.Get().enabled;

        public static implicit operator InputActionMap(ActionsActions set)
        {
            return set.Get();
        }

        public void SetCallbacks(IActionsActions instance)
        {
            if (this.m_Wrapper.m_ActionsActionsCallbackInterface != null)
            {
                this.Click.started -= this.m_Wrapper.m_ActionsActionsCallbackInterface.OnClick;
                this.Click.performed -= this.m_Wrapper.m_ActionsActionsCallbackInterface.OnClick;
                this.Click.canceled -= this.m_Wrapper.m_ActionsActionsCallbackInterface.OnClick;
                this.RightClick.started -= this.m_Wrapper.m_ActionsActionsCallbackInterface.OnRightClick;
                this.RightClick.performed -= this.m_Wrapper.m_ActionsActionsCallbackInterface.OnRightClick;
                this.RightClick.canceled -= this.m_Wrapper.m_ActionsActionsCallbackInterface.OnRightClick;
                this.Rotate.started -= this.m_Wrapper.m_ActionsActionsCallbackInterface.OnRotate;
                this.Rotate.performed -= this.m_Wrapper.m_ActionsActionsCallbackInterface.OnRotate;
                this.Rotate.canceled -= this.m_Wrapper.m_ActionsActionsCallbackInterface.OnRotate;
                this.Destroy.started -= this.m_Wrapper.m_ActionsActionsCallbackInterface.OnDestroy;
                this.Destroy.performed -= this.m_Wrapper.m_ActionsActionsCallbackInterface.OnDestroy;
                this.Destroy.canceled -= this.m_Wrapper.m_ActionsActionsCallbackInterface.OnDestroy;
                this.MousePosition.started -= this.m_Wrapper.m_ActionsActionsCallbackInterface.OnMousePosition;
                this.MousePosition.performed -= this.m_Wrapper.m_ActionsActionsCallbackInterface.OnMousePosition;
                this.MousePosition.canceled -= this.m_Wrapper.m_ActionsActionsCallbackInterface.OnMousePosition;
                this.CameraMovement.started -= this.m_Wrapper.m_ActionsActionsCallbackInterface.OnCameraMovement;
                this.CameraMovement.performed -= this.m_Wrapper.m_ActionsActionsCallbackInterface.OnCameraMovement;
                this.CameraMovement.canceled -= this.m_Wrapper.m_ActionsActionsCallbackInterface.OnCameraMovement;
                this.Sprint.started -= this.m_Wrapper.m_ActionsActionsCallbackInterface.OnSprint;
                this.Sprint.performed -= this.m_Wrapper.m_ActionsActionsCallbackInterface.OnSprint;
                this.Sprint.canceled -= this.m_Wrapper.m_ActionsActionsCallbackInterface.OnSprint;
            }

            this.m_Wrapper.m_ActionsActionsCallbackInterface = instance;
            if (instance != null)
            {
                this.Click.started += instance.OnClick;
                this.Click.performed += instance.OnClick;
                this.Click.canceled += instance.OnClick;
                this.RightClick.started += instance.OnRightClick;
                this.RightClick.performed += instance.OnRightClick;
                this.RightClick.canceled += instance.OnRightClick;
                this.Rotate.started += instance.OnRotate;
                this.Rotate.performed += instance.OnRotate;
                this.Rotate.canceled += instance.OnRotate;
                this.Destroy.started += instance.OnDestroy;
                this.Destroy.performed += instance.OnDestroy;
                this.Destroy.canceled += instance.OnDestroy;
                this.MousePosition.started += instance.OnMousePosition;
                this.MousePosition.performed += instance.OnMousePosition;
                this.MousePosition.canceled += instance.OnMousePosition;
                this.CameraMovement.started += instance.OnCameraMovement;
                this.CameraMovement.performed += instance.OnCameraMovement;
                this.CameraMovement.canceled += instance.OnCameraMovement;
                this.Sprint.started += instance.OnSprint;
                this.Sprint.performed += instance.OnSprint;
                this.Sprint.canceled += instance.OnSprint;
            }
        }
    }

    public interface IActionsActions
    {
        void OnCameraMovement(InputAction.CallbackContext context);
        void OnClick(InputAction.CallbackContext context);
        void OnDestroy(InputAction.CallbackContext context);
        void OnMousePosition(InputAction.CallbackContext context);
        void OnRightClick(InputAction.CallbackContext context);
        void OnRotate(InputAction.CallbackContext context);
        void OnSprint(InputAction.CallbackContext context);
    }
}