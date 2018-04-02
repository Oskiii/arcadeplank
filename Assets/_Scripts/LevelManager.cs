using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance;
    public List<Dot> Dots = new List<Dot>();

    private void Awake()
    {
        Instance = this;
    }
}