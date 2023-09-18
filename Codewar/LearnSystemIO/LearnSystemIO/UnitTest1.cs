namespace LearnSystemIO
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TryStreamReadMethod()
        {
            //arrange: create a 100 loop to build MemoryStream 0x00,0x01,0x02,0x03,....
            byte[] byteArr = new byte[100];
            for (byte i = 0; i < 100; i++)
            {
                byteArr[i] = (i);
            }
            Stream s = new MemoryStream(byteArr);
            //act: let's read first 5 bytes by using Stream.Read Method
            // Stream.Read signature (byte[] bufferToPopulate,int startingPosition, int numberOfBytes)
            byte[] bufferToPopulate = new byte[5];// create a 5 bytes array as the destination to stored bytes read

            int bytesRead = s.Read(bufferToPopulate, 0, 5); //call Stream.Read to read the first 5 bytes ** it will advance the pointer from 0 to 5

            Assert.AreEqual(bufferToPopulate[0], 0x00);
            Assert.AreEqual(bufferToPopulate[1], 0x01);
            Assert.AreEqual(bufferToPopulate[2], 0x02);
            Assert.AreEqual(bufferToPopulate[3], 0x03);
            Assert.AreEqual(bufferToPopulate[4], 0x04);
            Assert.AreEqual(bytesRead, 5);
        }
        [TestMethod]
        public void ConfirmStreamReadReturnValueIsBoundByTheNumberOfByteActuallyRead()
        {
            //arrange: create a 100 loop to build MemoryStream 0x00,0x01,0x02,0x03,....
            byte[] byteArr = new byte[100];
            for (byte i = 0; i < 100; i++)
            {
                byteArr[i] = (i);
            }
            Stream s = new MemoryStream(byteArr);
            //act: let's read first 5 bytes by using Stream.Read Method
            // Stream.Read signature (byte[] bufferToPopulate,int startingPosition, int numberOfBytes)
            byte[] bufferToPopulate = new byte[120];// create a 5 bytes array as the destination to stored bytes read

            int bytesRead = s.Read(bufferToPopulate, 0, 120); //call Stream.Read to read the first 5 bytes ** it will advance the pointer from 0 to 5

            Assert.AreEqual(bufferToPopulate[0], 0x00);
            Assert.AreEqual(bufferToPopulate[1], 0x01);
            Assert.AreEqual(bufferToPopulate[2], 0x02);
            Assert.AreEqual(bufferToPopulate[3], 0x03);
            Assert.AreEqual(bufferToPopulate[4], 0x04);
            Assert.AreEqual(bytesRead, 100);
        }

        [TestMethod]
        public void CreateANewMemoryStreamFromBytes()
        {
            //arrange: create a 100 loop to build MemoryStream 0x00,0x01,0x02,0x03,....
            byte[] byteArr = new byte[100];
            for (byte i = 0; i < 100; i++)
            {
                byteArr[i] = (i);
            }
            Stream s = new MemoryStream();//the Stream s is empty
            //Act write to Stream s using data in byteArr
            s.Write(byteArr,0,100);
            s.Position = 0;//reset the stream to the beginning of the stream
            //the position of stream is at 100 because we just Wrote 100 bytes
            Assert.IsTrue(s.CanWrite);
            Assert.IsTrue(s.CanSeek);
            Assert.IsTrue(s.CanRead);
            Assert.AreEqual(100,s.Length);
            Assert.AreEqual(0, s.Position);
           
            Assert.AreEqual(0, s.ReadByte());
            Assert.AreEqual(1, s.Position);
            Assert.AreEqual(1, s.ReadByte());
            Assert.AreEqual(10, s.Seek(10,0));
            Assert.AreEqual(10, s.ReadByte());
        }
        [TestMethod]
        public void CreateANewFileStreamFromBytes()
        {
            //arrange: create a 100 loop to build MemoryStream 0x00,0x01,0x02,0x03,....
            byte[] byteArr = new byte[100];
            for (byte i = 0; i < 100; i++)
            {
                byteArr[i] = (i);
            }
            Stream s = new FileStream("out.bin",FileMode.OpenOrCreate);//the Stream s is empty
            //Act write to Stream s using data in byteArr
            s.Write(byteArr, 0, 100);
            s.Position = 0;//reset the stream to the beginning of the stream
            //the position of stream is at 100 because we just Wrote 100 bytes
            Assert.IsTrue(s.CanWrite);
            Assert.IsTrue(s.CanSeek);
            Assert.IsTrue(s.CanRead);
            Assert.AreEqual(100, s.Length);
            Assert.AreEqual(0, s.Position);

            Assert.AreEqual(0, s.ReadByte());
            Assert.AreEqual(1, s.Position);
            Assert.AreEqual(1, s.ReadByte());
            Assert.AreEqual(10, s.Seek(10, 0));
            Assert.AreEqual(10, s.ReadByte());
            s.Flush();
            s.Close();
        }
        [TestMethod]
        public void WriteThenReadPrimitiveDataWithBinaryReaderWriter()
        {
            //arrange: 
            // 1 create a file Stream to store data at binary.bin
            // 2 construct BinaryWriter with above stream
            //act: write char,string, decimal, int64,int32 and write a double
            //dont forget to flush and close the file
            char a= 'a';
            string b = "Hello";
            decimal c = decimal.MaxValue;
            Int64 d = Int64.MaxValue;
            Int32 e = Int32.MaxValue;
            double f = Double.MaxValue;

            Stream s = new FileStream("binary.bin",FileMode.OpenOrCreate);//same as other tests,
            // we use Stream s to point to a FileStream
            BinaryWriter bw = new BinaryWriter(s);//
            bw.Write(a); 
            bw.Write(b);
            bw.Write(c);
            bw.Write(d);
            bw.Write(e);
            bw.Write(f);
            bw.Flush();
            
            //Assert
            int inputDataByteCount = 43;
            var testFile = new FileInfo("binary.bin");
            Assert.AreEqual(inputDataByteCount, testFile.Length);
            //Stream s2 = new FileStream("binary.bin", FileMode.Open);//same as other tests,
            s.Position= 0;
            BinaryReader br = new BinaryReader(s);//use the convenient methods from BinaryReader to get the original data back

            Assert.AreEqual(a, br.ReadChar());
            Assert.AreEqual(b, br.ReadString());
            Assert.AreEqual(c, br.ReadDecimal());
            Assert.AreEqual(d, br.ReadInt64());
            Assert.AreEqual(e, br.ReadInt32());
            Assert.AreEqual(f, br.ReadDouble());
            br.Close();

        }

        [TestMethod]
        public void CopyFileTest()
        {
            string srcFile = @"C:\test\a.png";
            string destFile = @"C:\test\copy-a.png";

            var br = new BinaryReader(new FileStream(srcFile, FileMode.Open));
            var bw = new BinaryWriter(new FileStream(destFile, FileMode.OpenOrCreate));
            
            bw.Write(br.ReadBytes((int)br.BaseStream.Length));
            bw.Flush();
            bw.Close();
            br.Close();

            var testSource = new BinaryReader(new FileStream(srcFile, FileMode.Open));
            var testDest = new BinaryReader(new FileStream(destFile, FileMode.Open));

            CollectionAssert.AreEqual(
                testSource.ReadBytes((int)testSource.BaseStream.Length)
                ,testDest.ReadBytes((int)testDest.BaseStream.Length));

        }


        [TestMethod]
        public void TestParsingStringToWinnerInstance()
        {
            string input = @"1, 1928, 44, ""Emil Jannings"", ""The Last Command, The Way of All Flesh""";
            Winner w = new Winner(input);
            Assert.AreEqual(1, w.Index);
            Assert.AreEqual(1928, w.Year);
            Assert.AreEqual(44, w.Age);
            Assert.AreEqual("Emil Jannings", w.Name);
            Assert.AreEqual("The Last Command, The Way of All Flesh", w.Movie);
        }
        [TestMethod]
        public void CreateAListOfWinnerFromCsvFile()
        {
            List<Winner> winners = new List<Winner>();

            using (StreamReader sr = new StreamReader(@"c:\test\oscar_age_male.csv"))
            {
                string line;
                // Read and display lines from the file until the end of
                // the file is reached.
                sr.ReadLine();//skip the first line, which contains the column name
                while ((line = sr.ReadLine()) != null)
                {
                    if (line.Length == 0) break;
                    winners.Add(new Winner(line));
                }
            }

            Assert.AreEqual(89, winners.Count);
            Assert.AreEqual(76, winners.Max(w=>w.Age));
            Assert.AreEqual(29, winners.Min(w=>w.Age));
            Assert.AreEqual(1928, winners.Min(w => w.Year));
            var multiYearWinner=
                winners.GroupBy(winner => winner.Name) //create group of record based on Actors Name
                .Select(g => new { Actor = g.Key, Count = g.Count() })// return a new anon class with 2 properties:Actor, and Count
                .Where (g=> g.Count>1)//only the actors who won more than once
                .OrderByDescending(g=>g.Count)
                .ToList();
                ;
            Assert.AreEqual(9, multiYearWinner.Count);
            Assert.AreEqual("Daniel Day-Lewis", multiYearWinner[0].Actor);

            var sw = new StreamWriter(@"c:\test\top-oscar-actors.csv");
            sw.WriteLine($"{"Actor",20}{"Number Of Award",20}");
            foreach (var item in multiYearWinner)
            {
                sw.WriteLine($"{item.Actor,20}{item.Count,20}");
            }
            sw.Close();
        }
    }
}
