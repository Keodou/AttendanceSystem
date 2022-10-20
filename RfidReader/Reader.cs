﻿using System.IO.Ports;

namespace RfidReader
{
    public class Reader
    {
        private SerialPort _rfidReader;

        public Reader(SerialPort rfidReader)
        {
            rfidReader.BaudRate = 9600;
            _rfidReader = rfidReader;
            //ports = SerialPort.GetPortNames();
        }

        public string[] GetPortsArray()
        {
            return SerialPort.GetPortNames();
        }

        public void OpenSerialPort()
        {
            _rfidReader.Open();
        }

        public void CloseSerialPort()
        {
            _rfidReader.Close();
        }

        public string SelectPort()
        {
            var ports = GetPortsArray();
            Dictionary<int, string> portNames = new();
            for (int i = 0; i < ports.Length; i++)
            {
                portNames.Add(i, ports[i]);
                Console.WriteLine($"{i}. {portNames[i]}");
            }
            int numPort = int.Parse(Console.ReadLine());
            _rfidReader.PortName = portNames[numPort];
            Console.WriteLine(_rfidReader.PortName);
            return _rfidReader.PortName;
        }

        public string GetRfidTag(string tag)
        {
            _rfidReader.Open();
            tag = _rfidReader.ReadLine();
            _rfidReader.Close();
            tag = tag.Replace('\r', ' ');
            return tag;
        }

        public string GetRfidTag()
        {
            var tag = _rfidReader.ReadLine();
            return tag.Replace('\r', ' ');
        }
    }
}