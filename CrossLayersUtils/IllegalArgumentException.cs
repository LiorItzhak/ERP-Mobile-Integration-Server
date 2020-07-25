using System;

namespace CrossLayersUtils
{
    public class IllegalArgumentException :ArgumentException
    {
        public IllegalArgumentException(string message)
            : base(message) { }
        
        public IllegalArgumentException(string message, string paramName)
            : base(message,paramName)
        {

        }
        
    }
    
    public class InvalidStateException :InvalidOperationException
    {
        public InvalidStateException(string message)
            : base(message) { }
  
        
    }
    
    public class NotFoundException : Exception
    {
        public NotFoundException(string message) : base(message){}
    }
}