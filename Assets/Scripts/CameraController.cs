using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [Tooltip("How much the player is allowed to move on the x axis before moving the camera")]
    [SerializeField] private float xLimit;

    [Tooltip("How much to offset the camera on the x axis when it moves")]
    [SerializeField] private float xSnapPos;

    [Range(0.0f, 1.0f)]
    [Tooltip("0 = more smoothness, 1 = less smoothness")]
    [SerializeField] private float cameraSmoothness;

    private Vector3 offset;
    private Player player;

    private void Awake()
    {
        player = GameObject.FindObjectOfType<Player>();
        offset = transform.position - player.transform.position;
    }

    private void Update()
    {
        var step = cameraSmoothness / Time.deltaTime;
        var xDistance = transform.position.x + xLimit;
        var negXDistance = transform.position.x - xLimit;
        var snapPos = new Vector3(xSnapPos, offset.y, offset.z);

        if (player.transform.position.x >= xDistance)
        {
            // Moves the camera slowly to the target position by the step amount each frame until the desired position is reached.
            // This makes the camera movement smoother
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position + snapPos, step);
        }
        else if (player.transform.position.x <= negXDistance)
        {
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position + Vector3.Reflect(snapPos, Vector3.left), step);
        }
    }
}
