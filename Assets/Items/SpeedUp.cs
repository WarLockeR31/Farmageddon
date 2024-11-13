public class SpeedUp : Item
{
    public override float ActionTime
    {
        get => 5;
    }

    public override void Do()
    {
        PlayerState.MulSpeed(2);
    }

    public override void Undo()
    {
        PlayerState.ResetSpeed();
    }
}