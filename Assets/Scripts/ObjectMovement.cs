using UnityEngine;
using UnityEngine.UI;

public class ObjectMovement : MonoBehaviour
{
    [SerializeField] private float _speedMovement;
    [SerializeField] private float _speedRotation;
    private Vector3[] _pointMovement;
    private bool _isMoving;
    private bool _isLoop;
    private int _nextNumberPoint;
    private int _maxAmointPoint;

    public void DownloadData(DataPoint data)
    {
        _pointMovement = data._pointMovement;
        _isLoop = data._isLoop == 1;
    }

    public void SetMaxAmountPoint(int amount)
    {
        _maxAmointPoint = amount;
    }

    public void InversIsMoving()
    {
        _isMoving = !_isMoving;
    }

    private void Update()
    {
        if (!_isMoving) return;

        transform.Translate(_speedMovement * transform.forward * Time.deltaTime, Space.World);
        transform.rotation = GetRotationToTarget(_pointMovement[_nextNumberPoint], transform, _speedRotation);

        if (Vector3.Distance(transform.position, _pointMovement[_nextNumberPoint]) < 1 && _nextNumberPoint < _pointMovement.Length)
        {
            _nextNumberPoint++;
            if (_nextNumberPoint >= _pointMovement.Length || _nextNumberPoint >= _maxAmointPoint)
                OnWayIsEnd();
        }
    }

    private Quaternion GetRotationToTarget(Vector3 _target, Transform transform, float speed, Vector3 offset = new Vector3())
    {
        Vector3 direction = _target + offset - transform.position;
        Quaternion rotation = Quaternion.LookRotation(direction);
        return Quaternion.Lerp(transform.rotation, rotation, speed * Time.deltaTime);
    }
    
    private void OnWayIsEnd()
    {
        if (_isLoop)
            _nextNumberPoint = 0;
        else
            _isMoving = false;
    }
}