using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SoccerFeed2; 

namespace SoccerFeedTest
{
    //Verifica que los objetos sean creados e inicializados correctamente. 
    [TestClass]
    public class InitializationTest
    {
        [TestMethod]
        public void AnnotationTest()
        {
            DateTime time = new DateTime();
            Player testPlayer = new Player("Test", "1", "GK", "Test Team", 1);
            Annotation testAnnotation = new Annotation(time, testPlayer, 0, 1); 
            Assert.AreEqual("[" + time + "] Test scored a Goal", testAnnotation.ToString()); 
        }

        [TestMethod]
        public void TeamTest()
        {
            Team testTeam = new Team("Barcelona", "Test stadium");
            Assert.AreEqual(11, testTeam.InGamePlayers.Count); 
        }
    }
}
