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
        public List<string> GetAllData(string filePath)
        {
            try
            {  
                List<string> dataList = new List<string>();
                using (var reader = new StreamReader(filePath))
                {
                    while (!reader.EndOfStream)
                    {
                        var line = reader.ReadLine();
                        dataList.Add(line.TrimEnd(','));
                    }
                }
                return dataList;
            }
            catch (Exception e)
            {

                throw;
            }
            
        }

        public List<string> GetAllDataStartedWithInput(string input, List<string> dataList)
        {
            try
            {
                return dataList.Where(x => x.StartsWith(input)).ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<DataResult> GetAllDataObjectStartedWithInput(string input, string filePath)
        {
            try
            {
                int inputLength = input.Length;
                List<string> inputResult = GetAllData(filePath).Where(x => x.StartsWith(input)).ToList();

                var result = (from i in inputResult
                              select new DataResult
                              {
                                  Name = i,
                                  NextCharacter = GetNextCharacter(inputLength, i)
                              }
                              ).ToList();

                return result;
            }
            catch (Exception)
            {

                throw;
            }
           
        }

        public char GetNextCharacter(int length, string input)
        {
            if (!string.IsNullOrEmpty(input))
            {
                return (char)input[length];
            }

            return (char)0;
        }
    }
}
