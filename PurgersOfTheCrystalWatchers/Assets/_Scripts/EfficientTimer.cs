using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace POTCW
{
    public class EfficientTimer
    {
        //A static timer that drives all other timers; ticks every .1 seconds
        static System.Timers.Timer GlobalTimer = new System.Timers.Timer(100);

        //What the EfficientTimer keeps track of time with
        public uint MyTimerCount = 0;

        public EfficientTimer()
        {
            GlobalTimer.Elapsed +=
                //Function that increases MyTimerCount every tick of GlobalTimer
                (object sender, System.Timers.ElapsedEventArgs e) => MyTimerCount++;
        }

        public float ToSeconds()
        {
            //Returns the time in seconds
            return .1f * MyTimerCount;
        }
    }
}
