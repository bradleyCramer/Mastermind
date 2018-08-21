using System;
using Mastermind;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Mastermind.Tests
{
    [TestClass]
    public class UnitTest1
    {

        [TestMethod]
        public void Evaluate_OneWell_NoMisplaced()
        {
            //Arrange
            int[] secret = { 1, 4, 5, 6 };
            int[] guess = { 1, 3, 2, 3 };
            MastermindGame game = new MastermindGame();

            //Act
            string expectedValue = game.evaluateGuess(guess, secret);

            //Assert
            expectedValue.Should().Be("+", "Because only one guess is well placed");
        }
        [TestMethod]
        public void Evaluate_NoWell_OneMisplaced()
        {
            //Arrange
            int[] secret = { 1, 4, 5, 6 };
            int[] guess = { 2, 5, 2, 3 };
            MastermindGame game = new MastermindGame();

            //Act
            string expectedValue = game.evaluateGuess(guess, secret);

            //Assert
            expectedValue.Should().Be("-", "Because only one guess is misplaced.");
        }

        [TestMethod]
        public void Evaluate_OneWell_OneMisplaced ()
        {
            //Arrange
            int[] secret = { 1, 4, 5, 6 };
            int[] guess = { 1, 5, 2, 3 };
            MastermindGame game = new MastermindGame();

            //Act
            string expectedValue = game.evaluateGuess(guess, secret);

            //Assert
            expectedValue.Should().Be("+-", "Because one is well placed and one is misplaced.");
        }

        [TestMethod]
        public void Evaluate_OneWell_TwoMisplaced()
        {
            //Arrange
            int[] secret = { 1, 4, 5, 6 };
            int[] guess = { 1, 5, 2, 4 };
            MastermindGame game = new MastermindGame();

            //Act
            string expectedValue = game.evaluateGuess(guess, secret);

            //Assert
            expectedValue.Should().Be("+--", "Because one is well placed and two are misplaced.");
        }

        [TestMethod]
        public void Evaluate_TwoWell_OneMisplaced()
        {
            //Arrange
            int[] secret = { 1, 4, 5, 6 };
            int[] guess = { 1, 5, 2, 6 };
            MastermindGame game = new MastermindGame();

            //Act
            string expectedValue = game.evaluateGuess(guess, secret);

            //Assert
            expectedValue.Should().Be("++-", "Because two are well placed and one is misplaced.");
        }

        [TestMethod]
        public void Evaluate_TwoWell_TwoMisplaced()
        {
            //Arrange
            int[] secret = { 1, 4, 5, 6 };
            int[] guess = { 1, 5, 4, 6 };
            MastermindGame game = new MastermindGame();

            //Act
            string expectedValue = game.evaluateGuess(guess, secret);

            //Assert
            expectedValue.Should().Be("++--", "Because two are well placed and two are misplaced.");
        }

        [TestMethod]
        public void Evaluate_OneWell_NoneMisplaced_AllSameNum()
        {
            //Arrange
            int[] secret = { 1, 4, 5, 6 };
            int[] guess = { 5, 5, 5, 5 };
            MastermindGame game = new MastermindGame();

            //Act
            string expectedValue = game.evaluateGuess(guess, secret);

            //Assert
            expectedValue.Should().Be("+", "Because one is well placed, but the misplaced ones are already covered by the well placed one.");
        }

        [TestMethod]
        public void Evaluate_OneMisplaced_Duplicate()
        {
            //Arrange
            int[] secret = { 1, 4, 5, 6 };
            int[] guess = { 4, 2, 4, 2 };
            MastermindGame game = new MastermindGame();

            //Act
            string expectedValue = game.evaluateGuess(guess, secret);

            //Assert
            expectedValue.Should().Be("-", "Because two 4's are misplaced but should only count for one misplacement.");
        }

        [TestMethod]
        public void Evaluate_TwoMisplaced_Duplicate()
        {
            //Arrange
            int[] secret = { 1, 4, 5, 6 };
            int[] guess = { 4, 5, 4, 5 };
            MastermindGame game = new MastermindGame();

            //Act
            string expectedValue = game.evaluateGuess(guess, secret);

            //Assert
            expectedValue.Should().Be("--", "Because two 4's and two 5's are misplaced but should only count for two misplacements.");
        }


    }
}
