using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace WWESmackdown
{
    public class imports
    {
        public uint ProcessID = 0;
        public imports(uint ProcessID) { this.ProcessID = ProcessID; }
        public void SetMemory(uint Address, ulong value)
        {
            byte[] b = BitConverter.GetBytes(value);
            Array.Reverse(b);
            PS3TMAPI.ProcessSetMemory(0, 0, ProcessID, 0, Address, b);
        }
        public void WriteByte(uint Address, byte value)
        {
            byte[] buff = new byte[1];
            buff[0] = value;
            PS3TMAPI.ProcessSetMemory(0, 0, ProcessID, 0, Address, buff);
        }
        public byte[] GetBytes(uint address, int length)
        {
            byte[] result = new byte[length];
            PS3TMAPI.ProcessGetMemory(0, 0, ProcessID, 0, address, ref result);
            return result;
        }
        public string ReadString(uint offset)
        {
            int blocksize = 40;
            int scalesize = 0;
            string str = string.Empty;

            while (!str.Contains('\0'))
            {
                byte[] buffer = GetBytes(offset + (uint)scalesize, blocksize);
                str += Encoding.UTF8.GetString(buffer);
                scalesize += blocksize;
            }
            return str.Substring(0, str.IndexOf('\0'));
        }
        public short ReadShort(uint address)
        {
            byte[] buff = GetBytes(address, 2);
            Array.Reverse(buff, 0, 2);
            return BitConverter.ToInt16(buff, 0);
        }
        public void WriteString(uint offset, string input)
        {
            byte[] buffer = Encoding.UTF8.GetBytes(input);
            Array.Resize(ref buffer, buffer.Length + 1);
            PS3TMAPI.ProcessSetMemory(0, 0, ProcessID, 0, offset, buffer);
        }
        public void WriteUInt16(uint offset, ushort input)
        {
            byte[] buff = new byte[2];
            BitConverter.GetBytes(input).CopyTo(buff, 0);
            Array.Reverse(buff, 0, 2);
            PS3TMAPI.ProcessSetMemory(0, 0, ProcessID, 0, offset, buff);
        }
    }
}
