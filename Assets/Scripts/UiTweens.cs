using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiTweens : MonoBehaviour
{
    Vector3 vec3 = new Vector3(0.8f, 0.8f, 0.0f);
    // Start is called before the first frame update
    void Start()
    {
        iTween.ScaleBy(this.gameObject, iTween.Hash("amount", vec3, "easetype", iTween.EaseType.linear, "time", 1.0f, "loopType", "pingPong"));
    }

}
