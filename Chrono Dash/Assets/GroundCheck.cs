using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    // allows use of player object
    GameObject Player;

    // Start is called before the first frame update
    void Start()
    {
        Player = gameObject.transform.parent.gameObject;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.collider.tag == "Grounded")
        {
            Player.GetComponent<Movement>().grounded = true;

        }
    }


    private void OnCollisionExit2D(Collision2D col)
    {
        if (col.collider.tag == "Grounded")
        {
            Player.GetComponent<Movement>().grounded = false;

        }
    }
}



