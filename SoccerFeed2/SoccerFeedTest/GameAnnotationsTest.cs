using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SoccerFeed2;

namespace SoccerFeedTest
{
    [TestClass]
    public class GameAnnotationsTest
    {
        static Team testTeamA = new Team("Test Team A", "Test Stadium");
        static Team testTeamB = new Team("Test Team B", "Test Stadium");
        static DateTime time = new DateTime();
        Game game = new Game(0, testTeamA, testTeamB);

        [TestMethod]
        public void AddAnnotationTest()
        {
            //Testing the annotation is added to the Game's list.
            Player testPlayerA = new Player("Test Player", "1", "GK", "Test Team A", 0);
            Annotation testAnnotation = new Annotation(time, testPlayerA, 0, 0);
            game.addAnnotation(testAnnotation);
            Assert.AreEqual(testAnnotation, game.Annotations[game.Annotations.Count - 1]); 
        }

        [TestMethod]
        public void GoalTest()
        {
            //Testing the Score is increased with each goal scored. 
            Player testPlayerA = new Player("Test Player", "1", "GK", "Test Team A", 0);
            Annotation testAnnotation1 = new Annotation(time, testPlayerA, 0, 0);
            game.addAnnotation(testAnnotation1);
            Assert.AreNotEqual(0, game.Score[0]);

            Player testPlayerB = new Player("Other Player", "2", "GK", "Test Team B", 0);
            Annotation testAnnotation2 = new Annotation(time, testPlayerB, 0, 0);
            game.addAnnotation(testAnnotation2);
            Assert.AreEqual(1, game.Score[1]); 
        }

        [TestMethod]
        public void SubstitutionTestA()
        {
            //Testing the team members are switched when there is a substitution in team A. 
            Player testPlayerA = new Player("Test Player", "1", "GK", "Test Team A", 0);
            Player testPlayerB = new Player("Other Player", "2", "GK", "Test Team A", 0);
            Annotation testAnnotation1 = new Annotation(time, testPlayerA, testPlayerB, 4, 0);
            game.addAnnotation(testAnnotation1);
            Assert.AreEqual(testPlayerA, testTeamA.AvailablePlayers[testTeamA.AvailablePlayers.Count - 1]);
            Assert.AreEqual(testPlayerB, testTeamA.InGamePlayers[testTeamA.InGamePlayers.Count - 1]);
        }

        [TestMethod]
        public void SubstitutionTestB()
        {
            //Testing the team members are switched when there is a substitution in team B. 
            Player testPlayerA = new Player("Test Player", "1", "GK", "Test Team B", 0);
            Player testPlayerB = new Player("Other Player", "2", "GK", "Test Team B", 0);
            Annotation testAnnotation1 = new Annotation(time, testPlayerA, testPlayerB, 4, 0);
            game.addAnnotation(testAnnotation1);
            Assert.AreEqual(testPlayerA, testTeamB.AvailablePlayers[testTeamB.AvailablePlayers.Count - 1]);
            Assert.AreEqual(testPlayerB, testTeamB.InGamePlayers[testTeamB.InGamePlayers.Count - 1]);
        }

    }
}
