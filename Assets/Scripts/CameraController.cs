using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    #region Serilized Fields

    [Range(0.0f, 1.0f)]
    [Tooltip("0 = more smoothness, 1 = less smoothness")]
    [SerializeField] private float cameraSmoothness;


    [SerializeField] private float xMin;
    [SerializeField] private float xMax;


    #endregion


    private Player player;

    private void Awake()
    {
        player = GameObject.FindObjectOfType<Player>();
    }

    private void LateUpdate()
    {
        float step = cameraSmoothness / Time.deltaTime;
        Vector3 cameraPos = transform.position;

        // Limits the camera to a min and max x value. Then moves the camera towards the players position if it is between the min and max
        // Also smooths the movement by dividing the speed by Time.deltaTime
        float x = Mathf.Clamp(player.transform.position.x, xMin, xMax);
        cameraPos = Vector3.MoveTowards(cameraPos, new Vector3(x, cameraPos.y, cameraPos.z), step);
        transform.position = cameraPos;

    }
}
