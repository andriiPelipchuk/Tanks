using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class AStar : MonoBehaviour {  
    public CharacterPathfindingMovementHandler characterPathfinding;
    public GameObject targetPosition;
    public Pathfinding pathfinding;

    private void Awake() {
        pathfinding = new Pathfinding(45, 45);
    }

}
