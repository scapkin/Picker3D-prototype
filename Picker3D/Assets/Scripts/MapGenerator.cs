using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : Singleton<MapGenerator>
{
    public List<Transform> maps = new List<Transform>();
    public List<Transform> collectable = new List<Transform>();

    [SerializeField] private int mapDistance = 750;

    public void MapGenerate()
    {
        int nextLevel = PlayerPrefs.GetInt("Level", 1);
        Instantiate(maps[nextLevel % 10], new Vector3(0, 0, mapDistance), Quaternion.identity);
        Instantiate(collectable[nextLevel % 10], new Vector3(0, 0, mapDistance), Quaternion.identity);
        collectable.Add(collectable[nextLevel]);
        collectable.Remove(collectable[nextLevel]);
        maps.Add(maps[nextLevel]);
        maps.Remove(maps[nextLevel]);
    }
}