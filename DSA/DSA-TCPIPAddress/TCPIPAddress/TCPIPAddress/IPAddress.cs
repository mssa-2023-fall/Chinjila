using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace TCPIPAddress
{
    public class IPAddress
    {
        byte[] addressByte = new byte[4];
        byte[] subnetMask = new byte[4];
        public string SubnetOctetString = string.Empty;
        public string SubnetDecString = string.Empty;
        public string AddressOctetString = string.Empty;
        public string AddressDecString = string.Empty;
        public int SubnetSuffix;

        public IPAddress(string addressString)
        {
            if (!IsValidAddress(addressString)) {
                throw new ArgumentException();
            }

            string[] addresses = addressString.Split('/');

            AddressDecString = addresses[0];
            SubnetSuffix = int.Parse(addresses[1]);

            for (int i = 0; i < 4; i++)
            {
                addressByte[i] = byte.Parse(addresses[0].Split('.')[i]);
                AddressOctetString += $"{Convert.ToString(addressByte[i],2).PadLeft(8, '0')}.";
            }
            AddressOctetString = AddressOctetString[0..^1];//rid extra . at the end
            
            var subnetString =
                new String(Enumerable.Repeat<char>('1', SubnetSuffix).ToArray()).PadRight(32, '0');

            subnetMask[0] = Convert.ToByte(Convert.ToInt16(subnetString[0..8], 2));
            subnetMask[1] = Convert.ToByte(Convert.ToInt16(subnetString[8..16], 2));
            subnetMask[2] = Convert.ToByte(Convert.ToInt16(subnetString[16..24], 2));
            subnetMask[3] = Convert.ToByte(Convert.ToInt16(subnetString[24..32], 2));

            SubnetOctetString = $"{subnetString[0..8]}.{subnetString[8..16]}.{subnetString[16..24]}.{subnetString[24..32]}";
            SubnetDecString = $"{subnetMask[0]}.{subnetMask[1]}.{subnetMask[2]}.{subnetMask[3]}";
        }
        private bool IsValidAddress(string addressString)
        {
            string[] addresses = addressString.Split('/');
            if (addresses.Length != 2) { return false; };//missing /
            if (addresses[0].Split('.').Length != 4) { return false; };//bad ip address, must contain 4 parts
            foreach (string octet in addresses[0].Split('.')) {
                if (!byte.TryParse(octet, out _)) return false; //if any part is not a byte, its wrong
            }
            if (byte.TryParse(addresses[1], out byte value))//the subnet portion should be number greater than 0 and less than 32
            {
                if (value > 32 || value < 0) return false;
            }
            else
            { return false; }
            return true;
        }
        public string NetworkID => 
            $"{addressByte[0] & subnetMask[0]}.{addressByte[1] & subnetMask[1]}.{addressByte[2] & subnetMask[2]}.{addressByte[3] & subnetMask[3]}";
        private byte[] NetworkIDBytes {
            get {
                byte[] result = new byte[4];
                result[0] = (byte)(addressByte[0] & subnetMask[0]);
                result[1] = (byte)(addressByte[1] & subnetMask[1]);
                result[2] = (byte)(addressByte[2] & subnetMask[2]);
                result[3] = (byte)(addressByte[3] & subnetMask[3]);
                return result;
            }
        }
        public double NumberOfAddress => Math.Pow(2,(32-SubnetSuffix));
        public string LastAddress
        {
            get {
                ulong networkID = (uint)NetworkIDBytes[0] * 256 * 256 * 256 + (uint)NetworkIDBytes[1] * 256 * 256 + (uint)NetworkIDBytes[2] * 256 + (uint)NetworkIDBytes[3];
                ulong endAddress = networkID + (ulong)NumberOfAddress-1;
                var a = endAddress / (256 * 256 * 256);
                var b = (endAddress % (256 * 256 * 256)) / (256 * 256);
                var c = ((endAddress % (256 * 256 * 256)) % (256 * 256)) / 256;
                var d = ((endAddress % (256 * 256 * 256)) % (256 * 256)) % 256;
                return $"{a}.{b}.{c}.{d}";
            }
        }

        public bool IsSameNetwork(IPAddress other)=> this.NetworkID== other.NetworkID;
    }
}
