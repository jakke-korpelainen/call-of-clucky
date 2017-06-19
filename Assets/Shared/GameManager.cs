using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager
{
    public event System.Action<Player> OnLocalPlayerJoined;

    private GameObject gameObject;

    private const string GameObjectName = "_gameManager";

    private static GameManager _instance;
    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new GameManager();
                _instance.gameObject = new GameObject(GameObjectName);
                _instance.gameObject.AddComponent<InputController>();
            }

            return _instance;
        }
    }

    private InputController _inputController;
    public InputController InputController
    {
        get
        {
            if (_inputController == null)
                _inputController = gameObject.GetComponent<InputController>();

            return _inputController;
        }
    }

    private Player _localPlayer;
    public Player LocalPlayer
    {
        get
        {
            return _localPlayer;
        }

        set
        {
            _localPlayer = value;
            if (OnLocalPlayerJoined != null)
                OnLocalPlayerJoined(_localPlayer);
        }
    }
}
