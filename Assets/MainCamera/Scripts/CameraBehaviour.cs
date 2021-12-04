using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehaviour : MonoBehaviour
{
    [SerializeField] private Transform playerTransform;

    private void Update()
    {
        var playerPosition = this.playerTransform.position;
        var cameraPosition = this.transform.position;
        cameraPosition          = new Vector3(playerPosition.x, cameraPosition.y, cameraPosition.z);
        this.transform.position = cameraPosition;
    }
}