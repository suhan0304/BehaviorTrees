using WUG.BehaviorTreeVisualizer;

public class AreItemsNearBy : Condition {
    private float m_DistanceToCheck;
    
    public AreItemsNearBy (float maxDistance) : base($"Are Items within {maxDistance}?") 
    {
        m_DistanceToCheck = maxDistance;
    }

    protected override void OnReset() { }

    public override NodeStatus OnRun() 
    {
        // Check for references
        if (GameMan)
    }
}