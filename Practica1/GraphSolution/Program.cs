using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace GraphSolution
{
    internal class Program
    {
        public class Sink
        {
            public List<string> Inheritance { get; set; } = new List<string>();
            public List<string> Aggregate { get; set; } = new List<string>();
        }

        static void Main(string[] args)
        {
            var graph = new Dictionary<string, Sink>();

            foreach (var line in File.ReadAllLines("C:\\Users\\Win10\\Desktop\\InfSystem\\Practica1\\GraphSolution\\Graph.txt"))
            {
                string from, to;
                bool isInheritance;

                if (line.Contains("--|>"))
                {
                    var parts = line.Split(new[] { "--|>" }, StringSplitOptions.None);
                    from = parts[0].Trim();
                    to = parts[1].Trim();
                    isInheritance = true;
                }
                else
                {
                    var parts = line.Split(new[] { "0->" }, StringSplitOptions.None);
                    from = parts[0].Trim();
                    to = parts[1].Trim();
                    isInheritance = false;
                }

                if (!graph.ContainsKey(from)) graph[from] = new Sink();
                if (!graph.ContainsKey(to)) graph[to] = new Sink();

                if (isInheritance)
                    graph[from].Inheritance.Add(to);
                else
                    graph[from].Aggregate.Add(to);
            }

            foreach (var kv in graph)
                Console.WriteLine($"{kv.Key}: [{string.Join(", ", kv.Value.Inheritance)}] [{string.Join(", ", kv.Value.Aggregate)}]");
        }
    }
}
