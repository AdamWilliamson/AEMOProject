using System;
using System.Collections.Generic;
using System.Threading.Tasks;
#nullable enable

namespace WebAPI.Commands.SubTextMatchingCommand
{
    // Ideally commands and queries would be in a seperate project.
    // But for a simple thing like this, vertical stripes is more appropriate.
    public class SubTextMatchingCommand
    {
        public SubTextMatchingCommand(string text, string subText, bool caseSensitive)
        {
            Text = text;
            SubText = subText;
            CaseSensitive = caseSensitive;
        }

        public string Text { get; }
        public string SubText { get; }
        public bool CaseSensitive { get; }
    }

    public class SubTextMatchingCommandHandler
    {
        public Task<SubTextMatchingResponse> Handle(SubTextMatchingCommand command)
        {
            // deal with case sensitivity.
            var text = (command.CaseSensitive) ? command.Text : command.Text?.ToLower();
            var subText = (command.CaseSensitive) ? command.SubText : command.SubText?.ToLower();

            var results = text.AllIndexesOf(subText);

            return Task.FromResult(new SubTextMatchingResponse(results));
        }
    }

    public class SubTextMatchingResponse
    {
        public SubTextMatchingResponse(IEnumerable<int> matchIndexes)
        {
            MatchIndexes = matchIndexes;
        }

        public IEnumerable<int> MatchIndexes { get; }
    }
}
