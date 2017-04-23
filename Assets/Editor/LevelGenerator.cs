using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using System.IO;

public class LevelGenerator
{
    [MenuItem("MyTools/GenerateLevel16x16")]
    static void CreateLevel1()
    {
        Create("Level1.txt");
    }


    [MenuItem("MyTools/GenerateLevel24x24")]
    static void CreateLevel2()
    {
        Create("Level2.txt");
    }


    [MenuItem("MyTools/GenerateLevel32x32")]
    static void CreateLevel3()
    {
        Create("Level3.txt");
    }


    static void Create(string name)
    {
        Object ground = AssetDatabase.LoadAssetAtPath("Assets/Protoype/Prefabs/GroundTile.prefab", typeof(GameObject));
        Object wall = AssetDatabase.LoadAssetAtPath("Assets/Protoype/Prefabs/Wall.prefab", typeof(GameObject));

        var groundParent = new GameObject("Ground");

        var level1Data = File.ReadAllLines("Assets/LevelData/" + name);
        int SIZE = level1Data.Length / 4;

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