using WUG.BehaviorTreeDemo;

public class IsNavigationActivityTypeOf : Condition {
    private NavigationActivity m_ActivityToCheckFor;

    public IsNavigationActivityTypeOf(NavigationActivity activity) : base($"Is Navigation Activity {activity}?") {
        m_ActivityToCheckFor = activity;
    }

    
}