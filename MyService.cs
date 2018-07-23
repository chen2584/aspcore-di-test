using System;

public class MyService
{
    public int num { get; set; }
    public int RandomNumber { get; set; }
    public MyService()
    {
        Random random = new Random();
        num = random.Next(1, 100);
    }
}