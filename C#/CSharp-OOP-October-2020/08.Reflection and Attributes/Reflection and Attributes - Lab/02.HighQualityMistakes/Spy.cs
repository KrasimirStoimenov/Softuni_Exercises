﻿using System;
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

        public string AnalyzeAcessModifiers(string className)
        {
            var sb = new StringBuilder();

            Type classType = Type.GetType(className);

            var fields = classType.GetFields(BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static);
            foreach (FieldInfo field in fields)
            {
                sb.AppendLine($"{field.Name} must be private!");
            }

            var methods = classType.GetMethods(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static);

            foreach (var method in methods.Where(x => x.Name.StartsWith("get") && !x.IsPublic))
            {
                sb.AppendLine($"{method.Name} have to be public!");
            }

            foreach (var method in methods.Where(x => x.Name.StartsWith("set") && !x.IsPrivate))
            {
                sb.AppendLine($"{method.Name} have to be private!");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
