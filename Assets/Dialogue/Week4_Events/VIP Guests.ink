EXTERNAL Changegold(value)
EXTERNAL Changesilk(value)
EXTERNAL Changefood(value)
EXTERNAL Changemorale(value)
EXTERNAL Changecitizens(value)
EXTERNAL Changematerials(value)
EXTERNAL ChangeVillagerMorale(value, Name)

->START

== START ==
VIP Guests

Will: “Hey Mayor, a band of noble merchants from the capital are passing by and demand for the finest, most luxurious service we can provide. I’d say this is a good opportunity to connect with the noble class from the capital so they may consider supporting our village later. ”


->CHOICES

== CHOICES ==

 * [Provide luxury service for the merchants.] ->Provide
 * [Refuse the merchants’ demands.] ->Refuse
 * [Kidnap the merchants and demand for ransom from the capital.] ->Kidnap
 # if Morale >= 65% and Troops >= 8

->DONE

== Provide ==
Later that day Lorraine comes to you and complains about you wasting money and resources on these guests.

* [If Inn is < Level 3.] ->Lower
* [If Inn is >= Level 3.] ->Higher

== Lower ==
~ Changegold(-500)
~ Changefood(-10)
~ Changesilk(-5)
~ Changemorale(-2)
~ ChangeVillagerMorale(10, "Will")
~ ChangeVillagerMorale(-5, "Lorraine")
->END

== Higher ==
~ Changegold(-250)
~ Changefood(-5)
~ ChangeVillagerMorale(10, "Will")
~ ChangeVillagerMorale(-5, "Lorraine")
->END

== Refuse ==
You refuse. It’s not like those nobilities will help your town from Leirrus’s invasion several weeks later anyway. The angry merchants leave and forcefully draft some citizens into their company, and you must fight them to rescue them.

* [Win] ->Win
* [Lose] ->Lose

== Win ==
You mobilize a rescue team to fight the merchants and save your citizens, and stripe the merchants off.
~ Changegold(250)
~ Changesilk(5)
~ Changemorale(5)
~ ChangeVillagerMorale(5, "Adelaine")
~ ChangeVillagerMorale(5, "Lorraine")
->END

== Lose ==
You mobilize a rescue team to fight the merchants and try to save your citizens, but it doesn't go well.
~ Changecitizens(-5)
~ Changematerials(-5)
~ Changemorale(-10)
->END

== Kidnap ==
# if Morale >= 65% and Troops >= 8
With the help of the villagers, you successfully lock the merchants up at night and put them into good use.
~ Changegold(500)
~ Changefood(-10)
~ Changemorale(5)
->END
