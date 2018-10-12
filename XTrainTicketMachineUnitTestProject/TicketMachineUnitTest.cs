using System;
using System.Collections.Generic;
using TrainTicketMachineBusiness;
using Xunit;
using Xunit.Extensions;

namespace XTrainTicketMachineUnitTestProject
{
    public class TicketMachineUnitTest
    {
        //[Fact]
        //public void PassingTest()
        //{
        //    Assert.Equal(4, Add(2, 2));
        //}

        //[Fact]
        //public void FailingTest()
        //{
        //    Assert.Equal(5, Add(2, 2));
        //}

        //int Add(int x, int y)
        //{
        //    return x + y;
        //}

        [Theory, MemberData(nameof(CitiesData))]  
        public void GetCityName(CityResult cityResult)
        {
            //Villa Ocampo, Villa Lugano, Villaguay,Villa Gesel, Villa Regina, Vila Paula de Sarmiento, Villa Nueva...
            var repository = new TicketMachineRepository();
            var dataList = repository.GetAllData(true);
            List<string> CitiesList = repository.GetAllDataStartedWithInput(cityResult.Input, dataList);

            Assert.Equal(cityResult.ResultList, CitiesList);
        }


        public static IEnumerable<object[]> CitiesData()
        {
            yield return new object[]
            {
                    new CityResult {Input ="Benguela", ResultList = { "Bengbu", "Bengaluru", "Bengazi" }}
            };
        }

        public class CityResult
        {
            public string Input { get; set; }
            public List<string> ResultList { get; set; }
        }

    }
}
