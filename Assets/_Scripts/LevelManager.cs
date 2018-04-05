using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance;
    [SerializeField] private RodControls _player;

    public List<float> Delays = new List<float>
    {
        0.1f,
        0.2f,
        0.15f,
        0.5f,
        0.3f,
        0.4f,
        0.3f,
        0.2f,
        0.3f,
        0.2f,
        0.1f
    };

    public List<Dot> Dots = new List<Dot>();
    public float RotationSpeed = 360f;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        PositionDots();
    }

    private void PositionDots()
    {
        Vector3 prevPos = Vector3.zero;
        var prevAngle = 0f;
        for (var i = 0; i < Dots.Count; i++)
        {
            Dot dot = Dots[i];
            float delay = Delays[i];
            int rotDirection = i % 2 == 0 ? 1 : -1;

            float angle = GetAngleForDelay(delay, RotationSpeed);
            angle *= rotDirection;
            angle *= -0.5f;
            angle += prevAngle;
            print(angle);
            dot.transform.position = Quaternion.AngleAxis(angle, Vector3.forward) * Vector3.up * 3 + prevPos;

            prevPos = dot.transform.position;
            prevAngle = angle;
        }
    }

    private float GetAngleForDelay(float delay, float rotationSpeed)
    {
        return rotationSpeed * delay;
    }

    public Dot PopDot()
    {
        return Dots.PopAt(0);
    }
}