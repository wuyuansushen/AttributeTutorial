using System;
using System.Runtime.InteropServices;
using System.Runtime;
using System.Reflection;

namespace AttributeTutorial
{
    [AttributeUsage(AttributeTargets.Class|AttributeTargets.Struct,AllowMultiple =true)]
    public class AuthorAttribute:Attribute
    {
        private string name;
        public string version { get; set; }
        public AuthorAttribute(string AuthorName)
        {
            name = AuthorName;
            version = "1.0.0";
        }
        public string GetName()
        {
            return name;
        }
    }

    [type:Author(AuthorName:"NullP",version ="1.1.1")]
    [type:Author(AuthorName:"NullW",version ="1.1.2")]
    class Program
    {
        static void Main(string[] args)
        {
            Attribute[] attArr = System.Attribute.GetCustomAttributes(typeof(Program));
            foreach ( var i in attArr)
            {
                Console.WriteLine(i);
                if(i is AuthorAttribute)
                {
                    AuthorAttribute a = (AuthorAttribute)i;
                    Console.WriteLine($"Author: {a.GetName()}, Version: {a.version}");
                }
                Console.WriteLine();
            }
        }
    }
}
