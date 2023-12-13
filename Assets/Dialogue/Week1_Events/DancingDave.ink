EXTERNAL Changegold(value)
EXTERNAL Changemorale(value)
EXTERNAL Changesilk(value)
EXTERNAL ChangeVillagerMorale(value, Name)

VAR gold = 10
VAR silk = 10

->START

== START ==
Dancing Dave

Will:
“Mayor, there's this guy named Dancing Dave who came to my Tavern.  He’s insisting I give him a chance to show off his dance skills to entertain my customers. I’m not sure if I should hire him or not, what should I do?”

->CHOICES

== CHOICES ==

* [Hire Dancing Dave (If player has 100 Gold)] ->Hire
* [Don’t hire Dancing Dave] -> Dont_hire
* [Throw a dance party (If player has 25 Silk and 250 Gold)] -> Party

== Hire ==
{gold >= 100: -> Hire}
“This Dancing Dave guy was much better than expected, he’ll bring a lot of customers in!”
~ Changegold(100)
~ Changemorale(2)
#-100 Gold, +2% Morale
->END

== Dont_hire ==
“Hey Mayor, after we said no he showed off his dance skills in the town square and said that we didn’t hire him. Some of the citizens weren’t happy.”
~ Changemorale (-5)
~ ChangeVillagerMorale(5, "Lorraine")
#-5% Morale, +5 Lorraine Morale
->END

== Party ==
{gold >= 250 && silk >=25: ->Party}
“Mayor the party went amazingly! This Dancing Dave guy is really good. I guess it is in the name.”
~ Changemorale (5)
~ Changesilk(25)
~ Changegold(250)
~ ChangeVillagerMorale(2, "Lorraine")
~ ChangeVillagerMorale(2, "Oscar")
~ ChangeVillagerMorale(2, "Will")
~ ChangeVillagerMorale(2, "Adelaine")
~ ChangeVillagerMorale(2, "Roe")
#+5% Morale, -25 Silk, -250 Gold +2 Every character’s morale.
->END