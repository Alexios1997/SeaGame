using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSc : MonoBehaviour
{


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow) && gameObject.transform.position.y < -1.176)
        {
            gameObject.transform.position += new Vector3(0.0f, 0.04f, 0.0f);
        }
        if (Input.GetKey(KeyCode.DownArrow) && gameObject.transform.position.y > -3.136)
        {
            gameObject.transform.position += new Vector3(0.0f, -0.04f, 0.0f);
        }
    }
}
