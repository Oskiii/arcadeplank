using System;
using UnityEngine;

public class RodControls : MonoBehaviour
{
    [SerializeField] private float _rotationSpeed = 1f;
    [SerializeField] private Transform _visual;

    private void Update()
    {
        transform.Rotate(0f, 0f, _rotationSpeed);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            AttachTo(LevelManager.Instance.Dots.PopAt(0));
        }
    }

    private void AttachTo(Dot dot)
    {
        //transform.SetParent(dot.transform, false);
        transform.position = dot.transform.position;
        FlipPivot();
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