using Shouldly;
using System;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Commands.SubTextMatchingCommand;
using Xunit;

namespace AebAPITest
{
    public class SubTextMatchingCommandTests
    {
        [Fact]
        public async Task GivenAText_WithARepeatedSubText_ItFinds3Matches()
        {
            var command = new SubTextMatchingCommand("I match contain match multiple matches", "match", true);

            var result = await new SubTextMatchingCommandHandler().Handle(command);

            result.MatchIndexes.ToList().Count().ShouldBe(3);
        }

        [Theory]
        [InlineData("text", "notfindable", 0)]
        [InlineData("text", "e", 1)]
        [InlineData("text text text", "text", 3)]
        [InlineData("<@>$text text text", "<@>$t", 1)]
        [InlineData("<@>$text text text", "t t", 2)]
        [InlineData("<@>$Text Text Text", "t t", 2)]
        [InlineData("<@>$text text text", "Text", 3)]
        public async Task GivenAText_WithCaseInsensititveSubText_ItFindsMatches(string text, string subtext, int count)
        {
            var command = new SubTextMatchingCommand(text, subtext, false);

            var result = await new SubTextMatchingCommandHandler().Handle(command);

            result.MatchIndexes.ToList().Count().ShouldBe(count);
        }

        [Theory]
        [InlineData("text", "e", 1)]
        [InlineData("text text text", "text", 3)]
        [InlineData("<@>$text text text", "<@>$t", 1)]
        [InlineData("<@>$text text text", "t t", 2)]
        [InlineData("<@>$Text Text Text", "t t", 0)]
        [InlineData("<@>$text text text", "Text", 0)]
        public async Task GivenAText_WithCaseSensititveSubText_ItFindsMatches(string text, string subtext, int count)
        {
            var command = new SubTextMatchingCommand(text, subtext, true);

            var result = await new SubTextMatchingCommandHandler().Handle(command);

            result.MatchIndexes.ToList().Count().ShouldBe(count);
        }

        [Fact]
        public async Task GivenANullText_WithASubText_ItExceptions()
        {
            var command = new SubTextMatchingCommand(null, "match", true);

            try
            {
                await new SubTextMatchingCommandHandler().Handle(command);
                Assert.False(true);
            }
            catch
            {
                Assert.True(true);
            }
        }

        [Fact]
        public async Task GivenANullSubTextText_WithText_ItExceptions()
        {
            var command = new SubTextMatchingCommand("the string that should be matched against", null, true);

            try
            {
                await new SubTextMatchingCommandHandler().Handle(command);
                Assert.False(true);
            }
            catch
            {
                Assert.True(true);
            }
        }
    }
}
