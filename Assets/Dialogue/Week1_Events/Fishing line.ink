EXTERNAL Changefood(value)
EXTERNAL Changesilk(value)
EXTERNAL ChangeVillagerMorale(value, Name)

->START

== START ==
New fishing line

Oscar: Mayor. I’m at the end of my fishing lines. Need silk to make more. I’d get it myself but uh… I need to fish. Can you go get some?

->CHOICES

== CHOICES ==

 * [Give 5 silk.] ->Five
 * [Give 10 silk.] ->Ten
 * [Give 25 silk.] ->Twenty_five

== Five ==
Thanks, Mayor. That’ll do.
~ Changefood(5)
~ Changesilk(-5)
->END

== Ten ==
Thanks, Mayor. That’ll do.
~ Changefood(10)
~ Changesilk(-10)
~ ChangeVillagerMorale(2, "Oscar")
->END

== Twenty_five ==
Thanks, Mayor. That’ll do.
~ Changefood(25)
~ Changesilk(-25)
~ ChangeVillagerMorale(5, "Oscar")
->END