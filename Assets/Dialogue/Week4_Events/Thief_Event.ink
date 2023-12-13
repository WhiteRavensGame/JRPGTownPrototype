EXTERNAL Changefood(value)
EXTERNAL Changemorale(value)
EXTERNAL Changecitizens(value)
EXTERNAL Changegold(value)
EXTERNAL ChangeVillagerMorale(value, Name)
VAR gold = 500

-> Start

== Start ==
Oscar: “Mayor, the town’s reserve has been broken into. As I was about to store some dried-fish in it, I found a hole on the wall.”
You and Oscar eventually track down the thief’s hideout, and discover that he is just a poor man in desperate need to feed his sick family.


-> Choices

== Choices ==
 * [Let it pass] -> Let_pass
 * [Laws & Discipline] -> Discipline
 * [Donation (requires 500 gold)] -> Donation

== Let_pass ==
You decide to walk away, and Oscar silently follows you
#-5 Food and +5% Morale
~ Changefood(-5)
~ Changemorale(5)
->END

== Discipline ==
Despite the thief’s begging, you compel him to spill what he has stolen
#=5% Reputation and +2% Morale
~ ChangeVillagerMorale(-5, "Oscar")
~ Changemorale(2)
->END   

== Donation ==
You decide to donate some gold to the family and also hire a doctor for them. But at the same time, you tell the thief to never steal again
#=500 Gold, +10% Reputation, and +5 Population
{gold < 500: ->Choices}
~ Changegold(-500)
~ ChangeVillagerMorale(10, "Oscar")
~ Changecitizens(5)
->END 