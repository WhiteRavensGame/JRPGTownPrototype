EXTERNAL Changefood(value)
EXTERNAL Changemorale(value)
EXTERNAL Changecitizens(value)
EXTERNAL Changegold(value)
EXTERNAL ChangeVillagerMorale(value, Name)
VAR gold = 500

-> Start

== Start ==
#speaker: Oscar #portrait: Oscar
“Mayor, the town’s reserve has been broken into. As I was about to store some dried-fish in it, I found a hole on the wall.”
#speaker: Narrator #portrait: Default
You and Oscar eventually track down the thief’s hideout, and discover that he is just a poor man in desperate need to feed his sick family.


-> Choices

== Choices ==
 * [Let it pass] -> Let_pass
 * [Laws & Discipline] -> Discipline
 * {gold > 499} [Donation] -> Donation
 # Need at least 500 gold

== Let_pass ==
#speaker: Narrator #portrait: Default
You decide to walk away, and Oscar silently follows you

~ Changefood(-5)
~ Changemorale(5)
->END

== Discipline ==
#speaker: Narrator #portrait: Default
Despite the thief’s begging, you compel him to spill what he has stolen

~ ChangeVillagerMorale(-5, "Oscar")
~ Changemorale(2)
->END   

== Donation ==
#speaker: Narrator #portrait: Default
You decide to donate some gold to the family and also hire a doctor for them. But at the same time, you tell the thief to never steal again

~ Changegold(-500)
~ ChangeVillagerMorale(10, "Oscar")
~ Changecitizens(5)
->END 