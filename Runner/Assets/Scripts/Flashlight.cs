using UnityEngine;

public class Flashlight : MonoBehaviour
{
    [Range(0,2)]
    private float _energy;

    public FieldOfView FieldOfView;
    public Light Light;
    public int MaxRange = 30;


    public float LossPerFrame = 0.01f;

    void Start ()
    {
        _energy = 1f;
    }
	
	void Update ()
	{
        if (_energy > 0f)
            _energy -= LossPerFrame / 60;

	    var range = _energy * MaxRange;

        FieldOfView.viewRadius = range;
	    Light.range = range;
        KillWithRay(range);
        
    }

    void KillWithRay(float range)
    {
        RaycastHit hit;
        Physics.Raycast(new Ray(transform.parent.position, transform.parent.forward), out hit, range);
        if (hit.transform == null)
            return;

        var enemy = hit.transform.gameObject.GetComponent<EnemyController>();
        if (enemy != null)
            enemy.SawLight();
    }
}
