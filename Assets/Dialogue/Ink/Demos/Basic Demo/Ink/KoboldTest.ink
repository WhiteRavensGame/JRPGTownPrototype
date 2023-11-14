// EVERYBODY GETS FOOD DAY EXAMPLE
->START

== START ==
Two kobolds enter the village, strutting about with huge sacks thrown over their shoulders.

"Hehe!" One snickers!

All the eyes are on them. Everybody concerned about what was about to happen.

One turns to you, "Heya, big man, we got some food for yous if you'd like to partake.."

His lips curl into a devious smirk, "Whaddya' say?"

->CHOICES

== CHOICES ==

* [Hoard all the food.] ->HOARD
* [Food for all.] ->FOOD_FOR_ALL
* [Kick them and fart in their face.] ->FIGHT 

== HOARD ==
"Hehe, all for yourself, eh? Well, you're the boss, I won't tell." He slyly hands you a rotisserie chicken, though prying eyes notice your scummy exchange.

# +5 FOOD AND -2% MORALE
// Here, the programmers would create the event that does this function. For now, put this as a placeholder.
->DONE

== FOOD_FOR_ALL ==
"Food for all! Food for all!" They start tossing out ham and meats for the entire village.

# +25 FOOD AND +5% MORALE
->DONE

== FIGHT ==
"BLEUGH..! FART?! I HATE FART!"

# COMMENCE BATTLE - MEDIUM DIFFICULTY
// Another placeholder if an event requires combat/troops
->DONE