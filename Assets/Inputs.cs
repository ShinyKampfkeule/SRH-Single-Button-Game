// GENERATED AUTOMATICALLY FROM 'Assets/Inputs.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @Inputs : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @Inputs()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""Inputs"",
    ""maps"": [
        {
            ""name"": ""Main"",
            ""id"": ""908c06e6-cd44-484c-b56f-bdce11542c79"",
            ""actions"": [
                {
                    ""name"": ""Tap"",
                    ""type"": ""Button"",
                    ""id"": ""2c83aa8a-1b88-4ea3-a53c-647630e6093e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Hold"",
                    ""type"": ""Button"",
                    ""id"": ""124c35b5-50a4-451d-a618-ff0ebd054099"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""DoubleTap"",
                    ""type"": ""Button"",
                    ""id"": ""a5ffb593-6ed8-486b-a72e-f51edc164501"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Exit"",
                    ""type"": ""Button"",
                    ""id"": ""c8f82dcd-87f7-4f9e-8320-b2f2f26cd0e7"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""80e73670-78b0-4d78-879e-e4ba2d08c255"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": ""MultiTap(tapDelay=0.2)"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""DoubleTap"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""814a9fbb-6a13-43a0-9192-9db294708bc0"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": ""Hold(duration=0.2)"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Hold"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""82e6eca9-e98b-43e8-94d8-b1af26f34194"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": ""Tap"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Tap"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""bd16ada2-bea5-49a9-812f-dab0f732e0c7"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": ""Tap"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Exit"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Main
        m_Main = asset.FindActionMap("Main", throwIfNotFound: true);
        m_Main_Tap = m_Main.FindAction("Tap", throwIfNotFound: true);
        m_Main_Hold = m_Main.FindAction("Hold", throwIfNotFound: true);
        m_Main_DoubleTap = m_Main.FindAction("DoubleTap", throwIfNotFound: true);
        m_Main_Exit = m_Main.FindAction("Exit", throwIfNotFound: true);
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

    // Main
    private readonly InputActionMap m_Main;
    private IMainActions m_MainActionsCallbackInterface;
    private readonly InputAction m_Main_Tap;
    private readonly InputAction m_Main_Hold;
    private readonly InputAction m_Main_DoubleTap;
    private readonly InputAction m_Main_Exit;
    public struct MainActions
    {
        private @Inputs m_Wrapper;
        public MainActions(@Inputs wrapper) { m_Wrapper = wrapper; }
        public InputAction @Tap => m_Wrapper.m_Main_Tap;
        public InputAction @Hold => m_Wrapper.m_Main_Hold;
        public InputAction @DoubleTap => m_Wrapper.m_Main_DoubleTap;
        public InputAction @Exit => m_Wrapper.m_Main_Exit;
        public InputActionMap Get() { return m_Wrapper.m_Main; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(MainActions set) { return set.Get(); }
        public void SetCallbacks(IMainActions instance)
        {
            if (m_Wrapper.m_MainActionsCallbackInterface != null)
            {
                @Tap.started -= m_Wrapper.m_MainActionsCallbackInterface.OnTap;
                @Tap.performed -= m_Wrapper.m_MainActionsCallbackInterface.OnTap;
                @Tap.canceled -= m_Wrapper.m_MainActionsCallbackInterface.OnTap;
                @Hold.started -= m_Wrapper.m_MainActionsCallbackInterface.OnHold;
                @Hold.performed -= m_Wrapper.m_MainActionsCallbackInterface.OnHold;
                @Hold.canceled -= m_Wrapper.m_MainActionsCallbackInterface.OnHold;
                @DoubleTap.started -= m_Wrapper.m_MainActionsCallbackInterface.OnDoubleTap;
                @DoubleTap.performed -= m_Wrapper.m_MainActionsCallbackInterface.OnDoubleTap;
                @DoubleTap.canceled -= m_Wrapper.m_MainActionsCallbackInterface.OnDoubleTap;
                @Exit.started -= m_Wrapper.m_MainActionsCallbackInterface.OnExit;
                @Exit.performed -= m_Wrapper.m_MainActionsCallbackInterface.OnExit;
                @Exit.canceled -= m_Wrapper.m_MainActionsCallbackInterface.OnExit;
            }
            m_Wrapper.m_MainActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Tap.started += instance.OnTap;
                @Tap.performed += instance.OnTap;
                @Tap.canceled += instance.OnTap;
                @Hold.started += instance.OnHold;
                @Hold.performed += instance.OnHold;
                @Hold.canceled += instance.OnHold;
                @DoubleTap.started += instance.OnDoubleTap;
                @DoubleTap.performed += instance.OnDoubleTap;
                @DoubleTap.canceled += instance.OnDoubleTap;
                @Exit.started += instance.OnExit;
                @Exit.performed += instance.OnExit;
                @Exit.canceled += instance.OnExit;
            }
        }
    }
    public MainActions @Main => new MainActions(this);
    public interface IMainActions
    {
        void OnTap(InputAction.CallbackContext context);
        void OnHold(InputAction.CallbackContext context);
        void OnDoubleTap(InputAction.CallbackContext context);
        void OnExit(InputAction.CallbackContext context);
    }
}
