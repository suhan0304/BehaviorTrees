public class Inverter : Decorator
{
    public Inverter(string displayName, Node childNode) : base(displayName, childNode)

    protected override void OnReset() {}

    protected override NodeStatus OnRun() {
        
    }
}