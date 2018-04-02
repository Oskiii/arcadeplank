using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform _followTarget;
    private Vector3 _offset;

    // Use this for initialization
    private void Start()
    {
        _offset = _followTarget.position - transform.position;
    }

    // Update is called once per frame
    private void Update()
    {
        transform.position = _followTarget.transform.position - _offset;
    }
}