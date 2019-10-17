using System;
using System.Collections.Generic;
using static SwitchBoard.Appliance;

namespace SwitchBoard
{
    class Switch
    {
        public Appliance appliance;
        public bool Status;
        public Stack<string> DurationLogs;
        static Random random = new Random();

        public void InitializeLogs()
        {
            this.DurationLogs = new Stack<string>();
            DurationLogs.Push(string.Format("{0}-{1}. Status : {2} created at {3}",appliance.Name, appliance.id,"Off",DateTime.Now.ToString()));
        }

        public Switch(ApplianceType type)
        {
            switch (type)
            {
                case ApplianceType.Fan:
                    appliance = new Fan(random.Next());
                    break;
                case ApplianceType.Light:
                    appliance = new Light(random.Next());
                    break;
                case ApplianceType.AC:
                    appliance = new AC(random.Next());
                    break;
                default:
                    break;
            }
            InitializeLogs();
        }
        public Switch(string name)
        {
            appliance = new Other(random.Next(), name);
            InitializeLogs();
        }
        public string Toggle()
        {
            Status = !Status;
            DurationLogs.Push(String.Format("{0}-{1} Status : {2} at {3}", appliance.Name, appliance.id,Status?"On":"Off",DateTime.Now.ToString()));
            return "Switch is " + (Status ? "On" : "Off");
        }
        public string GetLastDuration()
        {
            return DurationLogs.Peek();
        }
        public string GetDurationLogs()
        {
            string response = "";
            foreach(string s in DurationLogs)
            {
                response+= s + "\n";
            }
            return response;
        }
    }
}
