using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using System.IO;

public class LevelGenerator
{
    [MenuItem("MyTools/LevelGenerator")]
    static void Create()
    {
        Object ground = AssetDatabase.LoadAssetAtPath("Assets/Protoype/Prefabs/GroundTile.prefab", typeof(GameObject));
        Object wall = AssetDatabase.LoadAssetAtPath("Assets/Protoype/Prefabs/Wall.prefab", typeof(GameObject));

        const int SIZE = 8;

        var groundParent = new GameObject("Ground");

        var level1Data = File.ReadAllLines("Assets/LevelData/Level1.txt");
        var wallsParent = new GameObject("Wall");

        for (int x = -SIZE; x < SIZE; x++)
        {
            for (int z = -SIZE; z < SIZE; z++)
            {
                Object.Instantiate(ground, new Vector3(x * 2, 0, z * 2), Quaternion.identity, groundParent.transform);
            }
        }

        for (int x = -SIZE * 2; x < SIZE * 2; x++)
        {
            for (int z = -SIZE * 2; z < SIZE * 2; z++)
            {
                var arrX = x + SIZE * 2;
                var arrZ = z + SIZE * 2;

                var currentChar = level1Data[arrZ][arrX];

                if (currentChar == '-')
                {
                    var obj = GameObject.Instantiate(wall, new Vector3(x, 0, z), Quaternion.identity, wallsParent.transform) as GameObject;
                    obj.transform.eulerAngles = new Vector3(0, 90, 0);
                    if (z > 0)
                    {
                        obj.transform.position += new Vector3(-0.5f, 0, -1);
                    }
                    if (z < 0)
                    {
                        obj.transform.position += new Vector3(-0.5f, 0, 0);
                    }
                }

                if (currentChar == '|')
                {
                    var obj = GameObject.Instantiate(wall, new Vector3(x, 0, z), Quaternion.identity, wallsParent.transform) as GameObject;
                    if (x < 0)
                    {
                        obj.transform.position += new Vector3(0, 0, -0.5f);
                    }
                    if (x > 0)
                    {
                        obj.transform.position += new Vector3(-1, 0, -0.5f);
                    }
                }
            }
        }

    }
}