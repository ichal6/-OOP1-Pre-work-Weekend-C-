using System;

namespace AdamAndEve
{
    public class God 
    {
        public static Human[] Create()
        {
        return new Human[] {new Man(), new Woman()};
        }

    }

    public class Human
    {
    
    }

    class Man : Human
    {
  
    }

    class Woman : Human
    {

    }
}
