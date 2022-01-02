using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterPathfindingMovementHandler : MonoBehaviour
{

    private const float speed = 2f;

    private int currentPathIndex;
    private List<Vector3> pathVectorList;

    public Vector3 GetPosition()
    {
        return transform.position;
    }

    public void SetTargetPosition(Vector3 targetPosition)
    {
        currentPathIndex = 0;
        pathVectorList = Pathfinding.Instance.FindPath(GetPosition(), targetPosition);

        if (pathVectorList != null && pathVectorList.Count > 1)
        {
            pathVectorList.RemoveAt(0);
        }
    }

    private void Update()
    {
        HandleMovement();
    }

    private void HandleMovement()
    {
        if (pathVectorList != null)
        {
            Vector3 targetPosition = pathVectorList[currentPathIndex];
            if (Vector3.Distance(transform.position, targetPosition) > 1f)
            {
                Vector3 moveDir = (targetPosition - transform.position);
                RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.forward);
                moveDir = new Vector3(moveDir.x, moveDir.y);
                moveDir.Normalize();
                transform.position = transform.position + moveDir * speed * Time.deltaTime;
                DirectionMove(moveDir);
            }
            else
            {
                currentPathIndex++;
                if (currentPathIndex >= pathVectorList.Count)
                {
                    StopMoving();
                }
            }
        }
    }
    private void DirectionMove(Vector3 direction)
    {

        var rotationZ = Mathf.Atan2(-direction.y, -direction.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0f, 0f, rotationZ);
    }
    private void StopMoving()
    {
        pathVectorList = null;
    }

}