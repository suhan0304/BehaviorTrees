using UnityEngine;
using UnityEngine.AI;
using WUG.BehaviorTreeDemo;
using WUG.BehaviorTreeVisualizer;

public class NavigateToDestination : Node {
    private Vector3 m_TargetDistination;

    public NavigateToDestination()
    {
        Name = "Navigate";
    }

    protected override void OnReset(){ }

    protected override NodeStatus OnRun()
    {
        // Check for references
        if (GameManager.Instance == null || GameManager.Instance.NPC == null) {
            StatusReason = "GameManager and/or NPC is null";
            return NodeStatus.Failure;
        }

        // Perform logic that should only run once
        if (EvalutaionCount == 0)
        {
            // Get destination from GameManager
            GameObject destinationGO = GameManager.Instance.NPC.MyActivity == NavigationActivity.PickupItem ? GameManager.Instance.GetClosestItem() : GameManager.Instance.GetNextWayPoint();

            // Confirm that the destination is valid - If not, fail
            if (destinationGO == null) 
            {
                StatusReason = $"Unable to find game object for {GameManager.Instance.NPC.MyActivity}";
                return NodeStatus.Failure;
            }

            // Get a valid location on the NavMesh that's near the target destination
            NavMesh.SamplePosition(destinationGO.transform.position, out NavMeshHit hit, 1f, 1);

            // set the location for checks later
            m_TargetDistination = hit.position;

            // Set the destination on the NavMesh. This tells the AI to start moving to the new location.
            GameManager.Instance.NPC.MyNavMesh.SetDestination(m_TargetDistination);
            StatusReason = $"Starting to navigate to {destinationGO.transform.position}";

            // Return running, as we want to continue to have this node evaluate
            return NodeStatus.Running;
        }

        // Calculate how far the AI is from the destination
        float distanceToTarget = Vector3.Distance(m_TargetDistination, GameManager.Instance.NPC.transform.position);
        
        // If the AI is within .25f then navigation will bec onsidered a success
        if (distanceToTarget < .25f) {
            StatusReason = $"Navigation ended. " +
                $"\n - Evalutaion Count : {EvaluationCount}"
        }
    }
}