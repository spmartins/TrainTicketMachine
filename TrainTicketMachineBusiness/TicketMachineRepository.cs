using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace TrainTicketMachineBusiness
{
    public class TicketMachineRepository : ITicketMachine
    {
        public List<string> GetAllData()
        {
            var filePath = Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "Data", "world-cities_csv.csv");
            List<string> dataList = new List<string>();
            using (var reader = new StreamReader(filePath))
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    dataList.Add(line);
                }
            }
            return dataList;
        }

        public List<string> GetAllDataStartedWithInput(string input)
        {
            throw new NotImplementedException();
        }

        public char GetNextCharacter(string input, List<string> dataList)
        {
            throw new NotImplementedException();
        }
    }
}
