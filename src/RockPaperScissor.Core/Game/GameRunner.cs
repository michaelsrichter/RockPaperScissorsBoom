﻿using System;
using RockPaperScissor.Core.Game.Results;
using RockPaperScissor.Core.Model;
using System.Collections.Generic;
using System.Linq;
using RockPaperScissor.Core.Game.Bots;

namespace RockPaperScissor.Core.Game
{
    public class GameRunner
    {
        private readonly List<BaseBot> _competitors = new List<BaseBot>();

        public GameRunnerResult StartAllMatches()
        {
            var matchRunner = new MatchRunner();

            var matchResults = new List<MatchResult>();

            for (int i = 0; i < _competitors.Count; i++)
            {
                for (int j = i + 1; j < _competitors.Count; j++)
                {
                    matchResults.Add(matchRunner.RunMatch(_competitors[i], _competitors[j]));
                }
            }

            return GetBotRankingsFromMatchResults(matchResults);
        }

        public GameRunnerResult GetBotRankingsFromMatchResults(List<MatchResult> matchResults)
        {
            var botRankings = new List<BotRecord>();

            foreach (BaseBot bot in _competitors)
            {
                int wins = matchResults.Count(x => x.WasWonBy(bot.Id));
                int losses = matchResults.Count(x => x.WasLostBy(bot.Id));
                int ties = matchResults.Count(x => x.WinningPlayer == MatchOutcome.Neither); // TODO: Use this.

                botRankings.Add(new BotRecord(bot.Competitor, wins, losses, ties));
            }

            List<FullResults> allMatchResults = GetFullResultsByPlayer(matchResults);
            return new GameRunnerResult { BotRecords = botRankings, AllMatchResults = allMatchResults};
        }

        private static List<FullResults> GetFullResultsByPlayer(List<MatchResult> matchResults)
        {
            var player1s = matchResults.Select(x => x.Player1).Distinct();
            var player2s = matchResults.Select(x => x.Player2).Distinct();

            var competitors = player1s.Union(player2s).ToList();

            List<FullResults> allMatchResults = new List<FullResults>();
            foreach (Competitor competitor in competitors)
            {
                var collection = matchResults.Where(x => x.Player1 == competitor || x.Player2 == competitor).ToList();
                allMatchResults.Add(new FullResults { Competitor = competitor, MatchResults = collection});
            }

            return allMatchResults;
        }

        public void AddBot(BaseBot bot)
        {
            _competitors.Add(bot);
        }
    }
}