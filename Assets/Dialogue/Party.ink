EXTERNAL ChangeVillagerMorale(value, Name)
EXTERNAL Changemorale(value)
EXTERNAL ChangeBuildingProduction(value, Name)
VAR OscarMorale = 30
VAR AdelaineMorale = 30

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
{OscarMorale >= 30: ->Oscar_higher_thirty}
When comes the time of the representation, Oscar gives an astounding dance performance. Everyone loves it, and you think you can see half a smile on Lorraine’s face. Could have been a shadow though.
~ ChangeVillagerMorale(2, "Will")
~ ChangeVillagerMorale(1, "Lorraine")
~ ChangeVillagerMorale(1, "Oscar")
~ ChangeBuildingProduction(1, "Tavern")
->END

== Oscar_lower_thirty ==
{OscarMorale < 30: ->Oscar_lower_thirty}
When comes the time of the representation, Oscar seems exceedingly uncomfortable. He does one move, two moves, then leaves. Everyone is disappointed, Will and Lorraine most of all.
~ ChangeVillagerMorale(-2, "Will")
~ ChangeVillagerMorale(-1, "Lorraine")
~ ChangeVillagerMorale(-3, "Oscar")
~ ChangeBuildingProduction(-1, "Tavern")
->END

== Adelaine ==
 * [If Adelaine Morale > 30.] ->Adelaine_higher_thirty
 * [If Adelaine Morale < 30.] ->Adelaine_lower_thirty

->END

== Adelaine_higher_thirty ==
{AdelaineMorale >= 30: ->Adelaine_higher_thirty}
Adelaine agrees to sing at the party and though her voice isn’t amazing, the fervor with which she sings enraptures Will, and the rest of the villager. Everyone has a great time.
~ ChangeVillagerMorale(5, "Will")
~ Changemorale(5)
~ ChangeBuildingProduction(2, "Tavern")
->END

== Adelaine_lower_thirty ==
{AdelaineMorale < 30: ->Adelaine_lower_thirty}
Adelaine agrees to sing at the party and… well her voice isn’t amazing. Most people don’t care. Will still likes it though.
~ ChangeVillagerMorale(3, "Will")
~ ChangeBuildingProduction(2, "Tavern")
->END

== Lorraine ==
Lorraine has a collection of puppets that she uses to create a harrowing adventure of 3 heroes on a quest that makes everyone invested!
~ ChangeVillagerMorale(2, "Will")
~ ChangeBuildingProduction(1, "Tavern")

->END