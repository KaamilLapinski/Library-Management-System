namespace Library_Management_System.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            //Arrange
            int a = 5;
            int b = 3;
            //Act
            int result = a + b;
            //Assert
            Assert.Equal(8, result);
        }
    }
}