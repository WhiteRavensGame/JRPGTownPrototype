
EXTERNAL Changefood(value)
EXTERNAL TempChangeBuildingProduction(value, Name)

->START

== START ==
#speaker: Oscar  #portrait: Oscar
“Sir, from all the fishing we are doing it is possible we might cause damage to the local river, I have some ideas. What do you want to do?”

->CHOICES

== CHOICES ==

* [Impose fishing limits.] ->Impose
* [Follow Oscar’s advice for sustainable practices.] ->Follow
* [Continue as usual.] ->Usual

== Impose ==
#speaker: Oscar  #portrait: Oscar
“Establishing the limits for fishing may be bad for a few days but should be good for us in the long run.”
//No Fish for 3 days, +25 Fish after 3 days
~ Changefood(25)
->END

== Follow ==
#speaker: Oscar  #portrait: Oscar
“After we began following the new practices we’ve been able to revitalize the river. Good work.”
//+10 Fish, +1 Fishing Production
~ TempChangeBuildingProduction(1, "Fishery")
~ Changefood(10)
->END

== Usual ==
#speaker: Oscar  #portrait: Oscar
“There aren’t many fish left in the river now, the fishery will be slower for now.”
~ TempChangeBuildingProduction(-1, "Fishery")
//-1 Fishing Production
->END
