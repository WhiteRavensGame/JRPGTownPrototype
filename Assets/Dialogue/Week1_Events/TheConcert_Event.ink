EXTERNAL Changematerials(value)
EXTERNAL Changemorale(value)

-> Start

== Start ==
Lorraine: "There’s an elf making some noise in the town square, he’s putting up flyers and screaming that there must be a show! "
The flyer says Wymm Hasslefire, the world famous bard wants to put a concert on, what do you want to do?

-> Choices

== Choices ==
 * [Put the show on.] -> Show
 * [Tell Wymm to leave] -> No_Show

== Show ==
You use a large amount of materials to put on the show and the town loves it!
#Lose % of materials and gain 30% Morale
->END

== No_Show ==
You tell Wymm he can't host a show here and he leaves, leaving some people dissapointed.
#Lose 3% Morale
->END