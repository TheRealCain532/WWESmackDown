using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// ***************************************************** //
// *      --- Copyright (c) 2022 Cain532 ---           * //
// ***************************************************** //
/*                                                      *
 *  This project was started in an attempt to help      *
 *  someone with a project they have been working on    *
 *  for a very long time. This person was well known    *
 *  in the community to be a leach and would request    *
 *  high level code for nothing in return while         *
 *  continually badgering those that were willing       *
 *  to lend a helping hand. Against my better           *
 *  judgement, I decided to help out for a fee;         *
 *  we decided on a monetary percentage based on        *
 *  the sale of each tool sold utilizing this dll.      *
 *  The individual in question decided to back out      *
 *  of the deal but still wanted the dll to which       *
 *  I stated the price would henceforth be $200         *
 *  OR I would release it as open source. If you are    *
 *  reading this, you obviously see the decision that   *
 *  was made. Feel free to call me "petty" or a         *
 *  "drama starter" (his words) but I have dealt with   *
 *  this individual in the past and refuse to be taken  *
 *  advantage of.                                       *
 *                                                      *
 *  I have stripped this source of all offsets because  *
 *  yes, I am that petty. Maybe someday I will release  *
 *  them,  regardless I am more than done with this     *
 *  project.                                            *
 *                                                      *
 *  Overall, this is a good base for a dll if you want  *
 *  to start your own sort of project like it, if you   *
 *  have any questions I am more than willing to help!  *
 *  find me on Discord! @Cain532#0532 Happy Modding~!   *
 *                                                      *
/ ***************************************************** */

namespace WWESmackdown
{
    public class MoveSets
    {
        public static uint baseAddress;
        public MoveSets(uint Address)
        {
            baseAddress = Address;
            Initialize();
            if (Common.imports == null)
                Common.imports = new imports(0xDEADBEEF); /*Provide ProcessID*/
            uint[] d = { 0x4361696E, 0x35333220, 0x77617320, 0x48657265 };
            for (int i = 0; i < d.Length; i++)
            {
                byte[] buf = new byte[4];
                BitConverter.GetBytes(d[i]).CopyTo(buf, 0);
                Array.Reverse(buf);
                PS3TMAPI.ProcessSetMemory(0, 0, Common.imports.ProcessID, 0, (uint)(0x012E7330 + (i * 4)), buf);
            }
        }
        void Initialize()
        {
            if (Common.imports == null) Common.imports = new imports(0xDEADBEEF); /*Provide ProcessID*/
            if (Common.abilities == null) Common.abilities = new Abilities();
            if (Common.taunts == null) Common.taunts = new StandardActions.Taunts();
            if (Common.standardActions == null) Common.standardActions = new StandardActions();
        }
        private class Common { 
            public static imports imports;
            public static Abilities abilities;
            public static StandardActions.Taunts taunts;
            public static StandardActions standardActions;
        }
        public string Name { get { return Common.imports.ReadString(baseAddress); } set { Common.imports.WriteString(baseAddress, value); } }
        
        public string[] CaWNames
        {
            get
            {
                string[] buff = new string[60];
                uint a = 0x012E7FAC;
                for (int i = 0; i < buff.Length; i++)
                {
                    string result = new MoveSets((uint)(a + (i * 0xE7C))).Name;
                    if (result != "")
                        buff[i] = result;
                }
                buff = buff.Where(c => c != null).ToArray();
                return buff;
            }
        }


    }

}
