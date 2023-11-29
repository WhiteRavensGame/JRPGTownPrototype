EXTERNAL Changegold(value)
EXTERNAL ChangeSilkFarmProduction(value)

->START

== START ==
Exotic Silk Worms

Lorraine:
“Kid, I just got a shipment of exotic silk worms from a far away friend and I’m stuck on deciding on how I should incorporate them into my farm.”

->CHOICES

== CHOICES ==

 * [Cultivate new worms (If player has 250 Gold).] ->Cultivate
 * [Crossbreed with local worms (If player has 500 Gold).] ->Crossbreed
 * [Maintain pure strains.] ->Pure

== Cultivate ==
“Sir, the smaller boats gave us more materials to work with but I do think our fishing abilities have been limited.”
~ Changegold(-250)
~ ChangeSilkFarmProduction(1)
->END

== Crossbreed ==
“Sir, the boats that have sails seem to be working much better since we save more time traveing through the river.”
~ Changegold(-500)
~ ChangeSilkFarmProduction(2)
->END

== Pure ==
“Sir, the larger boats have taken up a lot of materials but we’ve been able to collect much more fish at a time because of it.”
# Nothing happens
->END