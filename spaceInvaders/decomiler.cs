using System;
using System.IO;
using System.Text;

namespace SpaceInvaderEmulator
{
    public class Decompiler
    {
        public Decompiler(FileStream fileStream)
        {
            this.fs = fileStream;
        }
        private int hexIn;
        private byte[] opcode = new byte[1];
        private int offset = 0;
        private byte[] addr8bit = new byte[1];
        private byte[] addr16bit = new byte[2];

        private FileStream fs;

        public void Decompile()
        {
            while ((hexIn = fs.Read(opcode, offset, opcode.Length)) > 0)
            {
                //Console.WriteLine(fs.Position);
                //Console.WriteLine("{0:X2}", Convert.ToHexString(opcode));

                var instruction = Convert.ToHexString(opcode).ToLower();
                Console.Write($"{(fs.Position - 1).ToString("X4")}  ");
                switch (instruction)
                {
                    case "00":
                        Console.WriteLine("NOP");
                        break;
                    case "01":
                        addr16bit[1] = (byte)fs.ReadByte();
                        addr16bit[0] = (byte)fs.ReadByte();
                        Console.WriteLine($"LXI B, ${Convert.ToHexString(addr16bit)}");
                        break;
                    case "02":
                        Console.WriteLine("STAX B");
                        break;
                    case "03":
                        Console.WriteLine("INX B");
                        break;
                    case "04":
                        Console.WriteLine("INR B");
                        break;
                    case "05":
                        Console.WriteLine("DCR B");
                        break;
                    case "06":
                        addr8bit[0] = (byte)fs.ReadByte();
                        Console.WriteLine($"MVI B, ${Convert.ToHexString(addr8bit)}");
                        break;
                    case "07":
                        Console.WriteLine("RLC");
                        break;
                    case "08":
                        Console.WriteLine("-");
                        break;
                    case "09":
                        Console.WriteLine("DAD B");
                        break;
                    case "0a":
                        Console.WriteLine("LDAX B");
                        break;
                    case "0b":
                        Console.WriteLine("DCX B");
                        break;
                    case "0c":
                        Console.WriteLine("INR C");
                        break;
                    case "0d":
                        Console.WriteLine("DCR C");
                        break;
                    case "0e":
                        addr8bit[0] = (byte)fs.ReadByte();
                        Console.WriteLine($"MVI C,${Convert.ToHexString(addr8bit)}");
                        break;
                    case "0f":
                        Console.WriteLine("RRC");
                        break;
                    case "10":
                        Console.WriteLine("-");
                        break;
                    case "11":
                        addr16bit[1] = (byte)fs.ReadByte();
                        addr16bit[0] = (byte)fs.ReadByte();
                        Console.WriteLine($"LXI D,${Convert.ToHexString(addr16bit)}");
                        break;
                    case "12":
                        Console.WriteLine("STAX D");
                        break;
                    case "13":
                        Console.WriteLine("INX D");
                        break;
                    case "14":
                        Console.WriteLine("INR D");
                        break;
                    case "15":
                        Console.WriteLine("DCR D");
                        break;
                    case "16":
                        addr8bit[0] = (byte)fs.ReadByte();
                        Console.WriteLine($"MVI D, ${Convert.ToHexString(addr8bit)}");
                        break;
                    case "17":
                        Console.WriteLine("RAL");
                        break;
                    case "18":
                        Console.WriteLine("-");
                        break;
                    case "19":
                        Console.WriteLine("DAD D");
                        break;
                    case "1a":
                        Console.WriteLine("LDAX D");
                        break;
                    case "1b":
                        Console.WriteLine("DCX D");
                        break;
                    case "1c":
                        Console.WriteLine("INR E");
                        break;
                    case "1d":
                        Console.WriteLine("DCR E");
                        break;
                    case "1e":
                        addr8bit[0] = (byte)fs.ReadByte();
                        Console.WriteLine($"MVI E,${Convert.ToHexString(addr8bit)}");
                        break;
                    case "1f":
                        Console.WriteLine("RAR");
                        break;
                    case "20":
                        Console.WriteLine("-");
                        break;
                    case "21":
                        addr16bit[1] = (byte)fs.ReadByte();
                        addr16bit[0] = (byte)fs.ReadByte();
                        Console.WriteLine($"LXI H,${Convert.ToHexString(addr16bit)}");
                        break;
                    case "22":
                        addr8bit[0] = (byte)fs.ReadByte();
                        Console.WriteLine($"SHLD ${Convert.ToHexString(addr8bit)}");
                        break;
                    case "23":
                        Console.WriteLine($"INX H");
                        break;
                    case "24":
                        Console.WriteLine($"INR H");
                        break;
                    case "25":
                        Console.WriteLine($"DCR H");
                        break;
                    case "26":
                        addr8bit[0] = (byte)fs.ReadByte();
                        Console.WriteLine($"MVI H,${Convert.ToHexString(addr8bit)}");
                        break;
                    case "27":
                        Console.WriteLine("DAA");
                        break;
                    case "28":
                        Console.WriteLine("-");
                        break;
                    case "29":
                        Console.WriteLine("DAD H");
                        break;
                    case "2a":
                        addr16bit[1] = (byte)fs.ReadByte();
                        addr16bit[0] = (byte)fs.ReadByte();
                        Console.WriteLine($"LHLD ${Convert.ToHexString(addr16bit)}");
                        break;
                    case "2b":
                        Console.WriteLine("DCX H");
                        break;
                    case "2c":
                        Console.WriteLine("INR L");
                        break;
                    case "2d":
                        Console.WriteLine("DCR L");
                        break;
                    case "2e":
                        addr8bit[0] = (byte)fs.ReadByte();
                        Console.WriteLine($"MVI L, ${Convert.ToHexString(addr8bit)}");
                        break;
                    case "2f":
                        Console.WriteLine("CMA");
                        break;
                    case "30":
                        Console.WriteLine("-");
                        break;
                    case "31":
                        addr16bit[1] = (byte)fs.ReadByte();
                        addr16bit[0] = (byte)fs.ReadByte();
                        Console.WriteLine($"LXI SP, ${Convert.ToHexString(addr16bit)}");
                        break;
                    case "32":
                        addr16bit[1] = (byte)fs.ReadByte();
                        addr16bit[0] = (byte)fs.ReadByte();
                        Console.WriteLine($"STA ${Convert.ToHexString(addr16bit)}");
                        break;
                    case "33":
                        Console.WriteLine("INX SP");
                        break;
                    case "34":
                        Console.WriteLine("INR M");
                        break;
                    case "35":
                        Console.WriteLine("DCR M");
                        break;
                    case "36":
                        addr8bit[0] = (byte)fs.ReadByte();
                        Console.WriteLine($"MVI M,${Convert.ToHexString(addr8bit)}");
                        break;
                    case "37":
                        Console.WriteLine("STC");
                        break;
                    case "38":
                        Console.WriteLine("-");
                        break;
                    case "39":
                        Console.WriteLine("DAD SP");
                        break;
                    case "3a":
                        addr16bit[1] = (byte)fs.ReadByte();
                        addr16bit[0] = (byte)fs.ReadByte();
                        Console.WriteLine($"LDA ${Convert.ToHexString(addr16bit)}");

                        break;
                    case "3b":
                        Console.WriteLine("DCX SP");
                        break;
                    case "3c":
                        Console.WriteLine("INR A");
                        break;
                    case "3d":
                        Console.WriteLine("DCR A");
                        break;
                    case "3e":
                        addr8bit[0] = (byte)fs.ReadByte();
                        Console.WriteLine($"MVI A,${Convert.ToHexString(addr8bit)}");

                        break;
                    case "3f":
                        Console.WriteLine("CMC");
                        break;
                    case "40":
                        Console.WriteLine("MOV B,B");
                        break;
                    case "41":
                        Console.WriteLine("MOV B,C");
                        break;
                    case "42":
                        Console.WriteLine("MOV B,D");
                        break;
                    case "43":
                        Console.WriteLine("MOV B,E");
                        break;
                    case "44":
                        Console.WriteLine("MOV B,H");
                        break;
                    case "45":
                        Console.WriteLine("MOV B,L");
                        break;
                    case "46":
                        Console.WriteLine("MOV B,M");
                        break;
                    case "47":
                        Console.WriteLine("MOV B,A");
                        break;
                    case "48":
                        Console.WriteLine("MOV C,B");
                        break;
                    case "49":
                        Console.WriteLine("MOV C,C");
                        break;
                    case "4a":
                        Console.WriteLine("MOV C,D");
                        break;
                    case "4b":
                        Console.WriteLine("MOV C,E");
                        break;
                    case "4c":
                        Console.WriteLine("MOV C,H");
                        break;
                    case "4d":
                        Console.WriteLine("MOV C,L");
                        break;
                    case "4e":
                        Console.WriteLine("MOV C,M");
                        break;
                    case "4f":
                        Console.WriteLine("MOV C,A");
                        break;
                    case "50":
                        Console.WriteLine("MOV D,B");
                        break;
                    case "51":
                        Console.WriteLine("MOV D,C");
                        break;
                    case "52":
                        Console.WriteLine("MOV D,D");
                        break;
                    case "53":
                        Console.WriteLine("MOV D,E");
                        break;
                    case "54":
                        Console.WriteLine("MOV D,H");
                        break;
                    case "55":
                        Console.WriteLine("MOV D,L");
                        break;
                    case "56":
                        Console.WriteLine("MOV D,M");
                        break;
                    case "57":
                        Console.WriteLine("MOV D,A");
                        break;
                    case "58":
                        Console.WriteLine("MOV E,B");
                        break;
                    case "59":
                        Console.WriteLine("MOV E,C");
                        break;
                    case "5a":
                        Console.WriteLine("MOV E,D");
                        break;
                    case "5b":
                        Console.WriteLine("MOV E,E");
                        break;
                    case "5c":
                        Console.WriteLine("MOV E,H");
                        break;
                    case "5d":
                        Console.WriteLine("MOV E,L");
                        break;
                    case "5e":
                        Console.WriteLine("MOV E,M");
                        break;
                    case "5f":
                        Console.WriteLine("MOV E,A");
                        break;
                    case "60":
                        Console.WriteLine("MOV H,B");
                        break;
                    case "61":
                        Console.WriteLine("MOV H,C");
                        break;
                    case "62":
                        Console.WriteLine("MOV H,D");
                        break;
                    case "63":
                        Console.WriteLine("MOV H,E");
                        break;
                    case "64":
                        Console.WriteLine("MOV H,H");
                        break;
                    case "65":
                        Console.WriteLine("MOV H,L");
                        break;
                    case "66":
                        Console.WriteLine("MOV H,M");
                        break;
                    case "67":
                        Console.WriteLine("MOV H,A");
                        break;
                    case "68":
                        Console.WriteLine("MOV L,B");
                        break;
                    case "69":
                        Console.WriteLine("MOV L,C");
                        break;
                    case "6a":
                        Console.WriteLine("MOV L,D");
                        break;
                    case "6b":
                        Console.WriteLine("MOV L,E");
                        break;
                    case "6c":
                        Console.WriteLine("MOV L,H");
                        break;
                    case "6d":
                        Console.WriteLine("MOV L,L");
                        break;
                    case "6e":
                        Console.WriteLine("MOV L,M");
                        break;
                    case "6f":
                        Console.WriteLine("MOV L,A");
                        break;
                    case "70":
                        Console.WriteLine("MOV M,B");
                        break;
                    case "71":
                        Console.WriteLine("MOV M,C");
                        break;
                    case "72":
                        Console.WriteLine("MOV M,D");
                        break;
                    case "73":
                        Console.WriteLine("MOV M,E");
                        break;
                    case "74":
                        Console.WriteLine("MOV M,H");
                        break;
                    case "75":
                        Console.WriteLine("MOV M,L");
                        break;
                    case "76":
                        Console.WriteLine("HLT");
                        break;
                    case "77":
                        Console.WriteLine("MOV M,A");
                        break;
                    case "78":
                        Console.WriteLine("MOV A,B");
                        break;
                    case "79":
                        Console.WriteLine("MOV A,C");
                        break;
                    case "7a":
                        Console.WriteLine("MOV A,D");
                        break;
                    case "7b":
                        Console.WriteLine("MOV A,E");
                        break;
                    case "7c":
                        Console.WriteLine("MOV A,H");
                        break;
                    case "7d":
                        Console.WriteLine("MOV A,L");
                        break;
                    case "7e":
                        Console.WriteLine("MOV A,M");
                        break;
                    case "7f":
                        Console.WriteLine("MOV A,A");
                        break;
                    case "80":
                        Console.WriteLine("ADD B");
                        break;
                    case "81":
                        Console.WriteLine("ADD C");
                        break;
                    case "82":
                        Console.WriteLine("ADD D");
                        break;
                    case "83":
                        Console.WriteLine("ADD E");
                        break;
                    case "84":
                        Console.WriteLine("ADD H");
                        break;
                    case "85":
                        Console.WriteLine("ADD L");
                        break;
                    case "86":
                        Console.WriteLine("ADD M");
                        break;
                    case "87":
                        Console.WriteLine("ADD A");
                        break;
                    case "88":
                        Console.WriteLine("ADC B");
                        break;
                    case "89":
                        Console.WriteLine("ADC C");
                        break;
                    case "8a":
                        Console.WriteLine("ADC D");
                        break;
                    case "8b":
                        Console.WriteLine("ADC E");
                        break;
                    case "8c":
                        Console.WriteLine("ADC H");
                        break;
                    case "8d":
                        Console.WriteLine("ADC L");
                        break;
                    case "8e":
                        Console.WriteLine("ADC M");
                        break;
                    case "8f":
                        Console.WriteLine("ADC A");
                        break;
                    case "90":
                        Console.WriteLine("SUB B");
                        break;
                    case "91":
                        Console.WriteLine("SUB C");
                        break;
                    case "92":
                        Console.WriteLine("SUB D");
                        break;
                    case "93":
                        Console.WriteLine("SUB E");
                        break;
                    case "94":
                        Console.WriteLine("SUB H");
                        break;
                    case "95":
                        Console.WriteLine("SUB L");
                        break;
                    case "96":
                        Console.WriteLine("SUB M");
                        break;
                    case "97":
                        Console.WriteLine("SUB A");
                        break;
                    case "98":
                        Console.WriteLine("SBB B");
                        break;
                    case "99":
                        Console.WriteLine("SBB C");
                        break;
                    case "9a":
                        Console.WriteLine("SBB D");
                        break;
                    case "9b":
                        Console.WriteLine("SBB E");
                        break;
                    case "9c":
                        Console.WriteLine("SBB H");
                        break;
                    case "9d":
                        Console.WriteLine("SBB L");
                        break;
                    case "9e":
                        Console.WriteLine("SBB M");
                        break;
                    case "9f":
                        Console.WriteLine("SBB A");
                        break;
                    case "a0":
                        Console.WriteLine("ANA B");
                        break;
                    case "a1":
                        Console.WriteLine("ANA C");
                        break;
                    case "a2":
                        Console.WriteLine("ANA D");
                        break;
                    case "a3":
                        Console.WriteLine("ANA E");
                        break;
                    case "a4":
                        Console.WriteLine("ANA H");
                        break;
                    case "a5":
                        Console.WriteLine("ANA L");
                        break;
                    case "a6":
                        Console.WriteLine("ANA M");
                        break;
                    case "a7":
                        Console.WriteLine("ANA A");
                        break;
                    case "a8":
                        Console.WriteLine("XRA B");
                        break;
                    case "a9":
                        Console.WriteLine("XRA C");
                        break;
                    case "aa":
                        Console.WriteLine("XRA D");
                        break;
                    case "ab":
                        Console.WriteLine("XRA E");
                        break;
                    case "ac":
                        Console.WriteLine("XRA H");
                        break;
                    case "ad":
                        Console.WriteLine("XRA L");
                        break;
                    case "ae":
                        Console.WriteLine("XRA M");
                        break;
                    case "af":
                        Console.WriteLine("XRA A");
                        break;
                    case "b0":
                        Console.WriteLine("ORA B");
                        break;
                    case "b1":
                        Console.WriteLine("ORA C");
                        break;
                    case "b2":
                        Console.WriteLine("ORA D");
                        break;
                    case "b3":
                        Console.WriteLine("ORA E");
                        break;
                    case "b4":
                        Console.WriteLine("ORA H");
                        break;
                    case "b5":
                        Console.WriteLine("ORA L");
                        break;
                    case "b6":
                        Console.WriteLine("ORA M");
                        break;
                    case "b7":
                        Console.WriteLine("ORA A");
                        break;
                    case "b8":
                        Console.WriteLine("CMP B");
                        break;
                    case "b9":
                        Console.WriteLine("CMP C");
                        break;
                    case "ba":
                        Console.WriteLine("CMP D");
                        break;
                    case "bb":
                        Console.WriteLine("CMP E");
                        break;
                    case "bc":
                        Console.WriteLine("CMP H");
                        break;
                    case "bd":
                        Console.WriteLine("CMP L");
                        break;
                    case "be":
                        Console.WriteLine("CMP M");
                        break;
                    case "bf":
                        Console.WriteLine("CMP A");
                        break;
                    case "c0":
                        Console.WriteLine("RNZ");
                        break;
                    case "c1":
                        Console.WriteLine("POP B");
                        break;
                    case "c2":
                        addr16bit[1] = (byte)fs.ReadByte();
                        addr16bit[0] = (byte)fs.ReadByte();
                        Console.WriteLine($"JNZ ${Convert.ToHexString(addr16bit)}");

                        break;
                    case "c3":
                        addr16bit[1] = (byte)fs.ReadByte();
                        addr16bit[0] = (byte)fs.ReadByte();

                        Console.WriteLine($"JMP ${Convert.ToHexString(addr16bit)}");

                        break;
                    case "c4":
                        addr16bit[1] = (byte)fs.ReadByte();
                        addr16bit[0] = (byte)fs.ReadByte();
                        Console.WriteLine($"CNZ ${Convert.ToHexString(addr16bit)}");

                        break;
                    case "c5":
                        Console.WriteLine("PUSH B");
                        break;
                    case "c6":
                        addr8bit[0] = (byte)fs.ReadByte();
                        Console.WriteLine($"ADI ${Convert.ToHexString(addr8bit)}");

                        break;
                    case "c7":
                        Console.WriteLine("RST 0");
                        break;
                    case "c8":
                        Console.WriteLine("RZ");
                        break;
                    case "c9":
                        Console.WriteLine("RET");
                        break;
                    case "ca":
                        addr16bit[1] = (byte)fs.ReadByte();
                        addr16bit[0] = (byte)fs.ReadByte();
                        Console.WriteLine($"JZ ${Convert.ToHexString(addr16bit)}");

                        break;
                    case "cb":
                        Console.WriteLine("-");
                        break;
                    case "cc":
                        addr16bit[1] = (byte)fs.ReadByte();
                        addr16bit[0] = (byte)fs.ReadByte();
                        Console.WriteLine($"CZ ${Convert.ToHexString(addr16bit)}");

                        break;
                    case "cd":
                        addr16bit[1] = (byte)fs.ReadByte();
                        addr16bit[0] = (byte)fs.ReadByte();
                        Console.WriteLine($"CALL ${Convert.ToHexString(addr16bit)}");

                        break;
                    case "ce":
                        addr8bit[0] = (byte)fs.ReadByte();
                        Console.WriteLine($"ACI ${Convert.ToHexString(addr8bit)}");

                        break;
                    case "cf":
                        Console.WriteLine("RST 1");
                        break;
                    case "d0":
                        Console.WriteLine("RNC");
                        break;
                    case "d1":
                        Console.WriteLine("POP D");
                        break;
                    case "d2":
                        addr16bit[1] = (byte)fs.ReadByte();
                        addr16bit[0] = (byte)fs.ReadByte();
                        Console.WriteLine($"JNC ${Convert.ToHexString(addr16bit)}");

                        break;
                    case "d3":
                        addr8bit[0] = (byte)fs.ReadByte();
                        Console.WriteLine($"OUT ${Convert.ToHexString(addr8bit)}");

                        break;
                    case "d4":
                        addr16bit[1] = (byte)fs.ReadByte();
                        addr16bit[0] = (byte)fs.ReadByte();
                        Console.WriteLine($"CNC ${Convert.ToHexString(addr16bit)}");

                        break;
                    case "d5":
                        Console.WriteLine("PUSH D");
                        break;
                    case "d6":
                        addr8bit[0] = (byte)fs.ReadByte();
                        Console.WriteLine($"SUI ${Convert.ToHexString(addr8bit)}");

                        break;
                    case "d7":
                        Console.WriteLine("RST 2");
                        break;
                    case "d8":
                        Console.WriteLine("RC");
                        break;
                    case "d9":
                        Console.WriteLine("-");
                        break;
                    case "da":
                        addr16bit[1] = (byte)fs.ReadByte();
                        addr16bit[0] = (byte)fs.ReadByte();
                        Console.WriteLine($"JC ${Convert.ToHexString(addr16bit)}");

                        break;
                    case "db":
                        addr8bit[0] = (byte)fs.ReadByte();
                        Console.WriteLine($"IN ${Convert.ToHexString(addr8bit)}");

                        break;
                    case "dc":
                        addr16bit[1] = (byte)fs.ReadByte();
                        addr16bit[0] = (byte)fs.ReadByte();
                        Console.WriteLine($"CC ${Convert.ToHexString(addr16bit)}");

                        break;
                    case "dd":
                        Console.WriteLine("-");
                        break;
                    case "de":
                        addr8bit[0] = (byte)fs.ReadByte();
                        Console.WriteLine($"SBI ${Convert.ToHexString(addr8bit)}");

                        break;
                    case "df":
                        Console.WriteLine("RST 3");
                        break;
                    case "e0":
                        Console.WriteLine("RPO");
                        break;
                    case "e1":
                        Console.WriteLine("POP H");
                        break;
                    case "e2":
                        addr16bit[1] = (byte)fs.ReadByte();
                        addr16bit[0] = (byte)fs.ReadByte();

                        Console.WriteLine($"JPO ${Convert.ToHexString(addr16bit)}");

                        break;
                    case "e3":
                        Console.WriteLine("XTHL");
                        break;
                    case "e4":
                        addr16bit[1] = (byte)fs.ReadByte();
                        addr16bit[0] = (byte)fs.ReadByte();

                        Console.WriteLine($"CPO ${Convert.ToHexString(addr16bit)}");

                        break;
                    case "e5":
                        Console.WriteLine("PUSH H");
                        break;
                    case "e6":
                        addr8bit[0] = (byte)fs.ReadByte();
                        Console.WriteLine($"ANI ${Convert.ToHexString(addr8bit)}");

                        break;
                    case "e7":
                        Console.WriteLine("RST 4");
                        break;
                    case "e8":
                        Console.WriteLine("RPE");
                        break;
                    case "e9":
                        Console.WriteLine("PCHL");
                        break;
                    case "ea":
                        addr16bit[1] = (byte)fs.ReadByte();
                        addr16bit[0] = (byte)fs.ReadByte();

                        Console.WriteLine($"JPE ${Convert.ToHexString(addr16bit)}");

                        break;
                    case "eb":
                        Console.WriteLine("XCHG");
                        break;
                    case "ec":
                        addr16bit[1] = (byte)fs.ReadByte();
                        addr16bit[0] = (byte)fs.ReadByte();

                        Console.WriteLine($"CPE ${Convert.ToHexString(addr16bit)}");

                        break;
                    case "ed":
                        Console.WriteLine("-");
                        break;
                    case "ee":
                        addr8bit[0] = (byte)fs.ReadByte();
                        Console.WriteLine($"XRI ${Convert.ToHexString(addr8bit)}");

                        break;
                    case "ef":
                        Console.WriteLine("RST 5");
                        break;
                    case "f0":
                        Console.WriteLine("RP");
                        break;
                    case "f1":
                        Console.WriteLine("POP PSW");
                        break;
                    case "f2":
                        addr16bit[1] = (byte)fs.ReadByte();
                        addr16bit[0] = (byte)fs.ReadByte();

                        Console.WriteLine($"JP ${Convert.ToHexString(addr16bit)}");

                        break;
                    case "f3":
                        Console.WriteLine("DI");
                        break;
                    case "f4":
                        addr16bit[1] = (byte)fs.ReadByte();
                        addr16bit[0] = (byte)fs.ReadByte();

                        Console.WriteLine($"CP ${Convert.ToHexString(addr16bit)}");

                        break;
                    case "f5":
                        Console.WriteLine("PUSH PSW");
                        break;
                    case "f6":
                        addr8bit[0] = (byte)fs.ReadByte();
                        Console.WriteLine($"ORI ${Convert.ToHexString(addr8bit)}");

                        break;
                    case "f7":
                        Console.WriteLine("RST 6");
                        break;
                    case "f8":
                        Console.WriteLine("RM");
                        break;
                    case "f9":
                        Console.WriteLine("SPHL");
                        break;
                    case "fa":
                        addr16bit[1] = (byte)fs.ReadByte();
                        addr16bit[0] = (byte)fs.ReadByte();

                        Console.WriteLine($"JM ${Convert.ToHexString(addr16bit)}");

                        break;
                    case "fb":
                        Console.WriteLine("EI");
                        break;
                    case "fc":
                        addr16bit[1] = (byte)fs.ReadByte();
                        addr16bit[0] = (byte)fs.ReadByte();

                        Console.WriteLine($"CM ${Convert.ToHexString(addr16bit)}");

                        break;
                    case "fd":
                        Console.WriteLine("-");
                        break;
                    case "fe":
                        addr8bit[0] = (byte)fs.ReadByte();
                        Console.WriteLine($"CPI ${Convert.ToHexString(addr8bit)}");

                        break;
                    case "ff":
                        Console.WriteLine("RST 7");
                        break;
                    default:
                        break;
                }
            }

        }

    }
}