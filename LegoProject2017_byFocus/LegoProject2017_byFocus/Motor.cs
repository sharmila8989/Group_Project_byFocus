using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lego.Ev3.Core;
using Lego.Ev3.Desktop;

namespace LegoProject2017_byFocus
{
    class Motor
    {
        
        public async Task TurnMotorAtPowerForTimeAsync(OutputPort outPort, int power, uint time, bool Bool)
        {
            await LegoBot.MainBrick.Brick.DirectCommand.TurnMotorAtPowerForTimeAsync(outPort, power, time, Bool);
        }

        public async Task StopMotor(OutputPort outPort)
        {
            await LegoBot.MainBrick.Brick.DirectCommand.StopMotorAsync(outPort, true);
        }
    }
}
