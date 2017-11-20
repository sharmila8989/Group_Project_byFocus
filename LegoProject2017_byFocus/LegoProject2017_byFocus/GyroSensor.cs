using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lego.Ev3.Core;
using Lego.Ev3.Desktop;

namespace LegoProject2017_byFocus
{
    public class GyroSensor
    {
        public float SIValue;   

        public GyroSensor()
        {
            LegoBot.MainBrick.Brick.BrickChanged += Brick_BrickChanged;
        }

        public void Brick_BrickChanged(object sender, BrickChangedEventArgs e)
        {
            //throw new NotImplementedException();
            SIValue = e.Ports[InputPort.One].SIValue;
        }

        public float getSIValue()
        {
            return SIValue;
        }


    }
}
