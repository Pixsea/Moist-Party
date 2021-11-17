using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ControllerManager : MonoBehaviour
{
    public const string defaultPlayerName = "Player";
    public static ControllerManager instance { get; private set; }
    [SerializeField]
    public List<GameObject> players { get; private set; } = new List<GameObject>();
    private void Awake()
    {
        if (instance != null)
            Destroy(gameObject);
        DontDestroyOnLoad(gameObject);
        instance = this;
    }

    public void PlayerJoined(PlayerInput player)
    {
        int num = player.playerIndex;
        player.gameObject.name = $"{defaultPlayerName}{num}";
        print($"Player {num} joined!");
        players.Add(player.gameObject);
        player.transform.position = Vector3.zero;
    }
}
