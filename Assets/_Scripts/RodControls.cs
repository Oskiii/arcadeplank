using System;
using UnityEngine;

public class RodControls : MonoBehaviour
{
    [SerializeField] private Transform _visual;
    public float Angle { get; private set; }

    private void Update()
    {
        Angle = LevelManager.Instance.RotationSpeed * Time.deltaTime;
        transform.Rotate(0f, 0f, Angle);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            AttachTo(LevelManager.Instance.PopDot());
        }
    }

    private void AttachTo(Dot dot)
    {
        //transform.SetParent(dot.transform, false);
        transform.position = dot.transform.position;
        FlipPivot();
        LevelManager.Instance.RotationSpeed *= -1;
    }

    private void FlipPivot()
    {
        Vector3 visualPosition = _visual.localPosition;
        visualPosition.x = 0;
        visualPosition.y = Math.Abs(visualPosition.y - 1) < 0.05f ? -1 : 1;
        visualPosition.z = 0;
        _visual.localPosition = visualPosition;
    }
}