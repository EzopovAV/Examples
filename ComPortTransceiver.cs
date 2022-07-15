using ComPortDeviceCommunicate.Interfaces;
using System;
using System.IO.Ports;

namespace ComPortDeviceCommunicate
{
	class ComPortTransceiver : IComPortTransceiver
	{
		public byte[] BytesToWrite { get; private set; }
		public byte[] ReceivedBytes { get; private set; }

		public event Action BytesToWriteChanged;
		public event Action ReceivedBytesChanged;

		public byte[] SendAndRead(SerialPort serialPort, byte[] bytesToWrite)
		{
			BytesToWrite = bytesToWrite;
			BytesToWriteChanged?.Invoke();

			var bytesToRead = new byte[bytesToWrite.Length];

			for (int i = 0; i < bytesToWrite.Length; i++)
			{
				serialPort.Write(bytesToWrite, i, 1);
				serialPort.Read(bytesToRead, i, 1);
			}

			ReceivedBytes = bytesToRead;
			ReceivedBytesChanged?.Invoke();

			return bytesToRead;
		}
	}
}