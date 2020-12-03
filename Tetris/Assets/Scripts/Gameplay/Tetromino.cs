using UnityEngine;

public class Tetromino : MonoBehaviour
{
    [SerializeField] private Transform rotationPoint;

    private Transform _transform;

    private void Awake()
    {
        _transform = transform;
    }

    public void MoveLeft()
    {
        _transform.position += Vector3.left;
    }
    
    public void MoveRight()
    {
        _transform.position += Vector3.right;
    }
    
    public void MoveDown()
    {
        _transform.position += Vector3.down;
    }
    
    public void MoveUp()
    {
        _transform.position += Vector3.up;
    }

    public void Rotate(float angle)
    {
        _transform.RotateAround(rotationPoint.position, Vector3.forward, angle);
    }
}
