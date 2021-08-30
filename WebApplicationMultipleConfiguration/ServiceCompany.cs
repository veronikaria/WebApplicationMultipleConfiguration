//using Microsoft.Extensions.Configuration;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;

//namespace WebApplicationMultipleConfiguration
//{
//    public interface IServiceCompany
//    {
//        IConfigurationSection Section { get; set; }
//        string getNameCompany();
//        int getNumberStuff();
//    }

//    public class ServiceMicrosoft : IServiceCompany
//    {
//        public IConfigurationSection Section { get; set; }
//        public string getNameCompany() => "Microsoft";
//        public int getNumberStuff()
//        {
//        }
//    }

//    public class ServiceGoogle : IServiceCompany
//    {
//        public IConfigurationSection Section { get; set; }
//        public string getNameCompany() => "Google";
//        public int getNumberStuff()
//        {
//        }
//    }

//    public class ServiceApple : IServiceCompany
//    {
//        public IConfigurationSection Section { get; set; }
        
//        public string getNameCompany() => "Apple";
//        public int getNumberStuff()
//        {
//        }
//    }
//}


