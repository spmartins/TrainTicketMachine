using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainTicketMachineBusiness
{
   public interface ITicketMachine
    {
        List<string> GetAllData(string filePath);

        List<string> GetAllDataStartedWithInput(string input, List<string> dataList);

        List<DataResult> GetAllDataObjectStartedWithInput(string input, string filePath);

        char GetNextCharacter(int length, string input);
    }
}
