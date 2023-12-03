EXTERNAL ChangeSilkProduction(value)
EXTERNAL Changegold(value)
EXTERNAL Changefood(value)
EXTERNAL Changesilk(value)
EXTERNAL Changematerials(value)
EXTERNAL Changetroops(value)

->START

== START ==
Silk Snake

Lorraine:
“Kid, I got… somewhat of an issue in my silk farm. A creature called the Silk Snake comes in at night to eat the silk produced. I could deal with it myself but… Do you have any ideas?”


->CHOICES

== CHOICES ==

 * [Fight the Snake] ->Fight
 * [Trap the Snake (10 Materials required)] ->Trap
 * [Send guards at night (2 Troops required)] ->Guard

== Fight ==
“Good thing we were able to get rid of the beast kid, we collected more silk that it had yet to eat.”
* [Win] ->Win
* [Lose] ->Lose

== Trap ==
“Good thing I’m an expert trap maker kid, we got the beast!”
~ Changematerials(-10)
~ Changefood(5)
~ Changesilk(10)
# +500 Gold
->END

== Guard ==
“Kid the chumps you sent last night were attacked and one was bitten by the beast before succumbing to its poison.”
~ Changetroops(-1)
~ Changesilk(-5)
#-1 troop, -5 Silk
->END

== Win ==
“Good thing we were able to get rid of the beast kid, we collected more silk that it had yet to eat.”
~ Changesilk(10)
~Changefood(5)
#+10 Silk, +5 Food
->END

== Lose ==
“The beast got away and wrecked part of the worm farm in the process. Don’t be sad. These things happen.”
~ Changesilk(-5)
~ ChangeSilkProduction(-1)
#-5 Silk, -1 Silk Production
->END