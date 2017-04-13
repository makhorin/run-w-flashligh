using Assets;
using UnityEngine;
using Random = System.Random;

public class EnemyGenerator : MonoBehaviour {

    private float _enemyTime = 1f;
    public EnemyController Enemy;
    public Transform Target;
    private readonly Random _rnd = new Random();

	
	void Update () {
	    if (_enemyTime > 0)
	    {
	        _enemyTime -= Time.deltaTime;
	        return;
	    }
	    _enemyTime = 1.5f;

	    var sign = _rnd.Next(-1, 1);
	    if (sign == 0)
	        sign = 1;

	    var thingX = (float)(-Constants.RoadWidth + _rnd.NextDouble() * Constants.RoadWidth * 2);
    
	    var enemy = Instantiate(Enemy, new Vector3(thingX, 1, sign * 40), Quaternion.identity);
	    enemy.SetTarget(Target);
	}
}
