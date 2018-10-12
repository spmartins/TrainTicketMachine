using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainTicketMachineBusiness
{
    interface ITicketMachine
    {
        List<string> GetAllData(bool type);

        List<string> GetAllDataStartedWithInput(string input, List<string> dataList);

        char GetNextCharacter(string input, List<string> dataList);
    }
}
