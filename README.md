<p align="center">
  <img src="https://daren-stottrup.notion.site/image/https%3A%2F%2Fs3-us-west-2.amazonaws.com%2Fsecure.notion-static.com%2Fdee6cfab-f437-4b10-b0c3-102ac1a0a0c9%2FArgon_Assault2.png?table=block&id=ff8d9eb0-a684-4323-a822-b97de7755eff&spaceId=f2ac5bd7-db8b-4b29-8205-809cd644ec3b&width=2000&userId=&cache=v2">
</p>

# Argon Assault
To learn more about this game, visit [Argon Assault](https://daren-stottrup.notion.site/Argon-Assault-ef580c7dfc8f4b41b6caea89621fc76c) on my [portfolio](https://daren-stottrup.notion.site/Game-Portfolio-3bc5aac8cfcb4d32af26f20301371155).
<br>
To play this game, check out the [WebGL Version](https://play.unity.com/mg/other/webgl-builds-29549).

## Coursework Project
This project was part of a course I took, and looking back, it's jarring to see the lack of "private" and "public" keywords! Nevertheless, as with most of the coursework projects, there were additions I made to the game--features that made the project go from simple homework, to games that I felt comfortable sending to friends to play as evidence of my education.

## My Additions

#### Feeling the Force
The first was in the Unity editor rather than in code. Simply put, I wanted the ship to appear as if it were actually flying correctly as much as possible, even if the player didn't move the controls at all. To do this, I attempted to animate Newtonian physics as the ship took banked turns before leveling out again in straight-aways.

#### Ammunition
I wanted to add some incentive to not just spam the lasers, so I added an [ammo](Assets/Scripts/Ammo.cs) feature. Once you run out of ammo, you cannot fire again until you touch down at the mountain plateau (meant to signify refueling).

#### Scoreboard
Finally, I added some [scoring](Assets/Scripts/ScoreBoard.cs) features and some useful UI elements to track them. On the left of the screen is how many [attempts](Assets/Scripts/Rounds.cs) the player needed before beating the game, as well as how many enemies are left before success. Destroying enemies will increase your score, but each attempt will deduct points.
