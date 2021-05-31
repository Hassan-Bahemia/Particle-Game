using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    
    [SerializeField] private List<GameObject> _enemies;
    
    public int GetEnemyCount()
    {
        return _enemies.Count;
    }
    
    public List<GameObject> GetEnemies()
    {
        return _enemies;
    }

    public void AddEnemy(GameObject enemy)
    {
        _enemies.Add(enemy);
    }
}
