using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewOptions : MonoBehaviour
{
    private HashSet<GameObject> standingInStart = new HashSet<GameObject>();

    public Text countLabel;
    
    public Color notEnoughColor = Color.red;
    public Color enoughColor = Color.green;
    public MeshRenderer floorMarker;
    private int playerCount => ControllerManager.instance.players.Count;

    private void Start()
    {
        countLabel.text = $"0/{playerCount} players ready";
        floorMarker.material.color = notEnoughColor;
    }

    private void OnTriggerEnter(Collider other)
    {
        countLabel.text = $"{standingInStart.Count}/{playerCount} players ready";
        if (standingInStart.Contains(other.transform.root.gameObject) == false)
        {
            standingInStart.Add(other.transform.root.gameObject);
        }
        
        if (standingInStart.Count == playerCount)
        {
            floorMarker.material.color = enoughColor;
        }
        else
        {
            floorMarker.material.color = notEnoughColor;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        GameObject player = other.transform.root.gameObject;
        if (standingInStart.Contains(player))
        {
            standingInStart.Remove(player);
        }
        countLabel.text = $"{standingInStart.Count}/{playerCount} players ready";
        if (standingInStart.Count < playerCount)
        {
            floorMarker.material.color = notEnoughColor;
        }
    }
}
