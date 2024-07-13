using WUG.BehaviorTreeVisualizer;

public abstract class Node : NodeBase {
    // Keeps track of the number of times the node has been evaluated in a single 'run'.
    public int EvaluationCount;

    // Runs the login for the node
    public virtual NodeStatus Run() {
        //Runs the 'custom' logic
        NodeStatus nodeStatus = OnRun();

        if (LastNodeStatus != nodeStatus || !m_LastStatusReason.Equals(StatusReason)) 
        {
            LastNodeStatus = nodeStatus;
            m_LastStatusReason = StatusReason;
            OnNodeStatusChanged(this);
        }

        // Increments the tracker for how many times the node has been evaluted this 'run'
        EvaluationCount++;
        
        // If the nodeStatus is not Running, then it is Success of Failure and can be Reset
        if (nodeStatus != NodeStatus.Running) {
            Reset();
        }

        // Return the StatusResult.
        return nodeStatus;
    }

    public void Reset() {
        EvaluationCount = 0;
        OnReset();
    }

    protected abstract NodeStatus OnRun();
    protected abstract void OnReset();

    private string m_LastStatusReason { get; set; } = "";
}
