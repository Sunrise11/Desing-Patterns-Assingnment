# Desing-Patterns-Assingnment

Josef Lindwall
A simple game where you try to reach the goal while avoiding falling hazards.

Patterns
-Command pattern in "Inputhandler.cs" in the form of a command for each of the players input. Each command is a saperate .sc
-Observer pattern was used for keeping track of the players health as well as detecting a win or loss. It can be found in "GameStateManager.cs", "Goal.cs","Health.cs",
"UIHealth.cs" and "HealthPickup.cs".
-Factory pattern was used to create the falling hazards the player has to avoid. It can be found in "GenericFactory.cs", "HazardFactory.cs", "HazardSpawner.cs"
