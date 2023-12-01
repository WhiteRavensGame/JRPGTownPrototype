EXTERNAL TurnBuildingOff(Name)
EXTERNAL Changefood(value)
EXTERNAL ChangeFisheryProduction(value)

Oscar:
“Sir, from all the fishing we are doing it is possible we might cause damage to the local river, I have some ideas. What do you want to do?”

* [Impose fishing limits]
“Sir, establishing the limits for fishing may be bad for a few days but should be good for us in the long run.”
#No Fish for 3 days, +25 Fish after 3 days
~ Changefood(25)

* [Follow Oscar’s advice for sustainable practices]
“Sir, after we began following the new practices we’ve been able to revitalize the river!”
#+10 Fish, +1 Fishing Production
~ ChangeFisheryProduction(1)
~ Changefood(10)

* [Continue as usual]
“Sir there aren’t many fish left in the river now, the fishery will be slower for now.”
~ ChangeFisheryProduction(-1)
#-1 Fishing Production
