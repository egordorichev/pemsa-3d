// GENERATED AUTOMATICALLY FROM 'Assets/Input/EmulatorInput.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @EmulatorInput : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @EmulatorInput()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""EmulatorInput"",
    ""maps"": [
        {
            ""name"": ""PemsaControls"",
            ""id"": ""b938d8b8-2e0e-4d90-94e2-bddcd5d0d5df"",
            ""actions"": [
                {
                    ""name"": ""Z"",
                    ""type"": ""Button"",
                    ""id"": ""ab16c33a-7656-4c64-94ad-b0601ae029ff"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""X"",
                    ""type"": ""Button"",
                    ""id"": ""eafcdac2-a5ac-498f-a230-abc5ebab2ca7"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Up"",
                    ""type"": ""Button"",
                    ""id"": ""7324d2f2-252d-41b5-b85b-410fdbd41937"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Down"",
                    ""type"": ""Button"",
                    ""id"": ""d1a20eda-b387-41df-a31e-2dea0ff64856"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Left"",
                    ""type"": ""Button"",
                    ""id"": ""e46753eb-b773-4da2-9bd9-66e08592b2f7"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Right"",
                    ""type"": ""Button"",
                    ""id"": ""081e9d7a-d891-4bdf-8c45-e62a356efa7c"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Analog"",
                    ""type"": ""Value"",
                    ""id"": ""e6adda82-03f8-4830-a24e-ac7aa05073aa"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Pause"",
                    ""type"": ""Button"",
                    ""id"": ""8a2ad894-ccf4-4a02-ad98-eabb1f5c75e2"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""65176cf4-eab4-4041-a4bf-0323db391074"",
                    ""path"": ""<Keyboard>/z"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""Z"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""fbd07710-ffd6-4b72-92c4-d3a85dd76ed9"",
                    ""path"": ""<Keyboard>/c"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""Z"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4b7ffb6a-3592-410d-9afb-67c728a21fa8"",
                    ""path"": ""<XInputController>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""GamePad"",
                    ""action"": ""Z"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""24f7f600-aaad-4f65-9b7b-a55a85cfc201"",
                    ""path"": ""<SwitchProControllerHID>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""GamePad"",
                    ""action"": ""Z"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""fa451efb-522c-48be-b24d-410110fd018b"",
                    ""path"": ""<DualShockGamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""GamePad"",
                    ""action"": ""Z"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6d0e6c95-03fd-4e0c-8471-0d59b3c4f707"",
                    ""path"": ""<Keyboard>/x"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""X"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a0718575-cc36-4550-827a-3bc199987a8a"",
                    ""path"": ""<XInputController>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""GamePad"",
                    ""action"": ""X"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b68d9512-59eb-448b-bebe-56c3213ba26b"",
                    ""path"": ""<SwitchProControllerHID>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""GamePad"",
                    ""action"": ""X"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4fd8953c-0343-45e4-947a-505db912c0d1"",
                    ""path"": ""<DualShockGamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""GamePad"",
                    ""action"": ""X"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2b31fe1f-a5ba-4b5a-850c-cffdec55d6bf"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""Up"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""179bdd87-5a14-489d-ac95-d52ba8f1dc49"",
                    ""path"": ""<Gamepad>/dpad/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""GamePad"",
                    ""action"": ""Up"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f9268c53-4fc9-4b04-8141-09b7d4b7bc6c"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""Down"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""de626dee-e809-4ba2-9802-3ffd76a20d3c"",
                    ""path"": ""<Gamepad>/dpad/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Down"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""110ff2d4-3c85-4967-bc54-b433ea171a0d"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""Left"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8b378df6-1290-4ca6-8c41-a4fc1d9a9d32"",
                    ""path"": ""<Gamepad>/dpad/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Left"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7f68fdb8-21c3-4c76-b59d-6432e5807f4b"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""Right"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3ca2d8fd-6756-4198-9e52-eeaf1a4bd3f4"",
                    ""path"": ""<Gamepad>/dpad/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Right"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""afe5d4f6-e5c8-4950-aad9-828d01db641e"",
                    ""path"": ""2DVector(mode=2)"",
                    ""interactions"": """",
                    ""processors"": ""NormalizeVector2"",
                    ""groups"": """",
                    ""action"": ""Analog"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""8ff4a735-dc28-420f-a556-2f8ba22c842f"",
                    ""path"": ""<Gamepad>/leftStick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""GamePad"",
                    ""action"": ""Analog"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""0b6f5508-9b3a-4dd6-a74d-2e46ac1eaf2b"",
                    ""path"": ""<Gamepad>/leftStick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""GamePad"",
                    ""action"": ""Analog"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""9b53b48a-3a25-4c3c-913e-31e7bc2dd5e4"",
                    ""path"": ""<Gamepad>/leftStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""GamePad"",
                    ""action"": ""Analog"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""447fc5f3-b120-49bf-8ea9-ad20138a7300"",
                    ""path"": ""<Gamepad>/leftStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""GamePad"",
                    ""action"": ""Analog"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""f31de7d3-3985-4952-a539-1b6fb0eb65ff"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""Pause"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f5f36f22-ab77-4b9a-8d36-ce731b7006c7"",
                    ""path"": ""<Gamepad>/start"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""GamePad"",
                    ""action"": ""Pause"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Keyboard and Mouse"",
            ""bindingGroup"": ""Keyboard and Mouse"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                },
                {
                    ""devicePath"": ""<Mouse>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        },
        {
            ""name"": ""GamePad"",
            ""bindingGroup"": ""GamePad"",
            ""devices"": [
                {
                    ""devicePath"": ""<XInputController>"",
                    ""isOptional"": false,
                    ""isOR"": false
                },
                {
                    ""devicePath"": ""<AndroidGamepad>"",
                    ""isOptional"": false,
                    ""isOR"": false
                },
                {
                    ""devicePath"": ""<iOSGameController>"",
                    ""isOptional"": false,
                    ""isOR"": false
                },
                {
                    ""devicePath"": ""<DualShockGamepad>"",
                    ""isOptional"": false,
                    ""isOR"": false
                },
                {
                    ""devicePath"": ""<SwitchProControllerHID>"",
                    ""isOptional"": false,
                    ""isOR"": false
                },
                {
                    ""devicePath"": ""<WebGLGamepad>"",
                    ""isOptional"": true,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // PemsaControls
        m_PemsaControls = asset.FindActionMap("PemsaControls", throwIfNotFound: true);
        m_PemsaControls_Z = m_PemsaControls.FindAction("Z", throwIfNotFound: true);
        m_PemsaControls_X = m_PemsaControls.FindAction("X", throwIfNotFound: true);
        m_PemsaControls_Up = m_PemsaControls.FindAction("Up", throwIfNotFound: true);
        m_PemsaControls_Down = m_PemsaControls.FindAction("Down", throwIfNotFound: true);
        m_PemsaControls_Left = m_PemsaControls.FindAction("Left", throwIfNotFound: true);
        m_PemsaControls_Right = m_PemsaControls.FindAction("Right", throwIfNotFound: true);
        m_PemsaControls_Analog = m_PemsaControls.FindAction("Analog", throwIfNotFound: true);
        m_PemsaControls_Pause = m_PemsaControls.FindAction("Pause", throwIfNotFound: true);
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

    // PemsaControls
    private readonly InputActionMap m_PemsaControls;
    private IPemsaControlsActions m_PemsaControlsActionsCallbackInterface;
    private readonly InputAction m_PemsaControls_Z;
    private readonly InputAction m_PemsaControls_X;
    private readonly InputAction m_PemsaControls_Up;
    private readonly InputAction m_PemsaControls_Down;
    private readonly InputAction m_PemsaControls_Left;
    private readonly InputAction m_PemsaControls_Right;
    private readonly InputAction m_PemsaControls_Analog;
    private readonly InputAction m_PemsaControls_Pause;
    public struct PemsaControlsActions
    {
        private @EmulatorInput m_Wrapper;
        public PemsaControlsActions(@EmulatorInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @Z => m_Wrapper.m_PemsaControls_Z;
        public InputAction @X => m_Wrapper.m_PemsaControls_X;
        public InputAction @Up => m_Wrapper.m_PemsaControls_Up;
        public InputAction @Down => m_Wrapper.m_PemsaControls_Down;
        public InputAction @Left => m_Wrapper.m_PemsaControls_Left;
        public InputAction @Right => m_Wrapper.m_PemsaControls_Right;
        public InputAction @Analog => m_Wrapper.m_PemsaControls_Analog;
        public InputAction @Pause => m_Wrapper.m_PemsaControls_Pause;
        public InputActionMap Get() { return m_Wrapper.m_PemsaControls; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PemsaControlsActions set) { return set.Get(); }
        public void SetCallbacks(IPemsaControlsActions instance)
        {
            if (m_Wrapper.m_PemsaControlsActionsCallbackInterface != null)
            {
                @Z.started -= m_Wrapper.m_PemsaControlsActionsCallbackInterface.OnZ;
                @Z.performed -= m_Wrapper.m_PemsaControlsActionsCallbackInterface.OnZ;
                @Z.canceled -= m_Wrapper.m_PemsaControlsActionsCallbackInterface.OnZ;
                @X.started -= m_Wrapper.m_PemsaControlsActionsCallbackInterface.OnX;
                @X.performed -= m_Wrapper.m_PemsaControlsActionsCallbackInterface.OnX;
                @X.canceled -= m_Wrapper.m_PemsaControlsActionsCallbackInterface.OnX;
                @Up.started -= m_Wrapper.m_PemsaControlsActionsCallbackInterface.OnUp;
                @Up.performed -= m_Wrapper.m_PemsaControlsActionsCallbackInterface.OnUp;
                @Up.canceled -= m_Wrapper.m_PemsaControlsActionsCallbackInterface.OnUp;
                @Down.started -= m_Wrapper.m_PemsaControlsActionsCallbackInterface.OnDown;
                @Down.performed -= m_Wrapper.m_PemsaControlsActionsCallbackInterface.OnDown;
                @Down.canceled -= m_Wrapper.m_PemsaControlsActionsCallbackInterface.OnDown;
                @Left.started -= m_Wrapper.m_PemsaControlsActionsCallbackInterface.OnLeft;
                @Left.performed -= m_Wrapper.m_PemsaControlsActionsCallbackInterface.OnLeft;
                @Left.canceled -= m_Wrapper.m_PemsaControlsActionsCallbackInterface.OnLeft;
                @Right.started -= m_Wrapper.m_PemsaControlsActionsCallbackInterface.OnRight;
                @Right.performed -= m_Wrapper.m_PemsaControlsActionsCallbackInterface.OnRight;
                @Right.canceled -= m_Wrapper.m_PemsaControlsActionsCallbackInterface.OnRight;
                @Analog.started -= m_Wrapper.m_PemsaControlsActionsCallbackInterface.OnAnalog;
                @Analog.performed -= m_Wrapper.m_PemsaControlsActionsCallbackInterface.OnAnalog;
                @Analog.canceled -= m_Wrapper.m_PemsaControlsActionsCallbackInterface.OnAnalog;
                @Pause.started -= m_Wrapper.m_PemsaControlsActionsCallbackInterface.OnPause;
                @Pause.performed -= m_Wrapper.m_PemsaControlsActionsCallbackInterface.OnPause;
                @Pause.canceled -= m_Wrapper.m_PemsaControlsActionsCallbackInterface.OnPause;
            }
            m_Wrapper.m_PemsaControlsActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Z.started += instance.OnZ;
                @Z.performed += instance.OnZ;
                @Z.canceled += instance.OnZ;
                @X.started += instance.OnX;
                @X.performed += instance.OnX;
                @X.canceled += instance.OnX;
                @Up.started += instance.OnUp;
                @Up.performed += instance.OnUp;
                @Up.canceled += instance.OnUp;
                @Down.started += instance.OnDown;
                @Down.performed += instance.OnDown;
                @Down.canceled += instance.OnDown;
                @Left.started += instance.OnLeft;
                @Left.performed += instance.OnLeft;
                @Left.canceled += instance.OnLeft;
                @Right.started += instance.OnRight;
                @Right.performed += instance.OnRight;
                @Right.canceled += instance.OnRight;
                @Analog.started += instance.OnAnalog;
                @Analog.performed += instance.OnAnalog;
                @Analog.canceled += instance.OnAnalog;
                @Pause.started += instance.OnPause;
                @Pause.performed += instance.OnPause;
                @Pause.canceled += instance.OnPause;
            }
        }
    }
    public PemsaControlsActions @PemsaControls => new PemsaControlsActions(this);
    private int m_KeyboardandMouseSchemeIndex = -1;
    public InputControlScheme KeyboardandMouseScheme
    {
        get
        {
            if (m_KeyboardandMouseSchemeIndex == -1) m_KeyboardandMouseSchemeIndex = asset.FindControlSchemeIndex("Keyboard and Mouse");
            return asset.controlSchemes[m_KeyboardandMouseSchemeIndex];
        }
    }
    private int m_GamePadSchemeIndex = -1;
    public InputControlScheme GamePadScheme
    {
        get
        {
            if (m_GamePadSchemeIndex == -1) m_GamePadSchemeIndex = asset.FindControlSchemeIndex("GamePad");
            return asset.controlSchemes[m_GamePadSchemeIndex];
        }
    }
    public interface IPemsaControlsActions
    {
        void OnZ(InputAction.CallbackContext context);
        void OnX(InputAction.CallbackContext context);
        void OnUp(InputAction.CallbackContext context);
        void OnDown(InputAction.CallbackContext context);
        void OnLeft(InputAction.CallbackContext context);
        void OnRight(InputAction.CallbackContext context);
        void OnAnalog(InputAction.CallbackContext context);
        void OnPause(InputAction.CallbackContext context);
    }
}
