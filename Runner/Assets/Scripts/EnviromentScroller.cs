using UnityEngine;

public class EnviromentScroller : MonoBehaviour {

    public float ScrollSpeed;

	void Update () {

	    transform.Translate(0f,0f, -ScrollSpeed);
    }
}
