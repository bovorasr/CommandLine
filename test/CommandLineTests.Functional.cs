﻿using Xunit;

namespace CommandLine.Tests
{
    public partial class CommandLineTests
    {
        [Fact]
        public void BasicTest1()
        {
            var options = Helpers.Parse<Options1>("p1 2 -opt1 10 -opt2 b");

            Assert.Equal("p1", options.p1);
            Assert.Equal(2, options.p2);
            Assert.Equal(10, options.opt1);
            Assert.Equal("b", options.opt2);
            Assert.Null(options.opt3);
        }

        [Fact]
        public void BasicTest2()
        {
            var options = Helpers.Parse<Options1>("p1 2 -opt1 10");

            Assert.Equal("p1", options.p1);
            Assert.Equal(2, options.p2);
            Assert.Equal(10, options.opt1);
            Assert.Equal("all", options.opt2);
            Assert.Null(options.opt3);
        }

        [Fact]
        public void BasicTest3()
        {
            var options = Helpers.Parse<Options1>("p1 2");

            Assert.Equal("p1", options.p1);
            Assert.Equal(2, options.p2);
            Assert.Equal(256, options.opt1);
            Assert.Equal("all", options.opt2);
            Assert.Null(options.opt3);
        }

        [Fact]
        public void BasicTest4()
        {
            var options = Helpers.Parse<Options1>("p1 2 -opt3 a b c");

            Assert.Equal("p1", options.p1);
            Assert.Equal(2, options.p2);
            Assert.Equal(256, options.opt1);
            Assert.Equal("all", options.opt2);
            Helpers.CollectionEquals(options.opt3, "a", "b", "c");
        }

        [Fact]
        public void BasicTest5()
        {
            var options = Helpers.Parse<Options1>("p1 2 -opt1 10 -opt3 a b c");

            Assert.Equal("p1", options.p1);
            Assert.Equal(2, options.p2);
            Assert.Equal(10, options.opt1);
            Assert.Equal("all", options.opt2);
            Helpers.CollectionEquals(options.opt3, "a", "b", "c");
        }

        [Fact]
        public void BasicTest6()
        {
            var options = Helpers.Parse<Options1>("p1 2 -opt3 a b c -opt1 10");

            Assert.Equal("p1", options.p1);
            Assert.Equal(2, options.p2);
            Assert.Equal(10, options.opt1);
            Assert.Equal("all", options.opt2);
            Helpers.CollectionEquals(options.opt3, "a", "b", "c");
        }

        [Fact]
        public void BasicTest7()
        {
            var options = Helpers.Parse<Options2>(" p1 d e fc -opt2 a b c -opt1 10");

            Assert.Equal("p1", options.p1);
            Helpers.CollectionEquals(options.p2, "d", "e", "fc");
            Assert.Equal(10, options.opt1);
            Helpers.CollectionEquals(options.opt2, "a", "b", "c");
        }

        [Fact]
        public void BasicTest8()
        {
            var options = Helpers.Parse<Options2>("p1 d e fc");

            Assert.Equal("p1", options.p1);
            Helpers.CollectionEquals(options.p2, "d", "e", "fc");
            Assert.Equal(256, options.opt1);
            Assert.Null(options.opt2);
        }

        [Fact]
        public void BasicTest9()
        {
            var options = Helpers.Parse<Options3NoRequired>("-opt1 10 -opt2 d e fc");

            Assert.Equal(10, options.opt1);
            Helpers.CollectionEquals(options.opt2, "d", "e", "fc");
            Assert.Equal(Enum1.B, options.opt3);
        }

        [Fact]
        public void BasicTest10()
        {
            var options = Helpers.Parse<Options3NoRequired>("-opt1 10 -opt2 d e fc -opt3 A");

            Assert.Equal(10, options.opt1);
            Helpers.CollectionEquals(options.opt2, "d", "e", "fc");
            Assert.Equal(Enum1.A, options.opt3);
        }

        [Fact]
        public void BasicTest11()
        {
            var options = Helpers.Parse<Options2>("p1 d e fc -opt2 a b c -opt1 10 -opt3 b");

            Assert.Equal("p1", options.p1);
            Helpers.CollectionEquals(options.p2, "d", "e", "fc");
            Assert.Equal(10, options.opt1);
            Helpers.CollectionEquals(options.opt2, "a", "b", "c");
            Assert.Equal('b', options.Character);
        }

        [Fact]
        public void BasicTest12()
        {
            Options2 options;
            var parsed = Parser.TryParse("p1 d e fc -opt2 a b c -opt1 10 -opt3 b", out options);

            Assert.True(parsed);
            Assert.Equal("p1", options.p1);
            Helpers.CollectionEquals(options.p2, "d", "e", "fc");
            Assert.Equal(10, options.opt1);
            Helpers.CollectionEquals(options.opt2, "a", "b", "c");
            Assert.Equal('b', options.Character);
        }

        [Fact]
        public void BasicTest13()
        {
            Options2 options = Parser.Parse<Options2>("p1 d e fc -opt2 a b c -opt1 10 -opt3 b");

            Assert.NotNull(options);
            Assert.Equal("p1", options.p1);
            Helpers.CollectionEquals(options.p2, "d", "e", "fc");
            Assert.Equal(10, options.opt1);
            Helpers.CollectionEquals(options.opt2, "a", "b", "c");
            Assert.Equal('b', options.Character);
        }

        [Fact]
        public void BasicTest14()
        {
            // Add leading and trailing whitespace
            Options2 options = Parser.Parse<Options2>("     p1 d e fc -opt2 a b c -opt1 10 -opt3 b  ");

            Assert.NotNull(options);
            Assert.Equal("p1", options.p1);
            Helpers.CollectionEquals(options.p2, "d", "e", "fc");
            Assert.Equal(10, options.opt1);
            Helpers.CollectionEquals(options.opt2, "a", "b", "c");
            Assert.Equal('b', options.Character);
        }

        [Fact]
        public void BasicTest15()
        {
            Options2 options = Parser.Parse<Options2>("p1 d e fc -opt2 a b c -opt1 10 -opt3 b".Split(' '));

            Assert.NotNull(options);
            Assert.Equal("p1", options.p1);
            Helpers.CollectionEquals(options.p2, "d", "e", "fc");
            Assert.Equal(10, options.opt1);
            Helpers.CollectionEquals(options.opt2, "a", "b", "c");
            Assert.Equal('b', options.Character);
        }
    }
}