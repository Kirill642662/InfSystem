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
        static void Main(string[] args)
        {
            var graph = new Dictionary<string, List<string>>();
            string[] separator = { "--|>", "0->" };

            foreach (var line in File.ReadAllLines("C:\\Users\\Win10\\Desktop\\InfSystem\\Practica1\\GraphSolution\\Graph.txt"))
            {
                string[] parts = line.Split(separator, StringSplitOptions.None);

                string from = parts[0].Trim();
                string to = parts[1].Trim();

                if (!graph.ContainsKey(from))
                    graph[from] = new List<string>();
                if (!graph.ContainsKey(to))
                    graph[to] = new List<string>();

                graph[from].Add(to);
            }
            foreach (var kv in graph)
                Console.WriteLine($"{kv.Key}, [{string.Join(", ", kv.Value)}]");
        }
    }
}
