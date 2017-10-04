# RSSS-ReallySimpleScoreStreaming
A really really simple score streaming originally made in .net core and angular 4, then migrated to .net framework due to server issues. I'm going to migrate back to .net core soon.

This is a 4-hour development solution to a 'not-so-big problem'. So, somethings could and should be made differently, and holpefully will be. But, this solved our problem and I will start to get this better from now.

https://github.com/thiagosgarcia/RSSS-ReallySimpleScoreStreaming/blob/master/screen1.PNG
https://github.com/thiagosgarcia/RSSS-ReallySimpleScoreStreaming/blob/master/screen2.PNG

## Setup
### Server
  - Restore nuget packages
  - Create `connections.config` file at the project root and put your connection strings
  - Run `Update-Database`
  - Deploy through you favorite solution (IIS, msbuild, etc)
  - Note the configured port and update `baseUrl` string for UI (currently at `Web\LiveScore\src\app\app.service.ts`)
### UI
  - Install node
  - run `npm-install`
  - run `ng serve -o`
  
## Usage
  Once deployed, you should set up matches through the api. Currently there's no UI for this action. There's CRUD operations exposed via REST API.
#### Creating a match example:
```
POST /api/score HTTP/1.1
Host: localhost:9122
Content-Type: application/json
{
	HomeTeamGoals : 0,
	AwayTeamGoals: 0,
	HomeTeam:{
		Name: "Team 1 name",
		Player1: "Player 1 name",
		Player2: "Player 2 name"
	},
	AwayTeam:{
		Name: "Team 2 name",
		Player1: "Player 1 name",
		Player2: "Player 2 name"
	}
}
```
#### Result:
```
{
    "TimeLeft": 0,
    "HomeTeamGoals": 0,
    "AwayTeamGoals": 0,
    "HomeTeam": {
        Name: "Team 1 name",
        Player1: "Player 1 name",
        Player2: "Player 2 name"
        "Id": 10
    },
    "AwayTeam": {
        Name: "Team 2 name",
        Player1: "Player 1 name",
        Player2: "Player 2 name"
        "Id": 9
    },
    "Id": 5
}
```
  Root `Id` is the `ScoreId` wich will be used to set the current score.
  
  You can also perform the following request to get the same result:
  ```
  GET /api/score/5 HTTP/1.1
  Host: localhost:9122
  ```
### Controlling matches
  When the UI is rendered, 'control fields' will be shown.
#### To configure a watcher:
  - Set the ScoreId in the first field (default is 1)
  - Click `Hide Controls`
  
  Done! Now this instance is a watcher and will be updated of the events in the current match.
#### To configure a control screen:
  Usually 1 control screen per match
  - Set ScoreId in the first field
  - Set Time Left (in seconds) to control match time in the second field
  - Click the red button to `reset` the timer
  - Click `play` when you want to start the countdown timer
  - Click `stop` to pause the countdown timer
  - Whenever is needed, you can click `plus` and `minus`buttons to control scores for each team
  
  **NOTE**: it is needed to keep the control screen on during matches. This version is **controlled by the UI**, the server is kind of _dummy_ and only gets the requests. As said before, this is a 4-hour solution, it _is going_ to get better =)
