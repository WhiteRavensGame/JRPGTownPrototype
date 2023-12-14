EXTERNAL Changefood(value)
EXTERNAL Changesilk(value)
EXTERNAL ChangeVillagerMorale(value, Name)
VAR silk = 10

->START

== START ==
#speaker: Oscar  #portrait: Oscar
"Mayor. I’m at the end of my fishing lines. Need silk to make more. I’d get it myself but uh… I need to fish. Can you go get some?"

->CHOICES

== CHOICES ==

 * {silk > 4} [Give 5 silk.] ->Five
 * {silk > 9} [Give 10 silk.] ->Ten
 * {silk > 24} [Give 25 silk.] ->Twenty_five

== Five ==
#speaker: Oscar  #portrait: Oscar
"Thanks, Mayor. That’ll do."
~ Changefood(5)
~ Changesilk(-5)
->END

== Ten ==
#speaker: Oscar  #portrait: Oscar
"Thanks, Mayor. That’ll do."
~ Changefood(10)
~ Changesilk(-10)
~ ChangeVillagerMorale(2, "Oscar")
->END

== Twenty_five ==
#speaker: Oscar  #portrait: Oscar
"Thanks, Mayor. That’ll do."
~ Changefood(25)
~ Changesilk(-25)
~ ChangeVillagerMorale(5, "Oscar")
->END
