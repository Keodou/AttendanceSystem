using System.IO.Ports;

namespace RFIDSystem
{
    public class Reader
    {
        private readonly SerialPort _rfidReader;

        public Reader(SerialPort rfidReader)
        {
            rfidReader.PortName = "COM3";
            rfidReader.BaudRate = 9600;
            _rfidReader = rfidReader;
        }

        public void OpenSerialPort()
        {
            _rfidReader.Open();
        }

        public void CloseSerialPort()
        {
            _rfidReader.Close();
        }

        public string GetRfidTag(string tag)
        {
            _rfidReader.Open();
            tag = _rfidReader.ReadLine();
            _rfidReader.Close();
            tag = tag.Replace('\r', ' ');
            return tag;
        }
    }
}
