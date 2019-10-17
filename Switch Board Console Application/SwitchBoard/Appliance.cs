
using System;

namespace SwitchBoard
{
    public enum ApplianceType { Fan = 1, Light, AC, Other };

    abstract class Appliance
    {
        public int id;
        public string Name;
        public ApplianceType applianceType;
        public Appliance(int id,string name)
        {
            this.id = id;
            this.Name = name;
            if(Enum.IsDefined(typeof(ApplianceType),this.Name))
                applianceType = (ApplianceType)Enum.Parse(typeof(ApplianceType), this.Name);
            else applianceType = (ApplianceType)Enum.Parse(typeof(ApplianceType), "Other");
        }
    }

    class Fan : Appliance
    {
        public Fan(int id) : base(id,"Fan") { }
    }
    class Light : Appliance
    {

        public Light(int id):base(id, "Light"){ }
    }
    class AC : Appliance
    {
        public AC(int id) : base(id, "A/C") { }
    }
    class Other : Appliance
    { 
        public Other(int id, string name):base(id, name){ }
    }
}
