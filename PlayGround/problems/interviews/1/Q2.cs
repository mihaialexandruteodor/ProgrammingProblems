using System.Text;
using System.Text.RegularExpressions;

public class Q2 : IBaseSolution
{

    public void solve()
    {
        string filename = @"" + Directory.GetCurrentDirectory() +"\\hosts.txt";
        LoggerHandler(filename);
    }


    public void LoggerHandler(string filename)
    {
        string outfile = @"" + Directory.GetCurrentDirectory() + "\\out_hosts.txt";
        var lines = File.ReadAllLines(filename);
        Dictionary<string, int> hostFreq = new Dictionary<string, int>();

        foreach (var line in lines)
        {
            var parts = line.Split('"').Select((element, index) => index % 2 == 0 ? element.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries) 
                : new string[] { element })
                .SelectMany( element => element)
                .ToList();

            if(!hostFreq.ContainsKey(parts[0]) )
            {
                hostFreq.Add(parts[0], 0);
            }
            hostFreq[parts[0]]++;
        }

        using(StreamWriter sw = new StreamWriter(outfile))
        {
            foreach (KeyValuePair<string, int> host in hostFreq)
            {
                string line = host.Key + " " + host.Value;
                sw.WriteLine(line);
            }
        }


    }

}