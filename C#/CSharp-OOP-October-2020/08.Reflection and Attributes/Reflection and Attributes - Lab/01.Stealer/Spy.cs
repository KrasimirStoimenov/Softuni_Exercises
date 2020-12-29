using System;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Stealer
{
    public class Spy
    {
        public string StealFieldInfo(string classNameToInvestigate, params string[] fieldsToInvestigate)
        {
            var sb = new StringBuilder();

            var classType = Type.GetType(classNameToInvestigate);
            var initializationOfClass = Activator.CreateInstance(classType);

            var classFields = classType.GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static);

            sb.AppendLine(classType.Name);

            foreach (var field in classFields.Where(x => fieldsToInvestigate.Contains(x.Name)))
            {
                sb.AppendLine($"{field.Name} = {field.GetValue(initializationOfClass)}");
            }


            return sb.ToString().TrimEnd();
        }
    }
}
