using System;
using System.IO.Ports;

namespace ComPortDeviceCommunicate.Interfaces
{
	public interface IComPortTransceiver
	{
		byte[] SendAndRead(SerialPort serialPort, byte[] bytesToWrite);
		byte[] BytesToWrite { get; }
		byte[] ReceivedBytes { get; }
		event Action BytesToWriteChanged;
		event Action ReceivedBytesChanged;
	}
}
