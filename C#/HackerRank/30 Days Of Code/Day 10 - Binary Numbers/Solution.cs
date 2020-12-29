using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;

class Solution
{



    static void Main(string[] args)
    {
        int n = Convert.ToInt32(Console.ReadLine());

        string binary = Convert.ToString(n, 2);
        string[] array = binary.Split('0');

        Console.WriteLine(array.Select(x=>x.Length).Max());
    }
}
