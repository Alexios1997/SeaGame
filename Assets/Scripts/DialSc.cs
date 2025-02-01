using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialSc : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Dest());
    }
    IEnumerator Dest()
    {

        yield return new WaitForSeconds(1.5f);
        Destroy(this.gameObject);
    }

}
