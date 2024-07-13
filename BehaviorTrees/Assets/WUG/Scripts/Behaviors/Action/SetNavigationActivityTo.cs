using WUG.BehaviorTreeDemo;
using WUG.BehaviorTreeVisualizer;

public class SetNavigationActivityTo : Node 
{
    private NavigationActivity m_NewActicity;

    public SetNavigationActivityTo (NavigationActivity newActicity)
    {
        m_NewActicity = newActicity;
        Name = $"Set NavigationActivity to {m_NewActicity}";
    }

    protected override void OnReset() { }

    protected override NodeStatus OnRun() 
    {
        if (GameManager.Instance == null || GameManager.Instance.NPC == null) {
            StatusReason = "GameManager and/or NPC is null";
            return NodeStatus.Failure;
        }

        GameManager.Instance.NPC.MyActivity = m_NewActicity;

        return NodeStatus.Success;
    }
}