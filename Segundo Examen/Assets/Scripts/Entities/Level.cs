using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Level
{
    public Level()
    {
        Bricks = new List<Brick>();
    }

    [Serializable]
    public class Brick
    {
        public BrickTypes BrickType;
        public Vector3 Position;
        public Quaternion Rotation;
        public int HitsCount;
        public string[] BreakSounds;
        public string[] DamageSrpites;
        public string Sprite;
    }

    public int Score;
    public int Scene;
    public List<Brick> Bricks;

    public void Save()
    {
        FileSystem<Level> fileSystem = new FileSystem<Level>();
        fileSystem.Save(this);
    }

    public static Level Load()
    {
        FileSystem<Level> fileSystem = new FileSystem<Level>();
        return fileSystem.load();
    }
}
