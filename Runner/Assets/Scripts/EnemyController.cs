using UnityEngine;
using System.Collections.Generic;
using Assets;

public class EnemyController : MonoBehaviour {

    private Transform _target;
    public float Speed;
    private IEnumerator<Vector3> _path;
    private Vector3 _nextPoint;
    private float _waitFor;
    private float _health = 10f;
    private float _stepKoef = 5f;
    private float _randomKoef = 50f;

    void Start()
    {
        _path = GetPathToTarget().GetEnumerator();
        _path.MoveNext();
        _nextPoint = _path.Current;
    }

    void Update()
    {
        if (_waitFor > 0.01f)
        {
            _waitFor -= Time.deltaTime;
            return;
        }

        transform.position = Vector3.MoveTowards(transform.position, _nextPoint, Speed * Time.deltaTime);

        if (transform.position != _nextPoint || !_path.MoveNext())
            return;

        _nextPoint = _path.Current;
        _waitFor = 0f;
    }

    public void SawLight()
    {
        _health -= 1f;
        if(_health < 0f)
            Destroy(gameObject);
    }

    private void KillTarget()
    {
        Destroy(_target.gameObject);
    }

    IEnumerable<Vector3> GetPathToTarget()
    {
        while (_target == null)
            yield return transform.position;

        var x = transform.position.x;
        var z = transform.position.z;

        do
        {
            var tX = _target.position.x;
            var tZ = _target.position.z;
            var d = Mathf.Sqrt(Mathf.Pow(tX - x, 2) + Mathf.Pow(tZ - z, 2));
            if (d < 0.1f)
                break;

            x = tX + Mathf.Min(1,d/ _randomKoef) * Random.Range(-tX - Constants.RoadWidth, Constants.RoadWidth - tX);

            z += Mathf.Sign(tZ - z) * _stepKoef;

            yield return new Vector3(x, 1, z);

        } while (true);

        yield return new Vector3(_target.position.x, 1, _target.position.z);
    }

    public void SetTarget(Transform target)
    {
        _target = target;
    }
}
