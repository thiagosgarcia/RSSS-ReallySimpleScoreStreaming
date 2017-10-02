select * from Matches
Select * from score
select * from team

select M.Id as MatchID, M.MatchTime, HT.Name as HomeTeam, S.HomeTeamGoals, 
	AT.Name as AwayTeam, S.AwayTeamGoals  from matches M
inner join score S on M.ScoreId = S.Id
inner join team AT on S.AwayTeamId = AT.Id 
inner join team HT on S.HomeTeamId = HT.Id 