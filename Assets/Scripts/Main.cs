using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{
    public float radius = 10;
    [Range(0,100)]
    public int _spawnObjectCount = 10;
    private void Start()
    {
        SpawnObjects();
    }
    public void SpawnObjects() 
    {
        for (int i = 0; i < _spawnObjectCount; i++)
        {
            Vector3 position = GetPosition(radius);
            ObjectsController.instance.Instantiate(position, Quaternion.identity);
        }
    }
    private Vector3 GetPosition(float radius)
    {
        Vector2 position = UnityEngine.Random.insideUnitCircle * radius;
        return new Vector3(position.x, 0, position.y);   
    }
  
}
