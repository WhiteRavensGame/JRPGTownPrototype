EXTERNAL Changefood(value)
EXTERNAL ChangeBuildingProduction(value, Name)
EXTERNAL Changecitizens(value)
VAR food = 10

-> Start

== Start ==
Oscar Herman: "Sir. A giant lily pad was floating down the river and on it is a giant frog."
What should we do?

-> Choices

== Choices ==
 * [Welcome Frog] -> Welcome_Frog
 * [Kick the frog out] -> Kick_Frog
 * [Recruit Frog - Need 25 Food] -> Recruit_Frog 
 #Need 25 Food

== Welcome_Frog ==
You welcome the frog giving up some food but it teaches the Fisherman some tricks.
You lose 10 food but gain +1 food production.
~ Changefood(-10)
~ ChangeBuildingProduction(1, "Fishery")
#-10 food & +1 Food production
->END

== Kick_Frog ==
You kick the frog out of your town and you make it angry.
The frog steals fish from the river giving it -1 food production.
~ ChangeBuildingProduction(-1, "Fishery")
#-1 food production
->END

== Recruit_Frog ==
{food >= 25: ->Recruit_Frog}
You recruit the frog giving it 25 food and recieving a new villager.
The fisherman recieves a new teacher, giving +3 food production.
~ Changefood(-25)
~ ChangeBuildingProduction(3, "Fishery")
~ Changecitizens(1)
# +1 Friend for fisherman
->END