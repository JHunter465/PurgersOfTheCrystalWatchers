// GENERATED AUTOMATICALLY FROM 'Assets/InputSystems/PlayerInputActions.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @PlayerInputActions : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerInputActions()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerInputActions"",
    ""maps"": [
        {
            ""name"": ""PlayerActions"",
            ""id"": ""bf0e1e57-f5b1-4874-9f85-318cd17fd43f"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""94aa54e2-f9ab-49cb-9bf0-ac5de8dafffd"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""LookMouse"",
                    ""type"": ""PassThrough"",
                    ""id"": ""25b1aaaa-fd4b-480b-842b-91f093f2f8fc"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Look"",
                    ""type"": ""PassThrough"",
                    ""id"": ""10ebe356-a6f2-4053-b02e-f60fb5d70535"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""841f50ca-d3ac-47c3-ae89-af82b690fb98"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Run"",
                    ""type"": ""Button"",
                    ""id"": ""6be43087-89df-48e7-82e0-24d3f90f65cb"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Crouch"",
                    ""type"": ""Button"",
                    ""id"": ""5c121e88-dc94-4ff0-a9d2-a7df1fb875e7"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Interact"",
                    ""type"": ""Button"",
                    ""id"": ""7b6356cf-a202-42cd-aa91-94c1117576d9"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Pause"",
                    ""type"": ""Button"",
                    ""id"": ""77ac6575-fa5d-44e9-9ca2-11ce69af3f71"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Secret1"",
                    ""type"": ""Button"",
                    ""id"": ""2b2b7255-a5e0-442a-850b-790d0677754a"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Secret2"",
                    ""type"": ""Button"",
                    ""id"": ""7222438e-d6c5-4758-a110-ed29a32cf8cc"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Secret3"",
                    ""type"": ""Button"",
                    ""id"": ""489fe1d1-867a-47e9-909a-d21c0323f637"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Secret4"",
                    ""type"": ""Button"",
                    ""id"": ""7f2f8f9a-deec-455e-b77d-80177ce9dad4"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Secret5"",
                    ""type"": ""Button"",
                    ""id"": ""ed452651-bbb6-492b-839c-18bd1783bb44"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Secret6"",
                    ""type"": ""Button"",
                    ""id"": ""627a3f2c-d8ba-41a1-9ebd-73aee4ce8bcc"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""dd76dd12-22f2-4d6f-9ad0-c310c58acfee"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""1f0b3559-0eea-474a-810e-12aafbe3cd04"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""c5784f19-b390-431a-9be4-08f0ba45f556"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""8327adbb-c8ca-4719-b3c5-1994a0dab573"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""53a25dd0-76a1-4158-a9a0-f296391c6640"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""d0bab6c1-294e-460f-ac33-6c86d7800448"",
                    ""path"": ""<DualShockGamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PS4 Controller"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d6bde55f-bf38-44ad-af0e-c90f143e42e6"",
                    ""path"": ""<XInputController>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Xbox Controller"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""91b8c293-7b30-48e6-923b-e177ee957e4d"",
                    ""path"": ""<XInputController>/rightStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Xbox Controller"",
                    ""action"": ""Look"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b77aaa4b-5336-46b8-82aa-e14a0babd829"",
                    ""path"": ""<DualShockGamepad>/rightStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PS4 Controller"",
                    ""action"": ""Look"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""65e71b94-ba15-49de-a88a-fa2a1db06c3a"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5d6078fd-31dc-4232-b04e-23191dcfe5de"",
                    ""path"": ""<DualShockGamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PS4 Controller"",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""633dd3d2-40b4-4195-9cb3-2bf92e69ead5"",
                    ""path"": ""<XInputController>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Xbox Controller"",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""fe1b2cd4-43b5-4366-be3d-d276b768f403"",
                    ""path"": ""<Keyboard>/shift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""Run"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a3c89a7f-c0e6-48cd-9113-1b70d473531f"",
                    ""path"": ""<XInputController>/leftStickPress"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Xbox Controller"",
                    ""action"": ""Run"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""33720b81-ad66-45d7-b8be-61902a084a2c"",
                    ""path"": ""<DualShockGamepad>/leftStickPress"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PS4 Controller"",
                    ""action"": ""Run"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b851f53f-43b2-4edc-8118-9dd16f88fb6e"",
                    ""path"": ""<Keyboard>/ctrl"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""Crouch"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7bc1df01-5062-475b-b9f0-f59262c5915f"",
                    ""path"": ""<DualShockGamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PS4 Controller"",
                    ""action"": ""Crouch"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9fd14ab8-c1f4-4436-baf6-5554bdb3bc6c"",
                    ""path"": ""<XInputController>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Xbox Controller"",
                    ""action"": ""Crouch"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a3e6c9db-314d-47fe-93e8-d73fc6a3e549"",
                    ""path"": ""<Mouse>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""LookMouse"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a80a3ccc-f5c8-4f69-a647-3043ace6a9ac"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""Interact"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9f81f3ef-0c96-4673-aa36-2cdf738f7582"",
                    ""path"": ""<DualShockGamepad>/buttonNorth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PS4 Controller"",
                    ""action"": ""Interact"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""abbd580c-e2f0-42d4-a70b-25f470de3b30"",
                    ""path"": ""<XInputController>/buttonNorth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Xbox Controller"",
                    ""action"": ""Interact"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a35ca7ce-7cf1-46bd-bb13-283f65c75d67"",
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
                    ""id"": ""a66b3b4c-4acd-48a3-bd15-7afd46a0e183"",
                    ""path"": ""<DualShockGamepad>/start"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PS4 Controller"",
                    ""action"": ""Pause"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""064d0bcd-e4a1-4ed0-82f4-88f5aae66ae5"",
                    ""path"": ""<XInputController>/start"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Xbox Controller"",
                    ""action"": ""Pause"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""221e3b4e-b1a5-4fc5-8dc9-d59853c6ee6c"",
                    ""path"": ""<Keyboard>/numpad1"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""Secret1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""90625f34-3765-472c-9c3e-74b855abb369"",
                    ""path"": ""<Keyboard>/numpad2"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""Secret2"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""eb61564f-07e3-4ddb-8a5f-0f6052258eb3"",
                    ""path"": ""<Keyboard>/numpad3"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""Secret3"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""36ac28af-8dc9-4ae3-865f-3ee47410da0b"",
                    ""path"": ""<Keyboard>/numpad4"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Secret4"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2ff0d2df-9c23-4037-8dc4-d7f359209c8c"",
                    ""path"": ""<Keyboard>/numpad5"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""Secret5"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""cdc786c9-2419-48b6-a877-b0c3e1fce0e6"",
                    ""path"": ""<Keyboard>/numpad6"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""Secret6"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""UIActions"",
            ""id"": ""ded09bc4-4cc6-4a29-aa8c-a09826cfe5bb"",
            ""actions"": [
                {
                    ""name"": ""Point"",
                    ""type"": ""PassThrough"",
                    ""id"": ""a3c394a5-b364-4903-b7c7-4696125d9944"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Click"",
                    ""type"": ""PassThrough"",
                    ""id"": ""21370ac5-a7f2-4d51-8c02-dd8d059dec72"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""ScrollWheel"",
                    ""type"": ""PassThrough"",
                    ""id"": ""f12972df-a078-43b9-869b-2071c9416721"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Submit"",
                    ""type"": ""Button"",
                    ""id"": ""3ffd6113-5167-4c04-9fbd-422cff3ce23d"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Cancel"",
                    ""type"": ""Button"",
                    ""id"": ""f6fa3703-94e9-491b-a844-ce76c3fa510a"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""aacbf704-8e72-4ea4-a7c5-3638dc89fb04"",
                    ""path"": ""<Mouse>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""Point"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7bab7f93-eb07-4578-869a-39d0f93186cc"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""Click"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e8e182f2-fbb5-4fa0-a0a8-79ab6f541688"",
                    ""path"": ""<Mouse>/scroll"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""ScrollWheel"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c97dd2fd-40a1-4d8e-8717-9eafdd43c9cf"",
                    ""path"": ""<DualShockGamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PS4 Controller"",
                    ""action"": ""Submit"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f19803bb-befb-45bb-9eb1-6e12ad71053f"",
                    ""path"": ""<Keyboard>/enter"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""Submit"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3faf5493-2488-454c-87e9-ab070f208d1b"",
                    ""path"": ""<XInputController>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Xbox Controller"",
                    ""action"": ""Submit"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a7ddfc86-1608-4ac1-b9f5-06edf3f1fbec"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse;PS4 Controller"",
                    ""action"": ""Submit"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a2057df0-b61f-4f4c-b257-801cb35cc120"",
                    ""path"": ""<Keyboard>/tab"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""Cancel"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5f401a7e-9026-4034-b375-f6d53dcc2a80"",
                    ""path"": ""<XInputController>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Xbox Controller"",
                    ""action"": ""Cancel"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""38abc97c-3266-4041-a585-7d5d9f51fade"",
                    ""path"": ""<DualShockGamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PS4 Controller"",
                    ""action"": ""Cancel"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d139c8cf-b07c-4d49-839c-44ede58b089a"",
                    ""path"": ""<Keyboard>/backspace"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""Cancel"",
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
            ""name"": ""PS4 Controller"",
            ""bindingGroup"": ""PS4 Controller"",
            ""devices"": [
                {
                    ""devicePath"": ""<DualShockGamepad>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        },
        {
            ""name"": ""Xbox Controller"",
            ""bindingGroup"": ""Xbox Controller"",
            ""devices"": [
                {
                    ""devicePath"": ""<XInputController>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // PlayerActions
        m_PlayerActions = asset.FindActionMap("PlayerActions", throwIfNotFound: true);
        m_PlayerActions_Move = m_PlayerActions.FindAction("Move", throwIfNotFound: true);
        m_PlayerActions_LookMouse = m_PlayerActions.FindAction("LookMouse", throwIfNotFound: true);
        m_PlayerActions_Look = m_PlayerActions.FindAction("Look", throwIfNotFound: true);
        m_PlayerActions_Jump = m_PlayerActions.FindAction("Jump", throwIfNotFound: true);
        m_PlayerActions_Run = m_PlayerActions.FindAction("Run", throwIfNotFound: true);
        m_PlayerActions_Crouch = m_PlayerActions.FindAction("Crouch", throwIfNotFound: true);
        m_PlayerActions_Interact = m_PlayerActions.FindAction("Interact", throwIfNotFound: true);
        m_PlayerActions_Pause = m_PlayerActions.FindAction("Pause", throwIfNotFound: true);
        m_PlayerActions_Secret1 = m_PlayerActions.FindAction("Secret1", throwIfNotFound: true);
        m_PlayerActions_Secret2 = m_PlayerActions.FindAction("Secret2", throwIfNotFound: true);
        m_PlayerActions_Secret3 = m_PlayerActions.FindAction("Secret3", throwIfNotFound: true);
        m_PlayerActions_Secret4 = m_PlayerActions.FindAction("Secret4", throwIfNotFound: true);
        m_PlayerActions_Secret5 = m_PlayerActions.FindAction("Secret5", throwIfNotFound: true);
        m_PlayerActions_Secret6 = m_PlayerActions.FindAction("Secret6", throwIfNotFound: true);
        // UIActions
        m_UIActions = asset.FindActionMap("UIActions", throwIfNotFound: true);
        m_UIActions_Point = m_UIActions.FindAction("Point", throwIfNotFound: true);
        m_UIActions_Click = m_UIActions.FindAction("Click", throwIfNotFound: true);
        m_UIActions_ScrollWheel = m_UIActions.FindAction("ScrollWheel", throwIfNotFound: true);
        m_UIActions_Submit = m_UIActions.FindAction("Submit", throwIfNotFound: true);
        m_UIActions_Cancel = m_UIActions.FindAction("Cancel", throwIfNotFound: true);
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

    // PlayerActions
    private readonly InputActionMap m_PlayerActions;
    private IPlayerActionsActions m_PlayerActionsActionsCallbackInterface;
    private readonly InputAction m_PlayerActions_Move;
    private readonly InputAction m_PlayerActions_LookMouse;
    private readonly InputAction m_PlayerActions_Look;
    private readonly InputAction m_PlayerActions_Jump;
    private readonly InputAction m_PlayerActions_Run;
    private readonly InputAction m_PlayerActions_Crouch;
    private readonly InputAction m_PlayerActions_Interact;
    private readonly InputAction m_PlayerActions_Pause;
    private readonly InputAction m_PlayerActions_Secret1;
    private readonly InputAction m_PlayerActions_Secret2;
    private readonly InputAction m_PlayerActions_Secret3;
    private readonly InputAction m_PlayerActions_Secret4;
    private readonly InputAction m_PlayerActions_Secret5;
    private readonly InputAction m_PlayerActions_Secret6;
    public struct PlayerActionsActions
    {
        private @PlayerInputActions m_Wrapper;
        public PlayerActionsActions(@PlayerInputActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_PlayerActions_Move;
        public InputAction @LookMouse => m_Wrapper.m_PlayerActions_LookMouse;
        public InputAction @Look => m_Wrapper.m_PlayerActions_Look;
        public InputAction @Jump => m_Wrapper.m_PlayerActions_Jump;
        public InputAction @Run => m_Wrapper.m_PlayerActions_Run;
        public InputAction @Crouch => m_Wrapper.m_PlayerActions_Crouch;
        public InputAction @Interact => m_Wrapper.m_PlayerActions_Interact;
        public InputAction @Pause => m_Wrapper.m_PlayerActions_Pause;
        public InputAction @Secret1 => m_Wrapper.m_PlayerActions_Secret1;
        public InputAction @Secret2 => m_Wrapper.m_PlayerActions_Secret2;
        public InputAction @Secret3 => m_Wrapper.m_PlayerActions_Secret3;
        public InputAction @Secret4 => m_Wrapper.m_PlayerActions_Secret4;
        public InputAction @Secret5 => m_Wrapper.m_PlayerActions_Secret5;
        public InputAction @Secret6 => m_Wrapper.m_PlayerActions_Secret6;
        public InputActionMap Get() { return m_Wrapper.m_PlayerActions; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerActionsActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerActionsActions instance)
        {
            if (m_Wrapper.m_PlayerActionsActionsCallbackInterface != null)
            {
                @Move.started -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnMove;
                @LookMouse.started -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnLookMouse;
                @LookMouse.performed -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnLookMouse;
                @LookMouse.canceled -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnLookMouse;
                @Look.started -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnLook;
                @Look.performed -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnLook;
                @Look.canceled -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnLook;
                @Jump.started -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnJump;
                @Run.started -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnRun;
                @Run.performed -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnRun;
                @Run.canceled -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnRun;
                @Crouch.started -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnCrouch;
                @Crouch.performed -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnCrouch;
                @Crouch.canceled -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnCrouch;
                @Interact.started -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnInteract;
                @Interact.performed -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnInteract;
                @Interact.canceled -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnInteract;
                @Pause.started -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnPause;
                @Pause.performed -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnPause;
                @Pause.canceled -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnPause;
                @Secret1.started -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnSecret1;
                @Secret1.performed -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnSecret1;
                @Secret1.canceled -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnSecret1;
                @Secret2.started -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnSecret2;
                @Secret2.performed -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnSecret2;
                @Secret2.canceled -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnSecret2;
                @Secret3.started -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnSecret3;
                @Secret3.performed -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnSecret3;
                @Secret3.canceled -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnSecret3;
                @Secret4.started -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnSecret4;
                @Secret4.performed -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnSecret4;
                @Secret4.canceled -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnSecret4;
                @Secret5.started -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnSecret5;
                @Secret5.performed -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnSecret5;
                @Secret5.canceled -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnSecret5;
                @Secret6.started -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnSecret6;
                @Secret6.performed -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnSecret6;
                @Secret6.canceled -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnSecret6;
            }
            m_Wrapper.m_PlayerActionsActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @LookMouse.started += instance.OnLookMouse;
                @LookMouse.performed += instance.OnLookMouse;
                @LookMouse.canceled += instance.OnLookMouse;
                @Look.started += instance.OnLook;
                @Look.performed += instance.OnLook;
                @Look.canceled += instance.OnLook;
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @Run.started += instance.OnRun;
                @Run.performed += instance.OnRun;
                @Run.canceled += instance.OnRun;
                @Crouch.started += instance.OnCrouch;
                @Crouch.performed += instance.OnCrouch;
                @Crouch.canceled += instance.OnCrouch;
                @Interact.started += instance.OnInteract;
                @Interact.performed += instance.OnInteract;
                @Interact.canceled += instance.OnInteract;
                @Pause.started += instance.OnPause;
                @Pause.performed += instance.OnPause;
                @Pause.canceled += instance.OnPause;
                @Secret1.started += instance.OnSecret1;
                @Secret1.performed += instance.OnSecret1;
                @Secret1.canceled += instance.OnSecret1;
                @Secret2.started += instance.OnSecret2;
                @Secret2.performed += instance.OnSecret2;
                @Secret2.canceled += instance.OnSecret2;
                @Secret3.started += instance.OnSecret3;
                @Secret3.performed += instance.OnSecret3;
                @Secret3.canceled += instance.OnSecret3;
                @Secret4.started += instance.OnSecret4;
                @Secret4.performed += instance.OnSecret4;
                @Secret4.canceled += instance.OnSecret4;
                @Secret5.started += instance.OnSecret5;
                @Secret5.performed += instance.OnSecret5;
                @Secret5.canceled += instance.OnSecret5;
                @Secret6.started += instance.OnSecret6;
                @Secret6.performed += instance.OnSecret6;
                @Secret6.canceled += instance.OnSecret6;
            }
        }
    }
    public PlayerActionsActions @PlayerActions => new PlayerActionsActions(this);

    // UIActions
    private readonly InputActionMap m_UIActions;
    private IUIActionsActions m_UIActionsActionsCallbackInterface;
    private readonly InputAction m_UIActions_Point;
    private readonly InputAction m_UIActions_Click;
    private readonly InputAction m_UIActions_ScrollWheel;
    private readonly InputAction m_UIActions_Submit;
    private readonly InputAction m_UIActions_Cancel;
    public struct UIActionsActions
    {
        private @PlayerInputActions m_Wrapper;
        public UIActionsActions(@PlayerInputActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @Point => m_Wrapper.m_UIActions_Point;
        public InputAction @Click => m_Wrapper.m_UIActions_Click;
        public InputAction @ScrollWheel => m_Wrapper.m_UIActions_ScrollWheel;
        public InputAction @Submit => m_Wrapper.m_UIActions_Submit;
        public InputAction @Cancel => m_Wrapper.m_UIActions_Cancel;
        public InputActionMap Get() { return m_Wrapper.m_UIActions; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(UIActionsActions set) { return set.Get(); }
        public void SetCallbacks(IUIActionsActions instance)
        {
            if (m_Wrapper.m_UIActionsActionsCallbackInterface != null)
            {
                @Point.started -= m_Wrapper.m_UIActionsActionsCallbackInterface.OnPoint;
                @Point.performed -= m_Wrapper.m_UIActionsActionsCallbackInterface.OnPoint;
                @Point.canceled -= m_Wrapper.m_UIActionsActionsCallbackInterface.OnPoint;
                @Click.started -= m_Wrapper.m_UIActionsActionsCallbackInterface.OnClick;
                @Click.performed -= m_Wrapper.m_UIActionsActionsCallbackInterface.OnClick;
                @Click.canceled -= m_Wrapper.m_UIActionsActionsCallbackInterface.OnClick;
                @ScrollWheel.started -= m_Wrapper.m_UIActionsActionsCallbackInterface.OnScrollWheel;
                @ScrollWheel.performed -= m_Wrapper.m_UIActionsActionsCallbackInterface.OnScrollWheel;
                @ScrollWheel.canceled -= m_Wrapper.m_UIActionsActionsCallbackInterface.OnScrollWheel;
                @Submit.started -= m_Wrapper.m_UIActionsActionsCallbackInterface.OnSubmit;
                @Submit.performed -= m_Wrapper.m_UIActionsActionsCallbackInterface.OnSubmit;
                @Submit.canceled -= m_Wrapper.m_UIActionsActionsCallbackInterface.OnSubmit;
                @Cancel.started -= m_Wrapper.m_UIActionsActionsCallbackInterface.OnCancel;
                @Cancel.performed -= m_Wrapper.m_UIActionsActionsCallbackInterface.OnCancel;
                @Cancel.canceled -= m_Wrapper.m_UIActionsActionsCallbackInterface.OnCancel;
            }
            m_Wrapper.m_UIActionsActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Point.started += instance.OnPoint;
                @Point.performed += instance.OnPoint;
                @Point.canceled += instance.OnPoint;
                @Click.started += instance.OnClick;
                @Click.performed += instance.OnClick;
                @Click.canceled += instance.OnClick;
                @ScrollWheel.started += instance.OnScrollWheel;
                @ScrollWheel.performed += instance.OnScrollWheel;
                @ScrollWheel.canceled += instance.OnScrollWheel;
                @Submit.started += instance.OnSubmit;
                @Submit.performed += instance.OnSubmit;
                @Submit.canceled += instance.OnSubmit;
                @Cancel.started += instance.OnCancel;
                @Cancel.performed += instance.OnCancel;
                @Cancel.canceled += instance.OnCancel;
            }
        }
    }
    public UIActionsActions @UIActions => new UIActionsActions(this);
    private int m_KeyboardandMouseSchemeIndex = -1;
    public InputControlScheme KeyboardandMouseScheme
    {
        get
        {
            if (m_KeyboardandMouseSchemeIndex == -1) m_KeyboardandMouseSchemeIndex = asset.FindControlSchemeIndex("Keyboard and Mouse");
            return asset.controlSchemes[m_KeyboardandMouseSchemeIndex];
        }
    }
    private int m_PS4ControllerSchemeIndex = -1;
    public InputControlScheme PS4ControllerScheme
    {
        get
        {
            if (m_PS4ControllerSchemeIndex == -1) m_PS4ControllerSchemeIndex = asset.FindControlSchemeIndex("PS4 Controller");
            return asset.controlSchemes[m_PS4ControllerSchemeIndex];
        }
    }
    private int m_XboxControllerSchemeIndex = -1;
    public InputControlScheme XboxControllerScheme
    {
        get
        {
            if (m_XboxControllerSchemeIndex == -1) m_XboxControllerSchemeIndex = asset.FindControlSchemeIndex("Xbox Controller");
            return asset.controlSchemes[m_XboxControllerSchemeIndex];
        }
    }
    public interface IPlayerActionsActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnLookMouse(InputAction.CallbackContext context);
        void OnLook(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnRun(InputAction.CallbackContext context);
        void OnCrouch(InputAction.CallbackContext context);
        void OnInteract(InputAction.CallbackContext context);
        void OnPause(InputAction.CallbackContext context);
        void OnSecret1(InputAction.CallbackContext context);
        void OnSecret2(InputAction.CallbackContext context);
        void OnSecret3(InputAction.CallbackContext context);
        void OnSecret4(InputAction.CallbackContext context);
        void OnSecret5(InputAction.CallbackContext context);
        void OnSecret6(InputAction.CallbackContext context);
    }
    public interface IUIActionsActions
    {
        void OnPoint(InputAction.CallbackContext context);
        void OnClick(InputAction.CallbackContext context);
        void OnScrollWheel(InputAction.CallbackContext context);
        void OnSubmit(InputAction.CallbackContext context);
        void OnCancel(InputAction.CallbackContext context);
    }
}
