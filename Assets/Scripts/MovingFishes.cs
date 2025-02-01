using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingFishes : MonoBehaviour
{
    public Vector3 MoveRorL; 
    // Start is called before the first frame update
    void Start()
    {
        iTween.MoveBy(this.gameObject, iTween.Hash("amount", MoveRorL, "easetype", iTween.EaseType.linear, "time", 25f));
        StartCoroutine(Dest());
    }
    IEnumerator Dest()
    {

        yield return new WaitForSeconds(25f);
        Destroy(this.gameObject);
    }

}
