EXTERNAL ChangeBuildingProduction(value, Name)
EXTERNAL Changecitizens(value)
EXTERNAL ChangeVillagerMorale(value, Name)
EXTERNAL TurnBuildingOff(value, Name)
EXTERNAL TempChangecitizens(value)
EXTERNAL Changegold(value)
EXTERNAL Changemorale(value)

->START

== START ==
A Gnome delegation

Oscar: Mayor. The forest folk have gathered at the gate. Better go meet them.
	When you get to the gate, you don’t understand: you see no one. Then, you lower your eyes. A tiny man looks up at you.
	“Greetings townsage! We are gnomes. We ask for your help in defeating the great red tiger that terrorizes our people. Should you help, we shall owe you one favor”.
	Oscar: They’re talking about the cat in my attic. I’d rather not, but I can chase it off. Your call.


->CHOICES

== CHOICES ==

 * [Chase the cat.] ->Chase
 * [Chase the cat (lie).] ->Lie
 * [Refuse to chase the cat.] ->Refuse

== Chase ==
“Well, cat’s gone. The little folk will be happy, I suppose.” 
Indeed, the gnomes are overjoyed, and reward you by leaving their best warriors to defend your town.
~ ChangeVillagerMorale(-2, "Oscar")
~ Changecitizens(1)

->END

== Lie ==
You tell Oscar to just move the cat out of the attic for a few days, and    then let it come back. Oscar leaves, hiding a smile. The gnomes seem satisfied, and leave, but not before leaving their  men with you. However, when the cats come back a week later, your new gnome villagers leave in indignation.
~ TempChangecitizens(5)

->END

== Refuse ==
Chase a cat away? What kind of monster would commit such an atrocity?! You choose to stand your ground and refuse the gnomes. They take offense, and attack you.

Start very easy battle (unlosable)
	Win: You step towards them and frown really hard. The gnomes get really scared and run away. They leave some gold behind.

~ Changegold(250)
~ Changemorale(-5)
->END