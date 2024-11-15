public class GreenHeal : Item
{
    public override void Do()
    {
        var manager = Manager.getInstance();
        manager.PlayerHealth.Heal(2, HealthType.Green);
    }
}