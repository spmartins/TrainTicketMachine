using Microsoft.VisualStudio.TestTools.UnitTesting;
using TrainTicketMachineBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainTicketMachineBusiness.Tests
{
    [TestClass()]
    public class TicketMachineRepositoryTests
    {

        [TestMethod()]
        public void GetAllDataStartedWithInputTest()
        {
            var repository = new TicketMachineRepository();
            var dataList = repository.GetAllData(true);
            List<string> expectedData = new List<string>
            {
                "Benguela","Bengbu","Bengkulu","Bengaluru", "Benghazi"
            };
            List<string> citiesList = repository.GetAllDataStartedWithInput("Beng", dataList);

            CollectionAssert.AreEqual(expectedData, citiesList);
        }

        [TestMethod()]
        public void GetNextCharacterTest()
        {
            var repository = new TicketMachineRepository();
            var dataList = repository.GetAllData(true);

            string text = "Bengaluru";
            int length = text.Length;
            char testResult = 'a';
            char result = repository.GetNextCharacter(length, text);

            Assert.AreEqual(testResult, result);
        }

        [TestMethod()]
        public void GetAllDataObjectStartedWithInputTest()
        {
            var repository = new TicketMachineRepository();

            string text = "Beng";
            var expectedResult = new List<DataResult>
            {
                new DataResult(){ Name = "Benguela", NextCharacter = 'u'},
                new DataResult(){ Name = "Bengbu", NextCharacter = 'b'},
                new DataResult(){ Name = "Bengkulu", NextCharacter = 'k'},
                new DataResult(){ Name = "Bengaluru", NextCharacter = 'a'},
                new DataResult(){ Name = "Benghazi", NextCharacter = 'h'}

            };

            List<DataResult> result = repository.GetAllDataObjectStartedWithInput(text, true);
            //CollectionAssert.AreEquivalent(expectedResult, result);
            Assert.AreEqual(expectedResult.FirstOrDefault().NextCharacter, result.FirstOrDefault().NextCharacter);
        }
    }
}