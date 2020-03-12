using System;

namespace Guns
{
    class Program
    {
        static void Main(string[] args)
        {
             
        }

    }
    public class Hero
    {
        public SetKill { get; }
    }
    public interface Kill
    {
        public void Execute()
        {
            Console.WriteLine($"");
        }
    }
    public class Gun : Kill
    {

    }
    public class Knife : Kill
    {

    }
}
