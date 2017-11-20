using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lego.Ev3.Core;
using Lego.Ev3.Desktop;

namespace LegoProject2017_byFocus
{
    public class ColourSensor
    {
        
        public float SIValue;
        //public float perValue;
        //public float rawValue;

        public ColourSensor()
        {
            LegoBot.MainBrick.Brick.BrickChanged += Brick_BrickChanged;
        }

        public void Brick_BrickChanged(object sender, BrickChangedEventArgs e)
        {
            //throw new NotImplementedException();
            SIValue = e.Ports[InputPort.Three].SIValue;
        }

        public float getColorSIValue()
        {
            return SIValue;
        }
        
    }
}
