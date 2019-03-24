using System;
using System.IO;
using System.Collections.Generic;
using System.Text;

namespace ADS.Week4
{
    public class Task5
    {
        public static void Main(string[] args)
        {
            using (StreamReader streamReader = new StreamReader("input.txt"))
            using (StreamWriter streamWriter = new StreamWriter("output.txt", false, Encoding.ASCII))
            {
                Quack quack = new Quack(streamReader, streamWriter);
                quack.Run();
            }
        }
    }
    public class Quack
    {
        private Dictionary<string, int> labels;
        private Queue<ushort> memory;
        private List<string> code;
        private ushort[] registers;
        private int cursor;

        private Dictionary<char, Action<string>> commands;

        private StreamWriter streamWriter;
        private StreamReader streamReader;

        public Quack(StreamReader streamReader, StreamWriter streamWriter)
        {
            this.streamReader = streamReader;
            this.streamWriter = streamWriter;

            labels = new Dictionary<string, int>();
            memory = new Queue<ushort>();
            code = new List<string>();
            registers = new ushort['z' - 'a' + 1];
            commands = new Dictionary<char, Action<string>> {
                ['+'] = Sum,
                ['-'] = Substract,
                ['*'] = Multiply,
                ['/'] = Divide,
                ['%'] = Mod,
                ['>'] = SetRegister,
                ['<'] = GetRegister,
                ['P'] = WriteNumber,
                ['C'] = WriteChar,
                ['J'] = Jump,
                ['Z'] = JumpIfZero,
                ['E'] = JumpIfEquals,
                ['G'] = JumpIfGreater,
                ['Q'] = Quit
            };
            cursor = 0;
        }

        public void Run()
        {
            ReadCode();
            while (cursor < code.Count)
            {
                if (commands.ContainsKey(code[cursor][0]))
                    commands[code[cursor][0]](code[cursor]);
                else
                    Put(code[cursor]);
                cursor++;
            }
        }
        private void ReadCode()
        {
            while (!streamReader.EndOfStream)
            {
                string line = streamReader.ReadLine();
                if (':' == line[0])
                    labels.Add(line.Substring(1), code.Count);
                else
                    code.Add(line);
            }
        }
        
        private void Sum(string command)
        {
            ushort a = memory.Dequeue();
            ushort b = memory.Dequeue();
            memory.Enqueue((ushort)(a + b));
        }
        private void Substract(string command)
        {
            ushort a = memory.Dequeue();
            ushort b = memory.Dequeue();
            memory.Enqueue((ushort)(a - b));
        }
        private void Multiply(string command)
        {
            ushort a = memory.Dequeue();
            ushort b = memory.Dequeue();
            memory.Enqueue((ushort)(a * b));
        }
        private void Divide(string command)
        {
            ushort a = memory.Dequeue();
            ushort b = memory.Dequeue();
            memory.Enqueue((ushort)(a / b));
        }
        private void Mod(string command)
        {
            ushort a = memory.Dequeue();
            ushort b = memory.Dequeue();
            memory.Enqueue((ushort)(a % b));
        }

        private void SetRegister(string command)
        {
            registers[command[1] - 'a'] = memory.Dequeue();
        }
        private void GetRegister(string command)
        {
            memory.Enqueue(registers[command[1] - 'a']);
        }
        private void WriteNumber(string command)
        {
            if (command.Length == 1)
                streamWriter.WriteLine(memory.Dequeue());
            else
                streamWriter.WriteLine(registers[command[1] - 'a']);
        }
        private void WriteChar(string command)
        {
            if (command.Length == 1)
                streamWriter.Write((char)(memory.Dequeue() % 256));
            else
                streamWriter.Write((char)(registers[command[1] - 'a'] % 256));
        }
        private void Jump(string command)
        {
            cursor = labels[command.Substring(1)] - 1;
        }
        private void JumpIfZero(string command)
        {
            if (registers[command[1] - 'a'] == 0)
                cursor = labels[command.Substring(2)] - 1;
        }
        private void JumpIfEquals(string command)
        {
            if (registers[command[1] - 'a'] == registers[command[2] - 'a'])
                cursor = labels[command.Substring(3)] - 1;
        }
        private void JumpIfGreater(string command)
        {
            if (registers[command[1] - 'a'] > registers[command[2] - 'a'])
                cursor = labels[command.Substring(3)] - 1;
        }
        private void Quit(string command)
        {
            cursor = code.Count;
        }
        private void Put(string command)
        {
            memory.Enqueue(ushort.Parse(command));
        }
    }
}