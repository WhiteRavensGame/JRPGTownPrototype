EXTERNAL ChangeWillMorale(value)
EXTERNAL ChangeOscarMorale(value)
EXTERNAL ChangeLorraineMorale(value)
EXTERNAL Changemorale(value)
EXTERNAL ChangeTavernProduction(value)

->START

== START ==
Party Planner

Will: “Hey Mayor I’m planning for a large party to celebrate the town’s prosperity! I was wondering if you had any suggestions?”

->CHOICES

== CHOICES ==

 * [Get Oscar to dance.] ->Oscar
 * [Ask Adelaine to sing.] ->Adelaine
 * [Ask Lorraine to do a puppet show.] ->Lorraine

== Oscar ==
Oscar grumbles a lot more than usual, but somehow, when you mention Lorraine will be there, he begrudgingly accepts. 

 * [If Oscar Morale > 30.] ->Oscar_higher_thirty
 * [If Oscar Morale < 30.] ->Oscar_lower_thirty

->END

== Oscar_higher_thirty ==
When comes the time of the representation, Oscar gives an astounding dance performance. Everyone loves it, and you think you can see half a smile on Lorraine’s face. Could have been a shadow though.
~ ChangeWillMorale(2)
~ ChangeLorraineMorale(1)
~ ChangeOscarMorale(1)
~ ChangeTavernProduction(1)
->END

== Oscar_lower_thirty ==
When comes the time of the representation, Oscar seems exceedingly uncomfortable. He does one move, two moves, then leaves. Everyone is disappointed, Will and Lorraine most of all.
~ ChangeWillMorale(-2)
~ ChangeLorraineMorale(-1)
~ ChangeOscarMorale(-3)
~ ChangeTavernProduction(-1)
->END

== Adelaine ==
 * [If Adelaine Morale > 30.] ->Adelaine_higher_thirty
 * [If Adelaine Morale < 30.] ->Adelaine_lower_thirty

->END

== Adelaine_higher_thirty ==
Adelaine agrees to sing at the party and though her voice isn’t amazing, the fervor with which she sings enraptures will, and the rest of the villager. Everyone has a great time.
~ ChangeWillMorale(5)
~ Changemorale(5)
~ ChangeTavernProduction(2)
->END

== Adelaine_lower_thirty ==
Adelaine agrees to sing at the party and… well her voice isn’t amazing. Most people don’t care. Will still likes it though.
~ ChangeWillMorale(3)
~ ChangeTavernProduction(2)
->END

== Lorraine ==
Lorraine has a collection of puppets that she uses to create a harrowing adventure of 3 heroes on a quest that makes everyone invested!
~ ChangeWillMorale(2)
~ ChangeTavernProduction(1)

->END