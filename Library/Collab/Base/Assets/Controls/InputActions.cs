// GENERATED AUTOMATICALLY FROM 'Assets/Controls/InputActions.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class InputActions : IInputActionCollection, IDisposable
{
    private InputActionAsset asset;
    public InputActions()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""InputActions"",
    ""maps"": [
        {
            ""name"": ""Player"",
            ""id"": ""ed687916-6fb4-4317-a4e5-b20c856d8d62"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""5801937a-fb73-4910-8b31-bb63130126be"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""AimPointer"",
                    ""type"": ""Value"",
                    ""id"": ""5b88e7e8-43c5-4220-99ed-9b320d484f13"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""TileSelectionPointer"",
                    ""type"": ""Value"",
                    ""id"": ""5c7d107c-9336-4ddc-97dd-0a418c50c3f4"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""BasicAttack"",
                    ""type"": ""Value"",
                    ""id"": ""8c0506e9-0eef-4639-9c55-87c1dc5192cc"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": ""Press(behavior=2)""
                },
                {
                    ""name"": ""CastSpell"",
                    ""type"": ""Button"",
                    ""id"": ""b5201bd9-2a8c-4f6b-a55c-f63f2f6d929c"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""PrevSpell"",
                    ""type"": ""Button"",
                    ""id"": ""80fd6cec-7961-4afb-96e4-cd767980385e"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""NextSpell"",
                    ""type"": ""Button"",
                    ""id"": ""45b7a4f8-1842-4bad-b6bc-26bfad1410d3"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Dash"",
                    ""type"": ""Button"",
                    ""id"": ""3ea842ae-8d11-424e-926b-b5acc99441e0"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""978bfe49-cc26-4a3d-ab7b-7d7a29327403"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Gamepad"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c1f7a91b-d0fd-4a62-997e-7fb9b69bf235"",
                    ""path"": ""<Gamepad>/rightStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Gamepad"",
                    ""action"": ""AimPointer"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""143bb1cd-cc10-4eca-a2f0-a3664166fe91"",
                    ""path"": ""<Gamepad>/dpad"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Gamepad"",
                    ""action"": ""TileSelectionPointer"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""92464ad0-b8ce-4f4e-b89f-d92f3037cb18"",
                    ""path"": ""<Gamepad>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Gamepad"",
                    ""action"": ""BasicAttack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""647eadb8-911a-4433-a3cf-932ed2d625f7"",
                    ""path"": ""<Gamepad>/leftTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""CastSpell"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2dc082fb-6152-4c39-843b-2dd845518cec"",
                    ""path"": ""<Gamepad>/leftShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""PrevSpell"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""01409f88-ca92-4998-b7a1-f2597d31f1c3"",
                    ""path"": ""<Gamepad>/rightShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""NextSpell"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""88d1d868-a0b3-4916-bb0a-258fa2428e30"",
                    ""path"": ""<Gamepad>/leftStickPress"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Dash"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""UI"",
            ""id"": ""312808f3-5601-48b3-9b76-c065da0b731d"",
            ""actions"": [
                {
                    ""name"": ""Navigate"",
                    ""type"": ""Value"",
                    ""id"": ""5ab1d44b-4189-40eb-9cde-29a3f942e0a3"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Submit"",
                    ""type"": ""Button"",
                    ""id"": ""db11fd6a-28c3-45f7-87da-8d90a7fdb2d0"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Cancel"",
                    ""type"": ""Button"",
                    ""id"": ""c9b4908d-0249-4dad-870c-44610ddea2a4"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Point"",
                    ""type"": ""PassThrough"",
                    ""id"": ""ae36c363-6c7d-44e8-9489-a21fcadb3c22"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Click"",
                    ""type"": ""PassThrough"",
                    ""id"": ""57522d7e-a23b-4c49-bcbb-79efd37a76e0"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""ScrollWheel"",
                    ""type"": ""PassThrough"",
                    ""id"": ""6fb909d0-c1aa-408e-aa25-6b403470bae5"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""MiddleClick"",
                    ""type"": ""PassThrough"",
                    ""id"": ""7e231422-f43f-457d-999e-bfa8b000382a"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""RightClick"",
                    ""type"": ""PassThrough"",
                    ""id"": ""5a13b876-bb6b-4bd8-b1a8-cf995afe6f63"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""TrackedDevicePosition"",
                    ""type"": ""PassThrough"",
                    ""id"": ""38c28850-4f13-460d-9799-41555852b822"",
                    ""expectedControlType"": ""Vector3"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""TrackedDeviceOrientation"",
                    ""type"": ""PassThrough"",
                    ""id"": ""80e9e2fb-8294-4159-b5d9-88ff6b11b168"",
                    ""expectedControlType"": ""Quaternion"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""TrackedDeviceSelect"",
                    ""type"": ""PassThrough"",
                    ""id"": ""3a95e24d-23d5-4049-a270-5827f1fc8ea2"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""Stick"",
                    ""id"": ""809f371f-c5e2-4e7a-83a1-d867598f40dd"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Navigate"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""14a5d6e8-4aaf-4119-a9ef-34b8c2c548bf"",
                    ""path"": ""<Gamepad>/leftStick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Gamepad"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""2db08d65-c5fb-421b-983f-c71163608d67"",
                    ""path"": ""<Gamepad>/leftStick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Gamepad"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""8ba04515-75aa-45de-966d-393d9bbd1c14"",
                    ""path"": ""<Gamepad>/leftStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Gamepad"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""fcd248ae-a788-4676-a12e-f4d81205600b"",
                    ""path"": ""<Gamepad>/leftStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Gamepad"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""fb8277d4-c5cd-4663-9dc7-ee3f0b506d90"",
                    ""path"": ""<Gamepad>/dpad"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Gamepad"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Stick"",
                    ""id"": ""e25d9774-381c-4a61-b47c-7b6b299ad9f9"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Navigate"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""3db53b26-6601-41be-9887-63ac74e79d19"",
                    ""path"": ""<Joystick>/stick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Joystick"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""0cb3e13e-3d90-4178-8ae6-d9c5501d653f"",
                    ""path"": ""<Joystick>/stick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Joystick"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""0392d399-f6dd-4c82-8062-c1e9c0d34835"",
                    ""path"": ""<Joystick>/stick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Joystick"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""942a66d9-d42f-43d6-8d70-ecb4ba5363bc"",
                    ""path"": ""<Joystick>/stick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Joystick"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""9e92bb26-7e3b-4ec4-b06b-3c8f8e498ddc"",
                    ""path"": ""*/{Submit}"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Submit"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""82627dcc-3b13-4ba9-841d-e4b746d6553e"",
                    ""path"": ""*/{Cancel}"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Cancel"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c52c8e0b-8179-41d3-b8a1-d149033bbe86"",
                    ""path"": ""<Pointer>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Point"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5693e57a-238a-46ed-b5ae-e64e6e574302"",
                    ""path"": ""<Touchscreen>/touch*/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Point"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4faf7dc9-b979-4210-aa8c-e808e1ef89f5"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Keyboard&Mouse"",
                    ""action"": ""Click"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8d66d5ba-88d7-48e6-b1cd-198bbfef7ace"",
                    ""path"": ""<Pen>/tip"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Keyboard&Mouse"",
                    ""action"": ""Click"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""47c2a644-3ebc-4dae-a106-589b7ca75b59"",
                    ""path"": ""<Touchscreen>/touch*/press"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Click"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""38c99815-14ea-4617-8627-164d27641299"",
                    ""path"": ""<Mouse>/scroll"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Keyboard&Mouse"",
                    ""action"": ""ScrollWheel"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""24066f69-da47-44f3-a07e-0015fb02eb2e"",
                    ""path"": ""<Mouse>/middleButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Keyboard&Mouse"",
                    ""action"": ""MiddleClick"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4c191405-5738-4d4b-a523-c6a301dbf754"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Keyboard&Mouse"",
                    ""action"": ""RightClick"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7236c0d9-6ca3-47cf-a6ee-a97f5b59ea77"",
                    ""path"": ""<XRController>/devicePosition"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""TrackedDevicePosition"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""23e01e3a-f935-4948-8d8b-9bcac77714fb"",
                    ""path"": ""<XRController>/deviceRotation"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""TrackedDeviceOrientation"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""932fe797-a0a9-4eef-bd2d-556b362e08d0"",
                    ""path"": ""<XRController>/trigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""TrackedDeviceSelect"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Keyboard&Mouse"",
            ""bindingGroup"": ""Keyboard&Mouse"",
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
            ""name"": ""Gamepad"",
            ""bindingGroup"": ""Gamepad"",
            ""devices"": [
                {
                    ""devicePath"": ""<Gamepad>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        },
        {
            ""name"": ""Touch"",
            ""bindingGroup"": ""Touch"",
            ""devices"": [
                {
                    ""devicePath"": ""<Touchscreen>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        },
        {
            ""name"": ""Joystick"",
            ""bindingGroup"": ""Joystick"",
            ""devices"": [
                {
                    ""devicePath"": ""<Joystick>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // Player
        m_Player = asset.FindActionMap("Player", throwIfNotFound: true);
        m_Player_Move = m_Player.FindAction("Move", throwIfNotFound: true);
        m_Player_AimPointer = m_Player.FindAction("AimPointer", throwIfNotFound: true);
        m_Player_TileSelectionPointer = m_Player.FindAction("TileSelectionPointer", throwIfNotFound: true);
        m_Player_BasicAttack = m_Player.FindAction("BasicAttack", throwIfNotFound: true);
        m_Player_CastSpell = m_Player.FindAction("CastSpell", throwIfNotFound: true);
        m_Player_PrevSpell = m_Player.FindAction("PrevSpell", throwIfNotFound: true);
        m_Player_NextSpell = m_Player.FindAction("NextSpell", throwIfNotFound: true);
        m_Player_Dash = m_Player.FindAction("Dash", throwIfNotFound: true);
        // UI
        m_UI = asset.FindActionMap("UI", throwIfNotFound: true);
        m_UI_Navigate = m_UI.FindAction("Navigate", throwIfNotFound: true);
        m_UI_Submit = m_UI.FindAction("Submit", throwIfNotFound: true);
        m_UI_Cancel = m_UI.FindAction("Cancel", throwIfNotFound: true);
        m_UI_Point = m_UI.FindAction("Point", throwIfNotFound: true);
        m_UI_Click = m_UI.FindAction("Click", throwIfNotFound: true);
        m_UI_ScrollWheel = m_UI.FindAction("ScrollWheel", throwIfNotFound: true);
        m_UI_MiddleClick = m_UI.FindAction("MiddleClick", throwIfNotFound: true);
        m_UI_RightClick = m_UI.FindAction("RightClick", throwIfNotFound: true);
        m_UI_TrackedDevicePosition = m_UI.FindAction("TrackedDevicePosition", throwIfNotFound: true);
        m_UI_TrackedDeviceOrientation = m_UI.FindAction("TrackedDeviceOrientation", throwIfNotFound: true);
        m_UI_TrackedDeviceSelect = m_UI.FindAction("TrackedDeviceSelect", throwIfNotFound: true);
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

    // Player
    private readonly InputActionMap m_Player;
    private IPlayerActions m_PlayerActionsCallbackInterface;
    private readonly InputAction m_Player_Move;
    private readonly InputAction m_Player_AimPointer;
    private readonly InputAction m_Player_TileSelectionPointer;
    private readonly InputAction m_Player_BasicAttack;
    private readonly InputAction m_Player_CastSpell;
    private readonly InputAction m_Player_PrevSpell;
    private readonly InputAction m_Player_NextSpell;
    private readonly InputAction m_Player_Dash;
    public struct PlayerActions
    {
        private InputActions m_Wrapper;
        public PlayerActions(InputActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_Player_Move;
        public InputAction @AimPointer => m_Wrapper.m_Player_AimPointer;
        public InputAction @TileSelectionPointer => m_Wrapper.m_Player_TileSelectionPointer;
        public InputAction @BasicAttack => m_Wrapper.m_Player_BasicAttack;
        public InputAction @CastSpell => m_Wrapper.m_Player_CastSpell;
        public InputAction @PrevSpell => m_Wrapper.m_Player_PrevSpell;
        public InputAction @NextSpell => m_Wrapper.m_Player_NextSpell;
        public InputAction @Dash => m_Wrapper.m_Player_Dash;
        public InputActionMap Get() { return m_Wrapper.m_Player; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerActions instance)
        {
            if (m_Wrapper.m_PlayerActionsCallbackInterface != null)
            {
                Move.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMove;
                Move.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMove;
                Move.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMove;
                AimPointer.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnAimPointer;
                AimPointer.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnAimPointer;
                AimPointer.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnAimPointer;
                TileSelectionPointer.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnTileSelectionPointer;
                TileSelectionPointer.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnTileSelectionPointer;
                TileSelectionPointer.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnTileSelectionPointer;
                BasicAttack.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnBasicAttack;
                BasicAttack.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnBasicAttack;
                BasicAttack.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnBasicAttack;
                CastSpell.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnCastSpell;
                CastSpell.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnCastSpell;
                CastSpell.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnCastSpell;
                PrevSpell.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnPrevSpell;
                PrevSpell.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnPrevSpell;
                PrevSpell.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnPrevSpell;
                NextSpell.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnNextSpell;
                NextSpell.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnNextSpell;
                NextSpell.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnNextSpell;
                Dash.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnDash;
                Dash.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnDash;
                Dash.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnDash;
            }
            m_Wrapper.m_PlayerActionsCallbackInterface = instance;
            if (instance != null)
            {
                Move.started += instance.OnMove;
                Move.performed += instance.OnMove;
                Move.canceled += instance.OnMove;
                AimPointer.started += instance.OnAimPointer;
                AimPointer.performed += instance.OnAimPointer;
                AimPointer.canceled += instance.OnAimPointer;
                TileSelectionPointer.started += instance.OnTileSelectionPointer;
                TileSelectionPointer.performed += instance.OnTileSelectionPointer;
                TileSelectionPointer.canceled += instance.OnTileSelectionPointer;
                BasicAttack.started += instance.OnBasicAttack;
                BasicAttack.performed += instance.OnBasicAttack;
                BasicAttack.canceled += instance.OnBasicAttack;
                CastSpell.started += instance.OnCastSpell;
                CastSpell.performed += instance.OnCastSpell;
                CastSpell.canceled += instance.OnCastSpell;
                PrevSpell.started += instance.OnPrevSpell;
                PrevSpell.performed += instance.OnPrevSpell;
                PrevSpell.canceled += instance.OnPrevSpell;
                NextSpell.started += instance.OnNextSpell;
                NextSpell.performed += instance.OnNextSpell;
                NextSpell.canceled += instance.OnNextSpell;
                Dash.started += instance.OnDash;
                Dash.performed += instance.OnDash;
                Dash.canceled += instance.OnDash;
            }
        }
    }
    public PlayerActions @Player => new PlayerActions(this);

    // UI
    private readonly InputActionMap m_UI;
    private IUIActions m_UIActionsCallbackInterface;
    private readonly InputAction m_UI_Navigate;
    private readonly InputAction m_UI_Submit;
    private readonly InputAction m_UI_Cancel;
    private readonly InputAction m_UI_Point;
    private readonly InputAction m_UI_Click;
    private readonly InputAction m_UI_ScrollWheel;
    private readonly InputAction m_UI_MiddleClick;
    private readonly InputAction m_UI_RightClick;
    private readonly InputAction m_UI_TrackedDevicePosition;
    private readonly InputAction m_UI_TrackedDeviceOrientation;
    private readonly InputAction m_UI_TrackedDeviceSelect;
    public struct UIActions
    {
        private InputActions m_Wrapper;
        public UIActions(InputActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @Navigate => m_Wrapper.m_UI_Navigate;
        public InputAction @Submit => m_Wrapper.m_UI_Submit;
        public InputAction @Cancel => m_Wrapper.m_UI_Cancel;
        public InputAction @Point => m_Wrapper.m_UI_Point;
        public InputAction @Click => m_Wrapper.m_UI_Click;
        public InputAction @ScrollWheel => m_Wrapper.m_UI_ScrollWheel;
        public InputAction @MiddleClick => m_Wrapper.m_UI_MiddleClick;
        public InputAction @RightClick => m_Wrapper.m_UI_RightClick;
        public InputAction @TrackedDevicePosition => m_Wrapper.m_UI_TrackedDevicePosition;
        public InputAction @TrackedDeviceOrientation => m_Wrapper.m_UI_TrackedDeviceOrientation;
        public InputAction @TrackedDeviceSelect => m_Wrapper.m_UI_TrackedDeviceSelect;
        public InputActionMap Get() { return m_Wrapper.m_UI; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(UIActions set) { return set.Get(); }
        public void SetCallbacks(IUIActions instance)
        {
            if (m_Wrapper.m_UIActionsCallbackInterface != null)
            {
                Navigate.started -= m_Wrapper.m_UIActionsCallbackInterface.OnNavigate;
                Navigate.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnNavigate;
                Navigate.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnNavigate;
                Submit.started -= m_Wrapper.m_UIActionsCallbackInterface.OnSubmit;
                Submit.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnSubmit;
                Submit.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnSubmit;
                Cancel.started -= m_Wrapper.m_UIActionsCallbackInterface.OnCancel;
                Cancel.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnCancel;
                Cancel.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnCancel;
                Point.started -= m_Wrapper.m_UIActionsCallbackInterface.OnPoint;
                Point.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnPoint;
                Point.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnPoint;
                Click.started -= m_Wrapper.m_UIActionsCallbackInterface.OnClick;
                Click.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnClick;
                Click.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnClick;
                ScrollWheel.started -= m_Wrapper.m_UIActionsCallbackInterface.OnScrollWheel;
                ScrollWheel.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnScrollWheel;
                ScrollWheel.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnScrollWheel;
                MiddleClick.started -= m_Wrapper.m_UIActionsCallbackInterface.OnMiddleClick;
                MiddleClick.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnMiddleClick;
                MiddleClick.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnMiddleClick;
                RightClick.started -= m_Wrapper.m_UIActionsCallbackInterface.OnRightClick;
                RightClick.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnRightClick;
                RightClick.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnRightClick;
                TrackedDevicePosition.started -= m_Wrapper.m_UIActionsCallbackInterface.OnTrackedDevicePosition;
                TrackedDevicePosition.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnTrackedDevicePosition;
                TrackedDevicePosition.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnTrackedDevicePosition;
                TrackedDeviceOrientation.started -= m_Wrapper.m_UIActionsCallbackInterface.OnTrackedDeviceOrientation;
                TrackedDeviceOrientation.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnTrackedDeviceOrientation;
                TrackedDeviceOrientation.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnTrackedDeviceOrientation;
                TrackedDeviceSelect.started -= m_Wrapper.m_UIActionsCallbackInterface.OnTrackedDeviceSelect;
                TrackedDeviceSelect.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnTrackedDeviceSelect;
                TrackedDeviceSelect.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnTrackedDeviceSelect;
            }
            m_Wrapper.m_UIActionsCallbackInterface = instance;
            if (instance != null)
            {
                Navigate.started += instance.OnNavigate;
                Navigate.performed += instance.OnNavigate;
                Navigate.canceled += instance.OnNavigate;
                Submit.started += instance.OnSubmit;
                Submit.performed += instance.OnSubmit;
                Submit.canceled += instance.OnSubmit;
                Cancel.started += instance.OnCancel;
                Cancel.performed += instance.OnCancel;
                Cancel.canceled += instance.OnCancel;
                Point.started += instance.OnPoint;
                Point.performed += instance.OnPoint;
                Point.canceled += instance.OnPoint;
                Click.started += instance.OnClick;
                Click.performed += instance.OnClick;
                Click.canceled += instance.OnClick;
                ScrollWheel.started += instance.OnScrollWheel;
                ScrollWheel.performed += instance.OnScrollWheel;
                ScrollWheel.canceled += instance.OnScrollWheel;
                MiddleClick.started += instance.OnMiddleClick;
                MiddleClick.performed += instance.OnMiddleClick;
                MiddleClick.canceled += instance.OnMiddleClick;
                RightClick.started += instance.OnRightClick;
                RightClick.performed += instance.OnRightClick;
                RightClick.canceled += instance.OnRightClick;
                TrackedDevicePosition.started += instance.OnTrackedDevicePosition;
                TrackedDevicePosition.performed += instance.OnTrackedDevicePosition;
                TrackedDevicePosition.canceled += instance.OnTrackedDevicePosition;
                TrackedDeviceOrientation.started += instance.OnTrackedDeviceOrientation;
                TrackedDeviceOrientation.performed += instance.OnTrackedDeviceOrientation;
                TrackedDeviceOrientation.canceled += instance.OnTrackedDeviceOrientation;
                TrackedDeviceSelect.started += instance.OnTrackedDeviceSelect;
                TrackedDeviceSelect.performed += instance.OnTrackedDeviceSelect;
                TrackedDeviceSelect.canceled += instance.OnTrackedDeviceSelect;
            }
        }
    }
    public UIActions @UI => new UIActions(this);
    private int m_KeyboardMouseSchemeIndex = -1;
    public InputControlScheme KeyboardMouseScheme
    {
        get
        {
            if (m_KeyboardMouseSchemeIndex == -1) m_KeyboardMouseSchemeIndex = asset.FindControlSchemeIndex("Keyboard&Mouse");
            return asset.controlSchemes[m_KeyboardMouseSchemeIndex];
        }
    }
    private int m_GamepadSchemeIndex = -1;
    public InputControlScheme GamepadScheme
    {
        get
        {
            if (m_GamepadSchemeIndex == -1) m_GamepadSchemeIndex = asset.FindControlSchemeIndex("Gamepad");
            return asset.controlSchemes[m_GamepadSchemeIndex];
        }
    }
    private int m_TouchSchemeIndex = -1;
    public InputControlScheme TouchScheme
    {
        get
        {
            if (m_TouchSchemeIndex == -1) m_TouchSchemeIndex = asset.FindControlSchemeIndex("Touch");
            return asset.controlSchemes[m_TouchSchemeIndex];
        }
    }
    private int m_JoystickSchemeIndex = -1;
    public InputControlScheme JoystickScheme
    {
        get
        {
            if (m_JoystickSchemeIndex == -1) m_JoystickSchemeIndex = asset.FindControlSchemeIndex("Joystick");
            return asset.controlSchemes[m_JoystickSchemeIndex];
        }
    }
    public interface IPlayerActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnAimPointer(InputAction.CallbackContext context);
        void OnTileSelectionPointer(InputAction.CallbackContext context);
        void OnBasicAttack(InputAction.CallbackContext context);
        void OnCastSpell(InputAction.CallbackContext context);
        void OnPrevSpell(InputAction.CallbackContext context);
        void OnNextSpell(InputAction.CallbackContext context);
        void OnDash(InputAction.CallbackContext context);
    }
    public interface IUIActions
    {
        void OnNavigate(InputAction.CallbackContext context);
        void OnSubmit(InputAction.CallbackContext context);
        void OnCancel(InputAction.CallbackContext context);
        void OnPoint(InputAction.CallbackContext context);
        void OnClick(InputAction.CallbackContext context);
        void OnScrollWheel(InputAction.CallbackContext context);
        void OnMiddleClick(InputAction.CallbackContext context);
        void OnRightClick(InputAction.CallbackContext context);
        void OnTrackedDevicePosition(InputAction.CallbackContext context);
        void OnTrackedDeviceOrientation(InputAction.CallbackContext context);
        void OnTrackedDeviceSelect(InputAction.CallbackContext context);
    }
}
