using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignPatterns.Singleton
{
    public sealed class ConfigurationManager
    {
        private static ConfigurationManager instance;
        private static object syncRoot = new Object();

        private ConfigurationManager() 
        { 
        
        }

        public static ConfigurationManager GetInstance
        {
            get
            {
                // You could add a double if check if you wanted to further tweak the implementation
                // but in reality this will not lead to any significant performance gains
                //if (instance == null)
                //{
                    lock (syncRoot)
                    {
                        if (instance == null)
                        {
                            instance = new ConfigurationManager();
                        }
                    }
                //}

                return instance;
            }
        }

        public void DisplayConfiguration()
        {
            Console.WriteLine("Single instance object");
        }
    }
}

