// GENERATED AUTOMATICALLY FROM 'Assets/Input/PlayerInput.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @PlayerInput : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerInput()
    {
        asset = InputActionAsset.FromJson(@"{
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
                },
                {
                    ""name"": ""Quit"",
                    ""type"": ""Button"",
                    ""id"": ""42d0c954-d71c-4760-8de0-cfc6e74ece9a"",
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
                },
                {
                    ""name"": """",
                    ""id"": ""a3db9841-fe0c-42b6-974a-2c65fb026f15"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Quit"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Actions
        m_Actions = asset.FindActionMap("Actions", throwIfNotFound: true);
        m_Actions_Click = m_Actions.FindAction("Click", throwIfNotFound: true);
        m_Actions_RightClick = m_Actions.FindAction("RightClick", throwIfNotFound: true);
        m_Actions_Rotate = m_Actions.FindAction("Rotate", throwIfNotFound: true);
        m_Actions_Destroy = m_Actions.FindAction("Destroy", throwIfNotFound: true);
        m_Actions_MousePosition = m_Actions.FindAction("MousePosition", throwIfNotFound: true);
        m_Actions_CameraMovement = m_Actions.FindAction("CameraMovement", throwIfNotFound: true);
        m_Actions_Sprint = m_Actions.FindAction("Sprint", throwIfNotFound: true);
        m_Actions_Quit = m_Actions.FindAction("Quit", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }

    // Actions
    private readonly InputActionMap m_Actions;
    private IActionsActions m_ActionsActionsCallbackInterface;
    private readonly InputAction m_Actions_Click;
    private readonly InputAction m_Actions_RightClick;
    private readonly InputAction m_Actions_Rotate;
    private readonly InputAction m_Actions_Destroy;
    private readonly InputAction m_Actions_MousePosition;
    private readonly InputAction m_Actions_CameraMovement;
    private readonly InputAction m_Actions_Sprint;
    private readonly InputAction m_Actions_Quit;
    public struct ActionsActions
    {
        private @PlayerInput m_Wrapper;
        public ActionsActions(@PlayerInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @Click => m_Wrapper.m_Actions_Click;
        public InputAction @RightClick => m_Wrapper.m_Actions_RightClick;
        public InputAction @Rotate => m_Wrapper.m_Actions_Rotate;
        public InputAction @Destroy => m_Wrapper.m_Actions_Destroy;
        public InputAction @MousePosition => m_Wrapper.m_Actions_MousePosition;
        public InputAction @CameraMovement => m_Wrapper.m_Actions_CameraMovement;
        public InputAction @Sprint => m_Wrapper.m_Actions_Sprint;
        public InputAction @Quit => m_Wrapper.m_Actions_Quit;
        public InputActionMap Get() { return m_Wrapper.m_Actions; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(ActionsActions set) { return set.Get(); }
        public void SetCallbacks(IActionsActions instance)
        {
            if (m_Wrapper.m_ActionsActionsCallbackInterface != null)
            {
                @Click.started -= m_Wrapper.m_ActionsActionsCallbackInterface.OnClick;
                @Click.performed -= m_Wrapper.m_ActionsActionsCallbackInterface.OnClick;
                @Click.canceled -= m_Wrapper.m_ActionsActionsCallbackInterface.OnClick;
                @RightClick.started -= m_Wrapper.m_ActionsActionsCallbackInterface.OnRightClick;
                @RightClick.performed -= m_Wrapper.m_ActionsActionsCallbackInterface.OnRightClick;
                @RightClick.canceled -= m_Wrapper.m_ActionsActionsCallbackInterface.OnRightClick;
                @Rotate.started -= m_Wrapper.m_ActionsActionsCallbackInterface.OnRotate;
                @Rotate.performed -= m_Wrapper.m_ActionsActionsCallbackInterface.OnRotate;
                @Rotate.canceled -= m_Wrapper.m_ActionsActionsCallbackInterface.OnRotate;
                @Destroy.started -= m_Wrapper.m_ActionsActionsCallbackInterface.OnDestroy;
                @Destroy.performed -= m_Wrapper.m_ActionsActionsCallbackInterface.OnDestroy;
                @Destroy.canceled -= m_Wrapper.m_ActionsActionsCallbackInterface.OnDestroy;
                @MousePosition.started -= m_Wrapper.m_ActionsActionsCallbackInterface.OnMousePosition;
                @MousePosition.performed -= m_Wrapper.m_ActionsActionsCallbackInterface.OnMousePosition;
                @MousePosition.canceled -= m_Wrapper.m_ActionsActionsCallbackInterface.OnMousePosition;
                @CameraMovement.started -= m_Wrapper.m_ActionsActionsCallbackInterface.OnCameraMovement;
                @CameraMovement.performed -= m_Wrapper.m_ActionsActionsCallbackInterface.OnCameraMovement;
                @CameraMovement.canceled -= m_Wrapper.m_ActionsActionsCallbackInterface.OnCameraMovement;
                @Sprint.started -= m_Wrapper.m_ActionsActionsCallbackInterface.OnSprint;
                @Sprint.performed -= m_Wrapper.m_ActionsActionsCallbackInterface.OnSprint;
                @Sprint.canceled -= m_Wrapper.m_ActionsActionsCallbackInterface.OnSprint;
                @Quit.started -= m_Wrapper.m_ActionsActionsCallbackInterface.OnQuit;
                @Quit.performed -= m_Wrapper.m_ActionsActionsCallbackInterface.OnQuit;
                @Quit.canceled -= m_Wrapper.m_ActionsActionsCallbackInterface.OnQuit;
            }
            m_Wrapper.m_ActionsActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Click.started += instance.OnClick;
                @Click.performed += instance.OnClick;
                @Click.canceled += instance.OnClick;
                @RightClick.started += instance.OnRightClick;
                @RightClick.performed += instance.OnRightClick;
                @RightClick.canceled += instance.OnRightClick;
                @Rotate.started += instance.OnRotate;
                @Rotate.performed += instance.OnRotate;
                @Rotate.canceled += instance.OnRotate;
                @Destroy.started += instance.OnDestroy;
                @Destroy.performed += instance.OnDestroy;
                @Destroy.canceled += instance.OnDestroy;
                @MousePosition.started += instance.OnMousePosition;
                @MousePosition.performed += instance.OnMousePosition;
                @MousePosition.canceled += instance.OnMousePosition;
                @CameraMovement.started += instance.OnCameraMovement;
                @CameraMovement.performed += instance.OnCameraMovement;
                @CameraMovement.canceled += instance.OnCameraMovement;
                @Sprint.started += instance.OnSprint;
                @Sprint.performed += instance.OnSprint;
                @Sprint.canceled += instance.OnSprint;
                @Quit.started += instance.OnQuit;
                @Quit.performed += instance.OnQuit;
                @Quit.canceled += instance.OnQuit;
            }
        }
    }
    public ActionsActions @Actions => new ActionsActions(this);
    public interface IActionsActions
    {
        void OnClick(InputAction.CallbackContext context);
        void OnRightClick(InputAction.CallbackContext context);
        void OnRotate(InputAction.CallbackContext context);
        void OnDestroy(InputAction.CallbackContext context);
        void OnMousePosition(InputAction.CallbackContext context);
        void OnCameraMovement(InputAction.CallbackContext context);
        void OnSprint(InputAction.CallbackContext context);
        void OnQuit(InputAction.CallbackContext context);
    }
}
