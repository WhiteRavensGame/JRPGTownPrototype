
EXTERNAL Changefood(value)
EXTERNAL TempChangeBuildingProduction(value, Name)

->START

== START ==
Over Fishing

Oscar:
“Sir, from all the fishing we are doing it is possible we might cause damage to the local river, I have some ideas. What do you want to do?”

->CHOICES

== CHOICES ==

* [Impose fishing limits] ->Impose
* [Follow Oscar’s advice for sustainable practices] ->Follow
* [Continue as usual] ->Usual

== Impose ==

“Sir, establishing the limits for fishing may be bad for a few days but should be good for us in the long run.”
#No Fish for 3 days, +25 Fish after 3 days
~ Changefood(25)
->END

== Follow

* [Follow Oscar’s advice for sustainable practices]
“Sir, after we began following the new practices we’ve been able to revitalize the river!”
#+10 Fish, +1 Fishing Production
~ TempChangeBuildingProduction(1, "Fishery")
~ Changefood(10)
->END

== Usual ==

* [Continue as usual]
“Sir there aren’t many fish left in the river now, the fishery will be slower for now.”
~ TempChangeBuildingProduction(-1, "Fishery")
#-1 Fishing Production
->END
