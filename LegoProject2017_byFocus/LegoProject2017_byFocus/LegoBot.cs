using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lego.Ev3.Core;
using Lego.Ev3.Desktop;

namespace LegoProject2017_byFocus
{
    class LegoBot
    {
        private static MainBrick mainBrick;
        private GyroSensor gyroSensor;
        private ColourSensor colourSensor;
        private UltrasonicSensor ultrasonicSensor;
        private Motor motor;

        public static MainBrick MainBrick
        {
            get
            {
                return mainBrick;
            }
            set
            {
                mainBrick = value;
            }
        }

        public GyroSensor GyroSensor
        {
            get
            {
                return gyroSensor;
            }
            set
            {
                gyroSensor = value;
            }
        }

        public ColourSensor ColourSensor
        {
            get
            {
                return colourSensor;
            }
            set
            {
                colourSensor = value;
            }
        }

        public UltrasonicSensor UltrasonicSensor
        {
            get
            {
                return ultrasonicSensor;
            }
            set
            {
                ultrasonicSensor = value;
            }
        }

        public Motor Motor
        {
            get
            {
                return motor;
            }
            set
            {
                motor = value;
            }
         
        }

        public LegoBot()
        {
            mainBrick = new MainBrick();
            gyroSensor = new GyroSensor();
            ultrasonicSensor = new UltrasonicSensor();
            colourSensor = new ColourSensor();
            motor = new Motor();


        }

        public async Task MoveForward()
        {
            await MainBrick.Brick.DirectCommand.TurnMotorAtPowerForTimeAsync(OutputPort.A, 40, 50, true);
            await MainBrick.Brick.DirectCommand.TurnMotorAtPowerForTimeAsync(OutputPort.D, 40, 50, true);
            await Task.Delay(10);
        }
        public async Task MoveBackward()
        {
            await MainBrick.Brick.DirectCommand.TurnMotorAtPowerForTimeAsync(OutputPort.A, -40, 10, false);
            await MainBrick.Brick.DirectCommand.TurnMotorAtPowerForTimeAsync(OutputPort.D, -40, 10, false);
            await Task.Delay(10);
        }
        public async Task Stop()
        {
            await MainBrick.Brick.DirectCommand.StopMotorAsync(OutputPort.A | OutputPort.D, true);
        }

        public async Task TurnLeft()
        {
            // delay it by few milli sec
            await Task.Delay(100);

            // store current angle
            float currentAngle = gyroSensor.SIValue;
            while(gyroSensor.SIValue <= currentAngle - 90)
            {
                MainBrick.Brick.BatchCommand.TurnMotorAtPowerForTime(OutputPort.A, -30, 10, false);
                MainBrick.Brick.BatchCommand.TurnMotorAtPowerForTime(OutputPort.D, 30, 10, false);
                await MainBrick.Brick.BatchCommand.SendCommandAsync();
                await Task.Delay(10);
            }
        }

        public async Task TurnRight()
        {
            // delay it by few milli sec
            await Task.Delay(100);

            // store current angle
            float currentAngle = gyroSensor.SIValue;
            while (gyroSensor.SIValue <= currentAngle + 90)
            {
                MainBrick.Brick.BatchCommand.TurnMotorAtPowerForTime(OutputPort.A, 30, 10, false);
                MainBrick.Brick.BatchCommand.TurnMotorAtPowerForTime(OutputPort.D, -30, 10, false);
                await MainBrick.Brick.BatchCommand.SendCommandAsync();
                await Task.Delay(10);
            }
        }

        public async Task turnAround()
        {

            await Task.Delay(100);
            float currentAngle = GyroSensor.SIValue;

            while (gyroSensor.SIValue >= currentAngle - 720)
            {
                MainBrick.Brick.BatchCommand.TurnMotorAtPowerForTime(OutputPort.A, -27, 10, false);
                MainBrick.Brick.BatchCommand.TurnMotorAtPowerForTime(OutputPort.D, 27, 10, false);
                await MainBrick.Brick.BatchCommand.SendCommandAsync();
                await Task.Delay(100);
            }
        }


        // position legobot for free movement
        public async Task adjustPosition()
        {
            await Task.Delay(100);
            
            if( UltrasonicSensor.SIValue > 0 && UltrasonicSensor.SIValue < 10)
            {
                do { await MoveBackward(); }while(UltrasonicSensor.SIValue >= 20);
            }
            else if(UltrasonicSensor.SIValue > 20 && UltrasonicSensor.SIValue < 110)
            {
                do { await MoveForward(); } while (UltrasonicSensor.SIValue <= 20);
            }
            
        }
        
    }
}
