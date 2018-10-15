using Microsoft.VisualStudio.TestTools.UnitTesting;
using TrainTicketMachineBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Moq;

namespace TrainTicketMachineBusiness.Tests
{
    [TestClass()]
    public class TicketMachineRepositoryTests
    {
        private readonly string  _filepath = Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "Data", "world-cities_csv.csv");

        [TestMethod()]
        public void GetAllDataStartedWithInputTest()
        {
            var repository = new TicketMachineRepository();
            var dataList = repository.GetAllData(_filepath);
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
            var dataList = repository.GetAllData(_filepath);

            string text = "Bengaluru";
            string searchText = "Beng";
            int length = searchText.Length;

            char expectedResult = 'a';
            char result = repository.GetNextCharacter(length, text);

            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod()]
        public void GetNextCharacterTestSameLength()
        {
            var repository = new TicketMachineRepository();
            var dataList = repository.GetAllData(_filepath);

            string text = "Ans";
            string searchText = "Ans";
            int length = searchText.Length;

            char expectedResult = (char)0;
            char result = repository.GetNextCharacter(length, text);

            Assert.AreEqual(expectedResult, result);
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

            List<DataResult> result = repository.GetAllDataObjectStartedWithInput(text, _filepath);
            //CollectionAssert.AreEquivalent(expectedResult, result);
            Assert.AreEqual(expectedResult.FirstOrDefault().NextCharacter, result.FirstOrDefault().NextCharacter);
        }
    }
}