
using System;
using UnityEngine;

public class EnviromentGenerator : MonoBehaviour
{

    public GameObject[] EnviromentPatterns;

    public Vector3 StartPoint;
    public Vector3 DestroyPoint;
    private System.Random _rnd;
    private readonly Transform[] _existingEnviroment = new Transform[2];

    void Start()
    {
        _rnd = new System.Random();
        var go = Instantiate(EnviromentPatterns[_rnd.Next(0, EnviromentPatterns.Length - 1)], Vector3.zero, Quaternion.identity);
        _existingEnviroment[1] = go.transform;
        go = Instantiate(EnviromentPatterns[_rnd.Next(0, EnviromentPatterns.Length - 1)], StartPoint, Quaternion.identity);
        _existingEnviroment[0] = go.transform;
    }
	
	void Update ()
	{

	    var dist = -_existingEnviroment[1].position.z + DestroyPoint.z;
	    if (dist > 0f)
	    {
	        Destroy(_existingEnviroment[1].gameObject);
	        _existingEnviroment[1] = _existingEnviroment[0];
	        var go = Instantiate(EnviromentPatterns[_rnd.Next(0, EnviromentPatterns.Length - 1)], StartPoint, Quaternion.identity);
	        _existingEnviroment[0] = go.transform;
        } 
	}
}
