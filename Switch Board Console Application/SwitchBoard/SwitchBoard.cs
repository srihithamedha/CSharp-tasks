
using System.Collections.Generic;

namespace SwitchBoard
{
    interface ISwitchBoard
    {
        bool AddAppliance(int choice,string name);
        string OperateOnAnAppliance(int choice,int operation);
        string StatusOfAllAppliances();
    }

    class SwitchBoard : ISwitchBoard
    {
        public List<Switch> Switches;
   
        public Dictionary<string, int> CountByCategory
        {
            get
            {
                return GetUpdatedList();
            }
          
        }

        public Dictionary<string,int> GetUpdatedList()
        {
            Dictionary<string, int> countByCategory = new Dictionary<string, int>();
            for (int i = 0; i < Switches.Count; i++)
            {
                if (countByCategory.ContainsKey(Switches[i].appliance.Name))
                {
                    countByCategory[Switches[i].appliance.Name]++;
                }
                else
                {
                    countByCategory.Add(Switches[i].appliance.Name, 1);
                }
            }
            return countByCategory;
        }

        public SwitchBoard()
        { 
            Switches = new List<Switch>();
        }

        public bool AddAppliance(int choice = 0, string name = null)
        {
            if (choice != 0)
            {
                Switches.Add(new Switch((ApplianceType)choice));
            }
            if(name != null)
            {
                Switches.Add(new Switch(name));
            }
            return true;
        }
        public string OperateOnAnAppliance(int choice,int operation) {
            Switch s = Switches[choice - 1];
            string response = "";
            switch (operation)
            {
                case 1:
                    response = s.Toggle();
                    break;
                case 2:
                    response = s.GetLastDuration();
                    break;
                case 3:
                    response = s.GetDurationLogs();
                    break;
                case 4:
                    Switches.RemoveAt(choice - 1);
                    response = "Appliance removed succesfully";
                    break;
            }
            return response;
        }
        public string StatusOfAllAppliances()
        {
            string response = "";
            foreach (Switch s in Switches)
            {
                response += s.GetLastDuration()+"\n";
            }
            return response;
        }
       
    }
}