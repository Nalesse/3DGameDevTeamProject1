using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlayer : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject player;
    public Transform playerpos;


    void Start()
    {
        Instantiate(player, playerpos.position, playerpos.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
