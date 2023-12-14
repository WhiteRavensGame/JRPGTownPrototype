EXTERNAL ChangeBuildingProduction(value, Name)
EXTERNAL Changegold(value)
EXTERNAL ChangeVillagerMorale(value, Name)
VAR gold = 10

->START

== START ==
#speaker: Adelaine  #portrait: Adelaine
“Hey Mayor, I was doing some experimenting with some metals and found a good alloy we could use in the village. What do you say?”

->CHOICES

== CHOICES ==

* {gold > 249} [Fund Adelaine’s research.] ->Fund
# Need at least 250 gold
* {gold > 499} [Seek external expertise.]  ->Seek
# Need at least 500 gold
* [Stick to known alloys.] ->Known

== Fund ==
#speaker: Adelaine  #portrait: Adelaine
“Thank you so much, Mayor! You have no idea how great this will be for the town!”
~ ChangeBuildingProduction(1, "Smithy")
~ Changegold(-250)
~ ChangeVillagerMorale(5, "Adelaine")
#+1 Blacksmith Production, -250 Gold, +5 Adelaine Morale
->END

== Seek ==
#speaker: Adelaine  #portrait: Adelaine
“Mayor, I told you my idea was good! Now we’re just going to do the same thing but waste more money in the process.”
~ ChangeBuildingProduction(1, "Smithy")
~ Changegold(-500)
~ ChangeVillagerMorale(-5, "Adelaine")
#+1 Blacksmith Production, -500 Gold, -5 Adelaine Morale
->END

== Known ==
#speaker: Adelaine  #portrait: Adelaine
“Mayor, the alloys are still working as normal so don’t worry. No new alloys but the old ones were my old man’s so I’m still happy to use them.”
#Nothing
->END