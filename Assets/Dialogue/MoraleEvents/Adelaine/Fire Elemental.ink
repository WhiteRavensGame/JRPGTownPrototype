EXTERNAL ChangeAdelaineMorale(value)
EXTERNAL Changematerials(value)
EXTERNAL ChangeMaterialProduction(value)
// Need a function for the material production

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
“Mayor, this is amazing! Even though it burned part of my shop, it's worth it since it’ll help me expand.”
~ ChangeAdelaineMorale(5)
~ Changematerials(-5)
~ ChangeMaterialProduction(2)
# +5% Adelaine Morale, -5 Materials, +2 Material Production
->END

== CAPTURE ==
“Mayor it seems mad but after a while it could help me out. Too bad it burned up half my shop.”
~ ChangeAdelaineMorale(2)
~ Changematerials(-10)
~ ChangeMaterialProduction(1)
# +2% Adelaine Morale, -10 Materials, +1 Material Production
->END

== KILL ==
“Mayor, I don’t think it was smart to kill the fire elemental, it would’ve been helpful. And it was soooo cute!”
~ ChangeAdelaineMorale(-5)
~ Changematerials(-10)
# -5% Adelaine Morale, -10 Materials
->END