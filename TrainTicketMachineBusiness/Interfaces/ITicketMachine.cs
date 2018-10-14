using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainTicketMachineBusiness
{
   public interface ITicketMachine
    {
        List<string> GetAllData(bool type);

        List<string> GetAllDataStartedWithInput(string input, List<string> dataList);

        List<DataResult> GetAllDataObjectStartedWithInput(string input, bool type);

        char GetNextCharacter(int length, string input);
    }
}
