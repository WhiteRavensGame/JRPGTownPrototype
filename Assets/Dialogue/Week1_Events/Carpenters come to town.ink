EXTERNAL Changefood(value)
EXTERNAL Changecitizens(value)
// Need a function for the discount

->START

== START ==
Carpenter Comes to Town 

InnKeeper: “Hey Mayor, a carpenter and his family have come to town. He doesn’t have any money but needs food and a place to stay. He says he can pay us back with free labor. 
Should we trust him?”

->CHOICES

== CHOICES ==

 * [Trust him.] ->TRUST
 * [Don’t trust him.] ->NOT_TRUST
 * [Ask him to build something for a test.] ->TEST

==TRUST==
Will - “That’s great Mayor! We have a new person to do work around here, could definitely help the town out.”
~ Changefood(-10)
~ Changecitizens(3)
# -10 Food, +3 citizens, and discount on next upgrade
->END

== NOT_TRUST ==
Will - “Mayor we just lost a good deal, it looks like he could’ve helped us out.”

# Lose the chance for discount.
->END

== TEST ==
Will - “Well Mayor, at least we got something.”

# You get a free chair
->END