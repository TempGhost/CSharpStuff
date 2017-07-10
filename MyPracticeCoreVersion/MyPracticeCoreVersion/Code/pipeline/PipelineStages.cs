using System;
using System.Collections.Concurrent;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MyPracticeCoreVersion.Code.pipeline
{
    public class PipelineStages
    {
        public static Task ReadFilenamesAsync(string path, BlockingCollection<string> output)
        {
            return Task.Run(() =>
            {
                foreach (string  itemfile in Directory.EnumerateDirectories(path,"*.cs",SearchOption.AllDirectories))
                { 
                    output.Add(itemfile);
                    ConsoleHelper.WriteLine("stage 1 add{0} file", itemfile);
                }
                output.CompleteAdding();
            });
        }

        public static async  Task LoadContentAsync(BlockingCollection<string> input, BlockingCollection<string> output)
        {
            foreach (var filename in input.GetConsumingEnumerable())
            {
                using ( FileStream stream = File.OpenRead(filename))
                {
                     var reader = new StreamReader(stream);
                    string line = null;
                    while ((line = await reader.ReadLineAsync())!=null)
                    {
                        output.Add(line);
                        ConsoleHelper.WriteLine(string.Format("stage 2 added {0}",line));
                    }
                }
            }
            output.CompleteAdding();
        }

        public static Task ProcessContentAsync(BlockingCollection<string> input,
            ConcurrentDictionary<string, int> output)
        {
            return Task.Run(() =>
            {
                foreach (var line in input.GetConsumingEnumerable())
                {
                    string[] words = line.Split(' ', ';', '\t', '{', '}', '(', ')', ':', ',', '"');
                    foreach (var word in words.Where(w => !string.IsNullOrEmpty(w)))
                    {
                         output.AddOrIncrementValue(word);
                         ConsoleHelper.WriteLine(String.Format("stage 3 add word {0}",word));
                    }
                }
            });
        }
    }
}