using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lego.Ev3.Core;
using Lego.Ev3.Desktop;
using System.Diagnostics;

namespace LegoProject2017_byFocus
{
    class MainBrick
    {
        private Brick mybrick = new Brick(new UsbCommunication());

        public Brick Brick
        {
            get
            {
                return mybrick;
            }
            set
            {
                mybrick = value;
            }
        }

        public async Task ConnectToBrick()
        {
            try
            {
                await mybrick.ConnectAsync();
            
            }

            catch(Exception)
            {
                throw new Exception("Issue connecting to Brick, check connection !!!!!");
            }
        }







    }
    
}
