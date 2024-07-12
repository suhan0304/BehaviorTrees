using WUG.BehaviorTreeVisualizer;

public class Timer : Decorator {
    private float m_StartTime;
    private bool m_UseFixedTime;
    private float m_TimeToWait;

    public Timer(float timeToWait, Node childeNode, bool useFixedTime = false) : base($"Timer for {timeToWait}", childeNode) {
        m_UseFixedTime = useFixedTime;
        m_TimeToWait = timeToWait;
    }

    protected override void OnReset() { }
    protected override NodeStatus OnRun() {
        //Confirm that a valid child node was passed in the constructor
        if (ChildNodes.Count == 0 || ChildNodes[0] == null) {
            return NodeStatus.Failure;
        }


    }
}