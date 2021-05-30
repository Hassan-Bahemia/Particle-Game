using UnityEngine;



public class EnemyYellowSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] _yellowEnemies;
    [SerializeField] private float _time;
    [SerializeField] private float _timeBetweenSpawns;
    [SerializeField] private float _angle;
    [SerializeField] private Vector3 _pos;
    [SerializeField] private GameObject _toBeSpawned;
    [SerializeField] private float _minX, _maxX;
    [SerializeField] private float _minY, _maxY;
    [SerializeField] private int _enemiesCount;
    [SerializeField] private int _maxEnemiesOnScreen;

    private void Start()
    {
        _time = Time.time;
        _timeBetweenSpawns = Random.Range(1f, 5f);
    }

    // Update is called once per frame
    void Update()
    {
        if (_enemiesCount >= _maxEnemiesOnScreen)
        {
            print("no more spawning max enemies");   
            return; 
        }


        if (Time.time - _time >= _timeBetweenSpawns)
        {
            _time = Time.time;
            _timeBetweenSpawns = Random.Range(2f, 10f);
            _angle = Random.Range(0f, 360f);
            _toBeSpawned = _yellowEnemies[Random.Range(0, _yellowEnemies.Length - 1)];
            _pos = new Vector2(Random.Range(_minX, _maxX), Random.Range(_minY, _maxY));
            SpawnEnemy();
            _enemiesCount++;
        }
    }

    void SpawnEnemy()
    {
        Instantiate(_toBeSpawned, _pos, Quaternion.Euler(new Vector3(0f, 0f, _angle)));
    }
}
