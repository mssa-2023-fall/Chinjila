namespace LearnImmutableTest
{
    [TestClass]
    public class SampleRecordTest
    {
        
        SampleRecord record1=null;
        [TestInitialize]
        public void TestSetup() {
            record1 = new SampleRecord(ParamString: "Test", ParamInt: 1, ParamDate: new DateTime(2023, 9, 5));
        }

        [TestMethod]
        public void TestRecordTypeEqualityWithPositionParameters()
        {
            //arrange
            SampleRecord record2 = new SampleRecord(ParamString: "Test", ParamInt: 1, ParamDate: new DateTime(2023, 9, 5));

            //assert
            Assert.AreEqual(record1, record2);
            Assert.AreNotSame(record1, record2);
        }
        [TestMethod]
        public void TestRecordTypeInEqualityWithPositionParameters()
        {
            //arrange
            SampleRecord record2 = new SampleRecord(ParamString: "Test", ParamInt: 2, ParamDate: new DateTime(2023, 9, 5));

            //assert
            Assert.AreNotEqual(record1, record2);
            Assert.AreNotSame(record1, record2);
        }
        [TestMethod]
        public void TestRecordTypeSamenessWithPositionParameters()
        {
            //arrange
            SampleRecord record2 = record1;

            //assert
            Assert.AreEqual(record1, record2);
            Assert.AreSame(record1, record2);
        }

        [TestMethod]
        public void TestRecordTypeAutoImplementedProperties()
        {
            //Arrange

            //Assert
            Assert.AreEqual("Test", record1.ParamString);
            Assert.AreEqual(1, record1.ParamInt);
            Assert.AreEqual(new DateTime(2023, 9, 5), record1.ParamDate);

        }

        [TestMethod]
        public void TestRecordTypeCanHaveMutableProperties()
        {
            //Arrange
            string expected = "NewString";
            record1.MutableProperty = "InitialString";
            //Act
            record1.MutableProperty = expected;
            //Assert
            Assert.AreEqual(record1.MutableProperty, expected);
        }

        [TestMethod]
        public void TestRecordTypeHaveDestructMethodWithOutParam()
        {
            //Arrange

            string outString = String.Empty;
            int outInt = 0;
            DateTime outDateTime = new DateTime();

            //Act
            record1.Deconstruct(out outString, out outInt, out outDateTime);

            //Assert
            Assert.AreEqual(outString, "Test");
            Assert.AreEqual(outInt, 1);
            Assert.AreEqual(outDateTime, new DateTime(2023, 9, 5));
        }
        [TestMethod]
        public void TestRecordTypeNonDestructiveMutation_with_Syntax()
        {
            //arrange
            
            //act
            SampleRecord record2 = record1 with { ParamInt=2 }; //this is the operation under testing, nondestructive mutation
            //record1.ParamInt = 5;// this is not allowed per compiler
            //Asserts
            Assert.AreNotEqual(record1, record2); // there are 2 different objects - equality comparison
            Assert.AreNotSame(record1, record2); // record2 points to differnt instance than record1 - reference comparison
            Assert.AreEqual(record2.ParamInt,2); // record2 has updated ParamInt
            Assert.AreEqual(record1.ParamInt,1); // record1 is immutable
            Assert.AreEqual(record2.ParamString, "Test"); //the record2 has the same properties as record1 if the property has not been modified
        }
    }
}