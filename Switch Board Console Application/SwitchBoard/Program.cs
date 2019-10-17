using System;
namespace SwitchBoard
{
    
    class UserSwitchBoardInterface
    {
        
        static void Main(string[] args)
        { 
            SwitchBoard switchBoard = new SwitchBoard();
            Console.WriteLine("SWITCH BOARD CONSOLE APPLICATION");
            while (true)
                {
                try
                {
                    Console.WriteLine("\nChoose an action from below");
                    Console.WriteLine("1. Add an appliance");
                    Console.WriteLine("2. Operate on an appliance");
                    Console.WriteLine("3. See status of all appliances");
                    Console.WriteLine("4. Exit\n");
                    Console.WriteLine("Enter your choice");
                    int choice = Convert.ToInt32(Console.ReadLine());

                    switch (choice)
                    {
                        case 1:
                            while (true) {
                                try
                                {
                                    Console.WriteLine("\nChoose an appliance to add from below");
                                    int ApplianceNamesLength = Enum.GetNames(typeof(ApplianceType)).Length;
                                    for (int i = 1; i <= ApplianceNamesLength; i++)
                                    {
                                        Console.WriteLine("{0}. {1}", i, (ApplianceType)i);
                                    }

                                    Console.WriteLine();
                                    Console.WriteLine("Enter your choice");

                                    int NameChoice = Convert.ToInt32(Console.ReadLine());
                                    if (NameChoice <= 0 || NameChoice > ApplianceNamesLength)
                                    {
                                        Console.WriteLine("Enter valid choice");
                                        continue;
                                    }
                                    if (NameChoice == ApplianceNamesLength)
                                    {
                                        Console.WriteLine();
                                        Console.WriteLine("Enter the name of the Appliance");
                                        if (switchBoard.AddAppliance(name: Console.ReadLine()))
                                        {
                                            Console.WriteLine("Appliance added succesfully\n");
                                        }
                                    }
                                    else
                                    {
                                        if (switchBoard.AddAppliance(choice: NameChoice))
                                        {
                                            Console.WriteLine("Appliance added succesfully\n");
                                        }
                                    }
                                    break;

                                }
                                catch (FormatException)
                                {
                                    Console.WriteLine("Please enter only number");
                                }
                            }
                            break;
                        case 2:
                            
                            if (!(switchBoard.Switches.Count > 0))
                            {
                                Console.WriteLine("There are no appliances connected");
                                break;
                            }
                            while (true)
                            {
                                int inc = 0;
                                Console.WriteLine("\n Choose an appliance to operate on from below");
                                foreach (Switch swi in switchBoard.Switches)
                                {
                                    Console.WriteLine("{0}. {1}-{2}", ++inc, swi.appliance.Name, swi.appliance.id);
                                }

                                Console.WriteLine("{0}. Return to main menu", ++inc);
                                Console.WriteLine();
                                Console.WriteLine("Enter your choice");
                                int applianceChoice = Convert.ToInt32(Console.ReadLine());
                                if (applianceChoice == inc)
                                {
                                    break;
                                }
                                if (applianceChoice < 1 || applianceChoice > inc)
                                {
                                    Console.WriteLine("Enter valid choice");
                                    continue;
                                }
                                while (true)
                                {
                                    Console.WriteLine("\nChoose an operation from below");
                                    Console.WriteLine("1. Toggle switch");
                                    Console.WriteLine("2. See status");
                                    Console.WriteLine("3. See logs");
                                    Console.WriteLine("4. Remove this appliance");
                                    Console.WriteLine("5. Go back and see all appliances");
                                    Console.WriteLine();
                                    try
                                    {
                                        int operation = Convert.ToInt32(Console.ReadLine());
                                        if (operation == 5)
                                        {
                                            break;
                                        }
                                        if (operation < 1 || operation > 5)
                                        {
                                            Console.WriteLine("Enter valid number\n");
                                            continue;
                                        }
                                        Console.WriteLine(switchBoard.OperateOnAnAppliance(applianceChoice, operation));
                                    }
                                    catch (FormatException)
                                    {
                                        Console.WriteLine("please enter only number");
                                    }
                                }
                                
                            }
                            break;
                        case 3:
                            string response = switchBoard.StatusOfAllAppliances();
                            if (response == "")
                            {
                                Console.WriteLine("There are no appliances connected");
                            }
                            else
                            {
                                Console.WriteLine(response);
                            }
                            break;
                        case 4:
                            return;
                        default:
                            Console.WriteLine("Enter valid number\n");
                            break;
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Please enter only number\n");
                }
            }
            
        }
    }
}
