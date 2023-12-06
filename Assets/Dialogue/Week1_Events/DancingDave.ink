EXTERNAL Changegold(value)
EXTERNAL Changemorale(value)
EXTERNAL Changesilk(value)
EXTERNAL ChangeVillagerMorale(value, Name)

Dancing Dave

Will:
“Mayor, there's this guy named Dancing Dave who came to my Tavern.  He’s insisting I give him a chance to show off his dance skills to entertain my customers. I’m not sure if I should hire him or not, what should I do?”

* [Hire Dancing Dave (If player has 100 Gold)]
“This Dancing Dave guy was much better than expected, he’ll bring a lot of customers in!”
~ Changegold(100)
~ Changemorale(2)
#-100 Gold, +2% Morale

* [Don’t hire Dancing Dave]
“Hey Mayor, after we said no he showed off his dance skills in the town square and said that we didn’t hire him. Some of the citizens weren’t happy.”
~ Changemorale (-5)
~ ChangeVillagerMorale(5, "Lorraine")
#-5% Morale, +5 Lorraine Morale

* [Throw a dance party (If player has 25 Silk and 250 Gold)]
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
