using System;

namespace RandomColor
{
    public class Ghost 
    {
        private string color;
        public Ghost()
        {
            SetColor(); 
        }
        
        private void SetColor()
        {
            Random generate = new Random();
            int number = generate.Next(0, 4);
            switch(number){
            case 0:
                color = "red";
                break;
            case 1:
                color = "yellow";
                break;
            case 2:
                color = "purple";
                break;
            case 3:
                color = "white";
                break;
            
            }
            
        }
        public string GetColor()
        {
            return color;
        }
    }
}
