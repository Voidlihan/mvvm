using System;

namespace ChainOfResponsibility
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
    public class Client
    {

    }
    public class IRequest
    {
        public string Name
    }
    public interface IHandler
    {
        void SetNext(IHandler handler);
        void Handle();
    }
    public abstract class BaseHandler : IHandler
    {
        private BaseHandler _handler;

        public abstract void Handle();
        public abstract void SetNext(IHandler handler)
        {
            _handler = handler;
        }
    }
    public class LoginCheckHandler : BaseHandler
    {
        public override void Handle(IRequest request)
        {
            
        }
    }
}
