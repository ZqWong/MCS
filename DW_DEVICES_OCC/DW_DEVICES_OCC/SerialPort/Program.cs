using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.IO.Ports;




public class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine($"SerialPort.GetPortNames() {SerialPort.GetPortNames().Length}");
        foreach (var item in SerialPort.GetPortNames())
        {
            Console.WriteLine(item);
        }

        var str = Console.ReadLine();
    }
}

