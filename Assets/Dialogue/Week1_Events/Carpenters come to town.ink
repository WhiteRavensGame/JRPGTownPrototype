EXTERNAL Changefood(value)
EXTERNAL Changecitizens(value)
EXTERNAL DiscountOnNextUpgrade(value, Name)

->START

== START ==
#speaker: Will  #portrait: Will
“Hey Mayor, a carpenter and his family have come to town. He doesn’t have any money but needs food and a place to stay. He says he can pay us back with free labor. 
Should we trust him?”

->CHOICES

== CHOICES ==

 * [Trust him.] ->TRUST
 * [Don’t trust him.] ->NOT_TRUST
 * [Ask him to build something for a test.] ->TEST

==TRUST==
#speaker: Will  #portrait: Will
“That’s great, Mayor! We have some new people to do work around here, could definitely help the town out.”

~ Changefood(-10)
~ Changecitizens(3)
~ DiscountOnNextUpgrade(1, "Blacksmith")

->END

== NOT_TRUST ==
#speaker: Will  #portrait: Will
“Mayor, we just lost a good deal, it looks like he could’ve helped us out.”


->END

== TEST ==
#speaker: Will  #portrait: Will
“Well Mayor, at least we got something.”

#speaker: Narrator  #portrait: default
You got a free chair!
->END