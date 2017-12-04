using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UdpBroadcastCapture
{
    public class Motion
    {



        public int ID { get; set; }

        public string MotionBool { get; set; }

        public string MotionLevel { get; set; }

        public string Picture { get; set; }

        public string DateTime { get; set; }

        public Motion()
        {
        }

        public Motion(string picture)
        {
            //this.ID = Service1.NextId++;
            this.Picture = picture;
        }

        public Motion(string motionBool, string motionLevel, string picture, string dateTime)
        {
            // this.ID = Service1.NextId++;
            this.MotionBool = motionBool;
            this.MotionLevel = motionLevel;
            this.Picture = picture;
            this.DateTime = dateTime;
        }
    }
}