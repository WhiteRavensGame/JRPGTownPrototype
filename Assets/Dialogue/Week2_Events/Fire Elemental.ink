EXTERNAL ChangeVillagerMorale(value, Name)
EXTERNAL Changematerials(value)
EXTERNAL ChangeBuildingProduction(value, Name)
VAR AdelaineMorale = 40

->START

== START ==
Fire Elemental

You head into the Blacksmith’s shop and nearby the forge is a small, dancing flame that drifts back and forth. 
Adelaine: “Hey Mayor! Look, it’s a fire elemental! Got in this morning and saw this little guy dancing around by the forge. I think it thinks it’s its mom! Can we keep it? Please? I promise I won’t let it burn down the town when it gets older!”

->CHOICES

== CHOICES ==

 * [(If Adelaine Morale > 40) Befriend.] ->BEFRIEND
 * [Capture.] ->CAPTURE
 * [Kill.] ->KILL

== BEFRIEND ==
{AdelaineMorale > 40: ->BEFRIEND}
“Mayor, this is amazing! Even though it burned part of my shop, it's worth it since it’ll help me expand.”
~ ChangeVillagerMorale(5, "Adelaine")
~ Changematerials(-5)
~ ChangeBuildingProduction(2, "Smithy")
# +5% Adelaine Morale, -5 Materials, +2 Material Production
->END

== CAPTURE ==
“Mayor it seems mad but after a while it could help me out. Too bad it burned up half my shop.”
~ ChangeVillagerMorale(2, "Adelaine")
~ Changematerials(-10)
~ ChangeBuildingProduction(1, "Smithy")
# +2% Adelaine Morale, -10 Materials, +1 Material Production
->END

== KILL ==
“Mayor, I don’t think it was smart to kill the fire elemental, it would’ve been helpful. And it was soooo cute!”
~ ChangeVillagerMorale(-5, "Adelaine")
~ Changematerials(-10)
# -5% Adelaine Morale, -10 Materials
->END