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
                _instance.gameObject.AddComponent<Timer>();
                _instance.gameObject.AddComponent<Respawner>();
            }

            return _instance;
        }
    }

    private Respawner _respawner;
    public Respawner Respawner
    {
        get
        {
            return _respawner ?? (_respawner = gameObject.GetComponent<Respawner>());
        }
    }

    private Timer _timer;
    public Timer Timer
    {
        get
        {
            return _timer ?? (_timer = gameObject.GetComponent<Timer>());
        }
    }

    private InputController _inputController;
    public InputController InputController
    {
        get
        {
            return _inputController ?? (_inputController = gameObject.GetComponent<InputController>());
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
