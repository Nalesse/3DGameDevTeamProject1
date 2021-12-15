using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Train : MonoBehaviour
{

    private Vector3 startPosition;

    [SerializeField] private float speed;
    [SerializeField] private float xLimit;

    // Start is called before the first frame update
    private void Start()
    {
        startPosition = transform.position;
    }

    // Update is called once per frame
    private void Update()
    {
        Vector3 trainPos = transform.position;
        transform.Translate(Vector3.left * (speed * Time.deltaTime));

        if (trainPos.x >= xLimit)
        {
            trainPos = startPosition;
            transform.position = trainPos;
        }

    }
}
