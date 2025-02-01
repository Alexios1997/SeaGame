using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TweenTrash : MonoBehaviour
{
    Vector3 vec3 = new Vector3(0.0f,0.1f,0.0f);
    Vector3 Rvec3 = new Vector3(0.0f,0.0f,0.1f);
    // Start is called before the first frame update
    void Start()
    {
        iTween.MoveBy(this.gameObject, iTween.Hash("amount", vec3, "easetype", iTween.EaseType.linear, "time", 1.5f, "loopType", "pingPong"));
        iTween.RotateBy(this.gameObject, iTween.Hash("amount", Rvec3, "easetype", iTween.EaseType.linear, "time", 2.5f, "loopType", "pingPong"));
    }

    
}
