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
        Object wall_D = AssetDatabase.LoadAssetAtPath("Assets/Protoype/Prefabs/Wall_D.prefab", typeof(GameObject));
        Object wall_U = AssetDatabase.LoadAssetAtPath("Assets/Protoype/Prefabs/Wall_U.prefab", typeof(GameObject));
        Object wall_R = AssetDatabase.LoadAssetAtPath("Assets/Protoype/Prefabs/Wall_R.prefab", typeof(GameObject));
        Object wall_L = AssetDatabase.LoadAssetAtPath("Assets/Protoype/Prefabs/Wall_L.prefab", typeof(GameObject));

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
                    if (z > 0)
                    {
                        Object.Instantiate(wall_U, new Vector3(x, 0, z), Quaternion.identity, wallsParent.transform);
                    }
                    if (z < 0)
                    {
                        Object.Instantiate(wall_D, new Vector3(x, 0, z), Quaternion.identity, wallsParent.transform);
                    }
                }

                if (currentChar == '|')
                {
                    if (x < 0)
                    {
                        Object.Instantiate(wall_L, new Vector3(x, 0, z), Quaternion.identity, wallsParent.transform);
                    }

                    if (x > 0)
                    {
                        Object.Instantiate(wall_R, new Vector3(x, 0, z), Quaternion.identity, wallsParent.transform);
                    }
                }
            }
        }

    }
}