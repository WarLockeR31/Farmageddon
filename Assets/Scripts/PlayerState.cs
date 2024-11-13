public static class PlayerState
{
    //// Speed ////
    private static float defaultSpeed = 20;
    private static float speed = defaultSpeed;

    public static float Speed { get { return speed; } }

    public static void MulSpeed(float mult)
    {
        speed *= mult;
    }

    public static void ResetSpeed()
    {
        speed = defaultSpeed;
    }

    //// Damage ////
} 