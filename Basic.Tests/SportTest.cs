using Basic.Core.Services;
using System;
using Xunit;

namespace Basic.Tests
{
    public class SportTest
    {
        [Fact]
        public void AddingNumbers()
        {
            //Arrange
            var mathSerive = new SportService("Damian scores");
            mathSerive.AddNumber(12);
            mathSerive.AddNumber(0);
            mathSerive.AddNumber(6);
            //Act
            var actual = mathSerive.GetStatistics();
            //Assert
            Assert.Equal(12, actual.Max);
            Assert.Equal(0, actual.Min);
            Assert.Equal(6, actual.Avg);

        }
    }
}
