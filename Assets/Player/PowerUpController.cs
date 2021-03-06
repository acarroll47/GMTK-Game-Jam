﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpController : MonoBehaviour {

    public GameObject activePowerUp;
    public GameObject nextPowerUp;
    public List<GameObject> queuedPowerUps = new List<GameObject>();

    void FixedUpdate() {
        if(queuedPowerUps.Count > 0)
            activePowerUp = queuedPowerUps[0];
    }


    void OnTriggerStay2D(Collider2D collider) {
        if(collider.gameObject.tag.Equals("Follower") && queuedPowerUps.Count < 2) {
            ShipController shipController = collider.gameObject.GetComponent<ShipController>();
            if(shipController.CheckPowerUp()) {
                queuedPowerUps.Add(shipController.GetPowerUp());
                SendPowerUpToPlayer();
            }
        }
    }


    void SendPowerUpToPlayer() {
        if(queuedPowerUps[0])
            activePowerUp = queuedPowerUps[0];
        if(queuedPowerUps[1])
            nextPowerUp = queuedPowerUps[1];

        ActivatePowerUp();
    }


    void ActivatePowerUp() {
        Vector3 spawnPoint = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);
        GameObject newPowerUp = Instantiate(activePowerUp, spawnPoint, gameObject.transform.rotation);
        //newPowerUp.transform.parent = gameObject.transform;
    }
}
