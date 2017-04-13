using System.Linq;
using UnityEngine;

public class Controller : MonoBehaviour {

	public float MoveSpeed = 6;
    public Vector2 MinPosition;
    public Vector2 MaxPosition;
    public Camera ViewCamera;
	Rigidbody _rigidbody;
	Vector3 _velocity;

	void Start () {
		_rigidbody = GetComponent<Rigidbody> ();
	}

	void Update () {
		Vector3 mousePos = ViewCamera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, ViewCamera.transform.position.y));
		transform.LookAt (mousePos + Vector3.up * transform.position.y);
		_velocity = new Vector3 (Input.GetAxisRaw ("Horizontal"), 0, Input.GetAxisRaw ("Vertical")).normalized * MoveSpeed;
    }

	void FixedUpdate()
	{
	    if (_rigidbody.position.x < MinPosition.x && _velocity.x < 0f)
	        _velocity.x = 0f;
	    if (_rigidbody.position.x > MaxPosition.x && _velocity.x > 0f)
	        _velocity.x = 0f;

	    if (_rigidbody.position.z < MinPosition.y && _velocity.z < 0f)
	        _velocity.z = 0f;
	    if (_rigidbody.position.z > MaxPosition.y && _velocity.z > 0f)
	        _velocity.z = 0f;

        _rigidbody.MovePosition (_rigidbody.position + _velocity * Time.fixedDeltaTime);
	}
}