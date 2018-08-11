namespace Adapter
{
    using System;

    internal class CommandSender
    {
        public void Push(BaseDevice device)
        {
            Console.WriteLine();
            Console.WriteLine("Execute push on device by inheritance");
            device.Push();
        }

        public void Push(IBaseDevice device)
        {
            Console.WriteLine();
            Console.WriteLine("Execute push on device by interface");
            device.Push();
        }
    }
}