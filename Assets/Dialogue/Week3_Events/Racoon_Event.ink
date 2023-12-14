EXTERNAL Changematerials(value)
EXTERNAL Changegold(value)
EXTERNAL Changecitizens(value)
EXTERNAL ChangeBuildingProduction(value, Name)
VAR material = 50

-> Start

== Start ==
Adelaine: "Boss! I went out back of my shop and found a bunch of racoons going through the trash."
"What should we do with them?"
{material < 25: ->Choices1}
-> Choices

== Choices ==
 * [Drive them out] -> Drive_out
 * [Give them supplies] -> Give_supplies
 * [Build village] -> Build_village
 #Need 25 Food
 
 
== Choices1 ==
 * [Give them supplies] -> Give_supplies
 * [Build village] -> Build_village


== Drive_out ==
You gather the town's folks to drive every single one of them out of town. But later that night they conduct one final raid at the Blacksmith’s place and steal some materials
#-10 Materials
~ Changematerials(-10)
->END

== Give_supplies ==
You give raccoons the food supplies they need, and later that evening, upon hearing a few light knocks of the door and opening it, you found a gem and a few little footprints next to it.
#+250 Wealth
~ Changegold(250)
->END   

== Build_village ==
{material < 25: ->Choices}
The raccoons become a part of your village. They regularly scavenge materials from different places and contribute to the material production of the village.
#-25 materials, -250 Gold,  +8 population, +5 materials per day
~ Changematerials(-25)
~ Changegold(-250)
~ Changecitizens(8)
~ ChangeBuildingProduction(5, "Mine")
->END 