using System.Collections.Generic;
using UnityEngine;

public class MovementComponent : MonoBehaviour
{
    private float speed = 0.1f;
    private Queue<Vector3> movePoints;
    private float reachDistance = 0.3f;
    
    private Vector3 velocity;
    public Vector3 Velocity => velocity;
    
    public event System.Action OnTargetReached;

    private Vector3 movePoint;
    
    void Update()
    {
        if (movePoints == null || movePoints.Count == 0) return;
        
        if (Vector3.Distance(transform.position, movePoint) <= reachDistance)
        {
            movePoints.Enqueue(movePoint);
            movePoint = movePoints.Dequeue();
            return;
        }
        
        var direction = (movePoint - transform.position).normalized;
        velocity = direction * speed;
        
        transform.Translate(velocity * Time.deltaTime, Space.World);
    }
    
    public void OnGetFromPool(Queue<Vector3> newMovePoints, float speed, float reachDistance)
    {
        movePoints = new Queue<Vector3>(newMovePoints);
        movePoint = movePoints.Dequeue();
        this.speed = speed;
        this.reachDistance = reachDistance;
    }
} 