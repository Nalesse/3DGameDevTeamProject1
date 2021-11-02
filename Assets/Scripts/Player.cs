using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{
    #region Public Vars

    #endregion

    #region Privite Vars

    #endregion

    #region Serialized Fields

    #endregion

    // Start is called before the first frame update
    private void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        PlayerMovement();
    }

    private void PlayerMovement()
    {
        var horizontalInput = Input.GetAxis("Horizontal");

        transform.Translate(Vector3.right * movementSpeed * horizontalInput * Time.deltaTime);
    }
}
