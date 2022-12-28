using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WWESmackdown
{
    
    public class Abilities
    {
        uint baseAddress;
        private class Common
        {
            public static imports imports;
        }
        public Abilities()
        {
            this.baseAddress = MoveSets.baseAddress; Common.imports = new imports(0xDEADBEEF); /*Provide ProcessID*/
        }
        enums.eAbilities Ability1 { get { return (enums.eAbilities)Common.imports.GetBytes(baseAddress, 1)[0]; } set { Common.imports.WriteByte(baseAddress, (byte)value); } }
        enums.eAbilities Ability2 { get { return (enums.eAbilities)Common.imports.GetBytes(baseAddress, 1)[0]; } set { Common.imports.WriteByte(baseAddress, (byte)value); } }
        enums.eAbilities Ability3 { get { return (enums.eAbilities)Common.imports.GetBytes(baseAddress, 1)[0]; } set { Common.imports.WriteByte(baseAddress, (byte)value); } }
        enums.eAbilities Ability4 { get { return (enums.eAbilities)Common.imports.GetBytes(baseAddress, 1)[0]; } set { Common.imports.WriteByte(baseAddress, (byte)value); } }
        enums.eAbilities Ability5 { get { return (enums.eAbilities)Common.imports.GetBytes(baseAddress, 1)[0]; } set { Common.imports.WriteByte(baseAddress, (byte)value); } }
        public void SetAbility(int slot, enums.eAbilities Ability)
        {
            switch (slot)
            {
                case 1: Ability1 = Ability; break;
                case 2: Ability2 = Ability; break;
                case 3: Ability3 = Ability; break;
                case 4: Ability4 = Ability; break;
                case 5: Ability5 = Ability; break;
                default:
                    break;
            }

        }
    }

    public class StandardActions {
        uint baseAddress;
        private class Common { public static imports imports; }
        public StandardActions() { this.baseAddress = MoveSets.baseAddress; Common.imports = new imports(0xDEADBEEF); /*Provide ProcessID*/ }

      public class RingInOut {
          uint baseAddress;
          public RingInOut() { this.baseAddress = MoveSets.baseAddress; Common.imports = new imports(0xDEADBEEF); /*Provide ProcessID*/ }
          enums.eRingIn RingIn { get { return (enums.eRingIn)Common.imports.ReadShort(baseAddress); } set { Common.imports.WriteUInt16(baseAddress, (ushort)value); } }
          enums.eRingOut RingOut { get { return (enums.eRingOut)Common.imports.ReadShort(baseAddress); } set { Common.imports.WriteUInt16(baseAddress, (ushort)value); } }

      }
      public class ApronRingInOut {
          uint baseAddress;
          public ApronRingInOut() { this.baseAddress = MoveSets.baseAddress; Common.imports = new imports(0xDEADBEEF); /*Provide ProcessID*/ }

      }
      public class ApronRingsideInOut {
          uint baseAddress;
          public ApronRingsideInOut() { this.baseAddress = MoveSets.baseAddress; Common.imports = new imports(0xDEADBEEF); /*Provide ProcessID*/ }
      
      }
      public class Taunts
        {
            uint baseAddress;
            public Taunts() { this.baseAddress = MoveSets.baseAddress; Common.imports = new imports(0xDEADBEEF); /*Provide ProcessID*/ }
            private class Common
            {
                public static imports imports;
            }
            public string[] TauntNames { get { return Enum.GetNames(typeof(enums.eTaunts)); } }
            public enums.eTaunts getCurrentTaunt(uint input)
            {
                byte[] Bits = Common.imports.GetBytes(input, 2);
                Array.Reverse(Bits);
                ushort shorts = BitConverter.ToUInt16(Bits, 0);
                return (enums.eTaunts)shorts;
            }
            public string getTauntName(int input)
            {
                enums.eTaunts result = 0;
                switch (input)
                {
                    case 1: result = Taunt1; break;
                    case 2: result = Taunt2; break;
                    case 3: result = Taunt3; break;
                    case 4: result = Taunt4; break;
                }
                return Enum.GetName(typeof(enums.eTaunts), result);
            }
            enums.eTaunts Taunt1 { get { return getCurrentTaunt(baseAddress); } set { Common.imports.WriteUInt16(baseAddress, (ushort)value); } }
            enums.eTaunts Taunt2 { get { return getCurrentTaunt(baseAddress); } set { Common.imports.WriteUInt16(baseAddress, (ushort)value); } }
            enums.eTaunts Taunt3 { get { return getCurrentTaunt(baseAddress); } set { Common.imports.WriteUInt16(baseAddress, (ushort)value); } }
            enums.eTaunts Taunt4 { get { return getCurrentTaunt(baseAddress); } set { Common.imports.WriteUInt16(baseAddress, (ushort)value); } }
            public void SetTaunt(int slot, enums.eTaunts newTaunt)
            {
                switch (slot)
                {
                    case 1: Taunt1 = newTaunt; break;
                    case 2: Taunt2 = newTaunt; break;
                    case 3: Taunt3 = newTaunt; break;
                    case 4: Taunt4 = newTaunt; break;
                }
            }
            public void SetTaunt(int slot, string input)
            {
                SetTaunt(slot, (enums.eTaunts)(int)Enum.Parse(typeof(enums.eTaunts), input));
            }

        }
    }
    public class Standing { }
    public class Ground { }
    public class Corner { }
    public class Rope { }
    public class Aprion { }
    public class Diving { }
    public class Running { }
    public class TagTeam { }
    public class SpecialMoves { }
}
