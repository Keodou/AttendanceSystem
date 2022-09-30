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

        public string GetRfidTag(string cardId)
        {
            _rfidReader.Open();
            cardId = _rfidReader.ReadLine();
            _rfidReader.Close();
            cardId = cardId.Replace('\r', ' ');
            return cardId;
        }
    }
}
