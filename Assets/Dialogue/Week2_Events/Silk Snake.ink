EXTERNAL ChangeSilkProduction(value)
EXTERNAL Changegold(value)
EXTERNAL Changefood(value)
EXTERNAL Changesilk(value)
EXTERNAL Changematerials(value)
EXTERNAL Changetroops(value)
VAR material = 50
VAR troops = 50

->START

== START ==
#speaker: Lorraine #portrait: Lorraine
“Kid, I got… somewhat of an issue in my silk farm. A creature called the Silk Snake comes in at night to eat the silk produced. I could deal with it myself but… Do you have any ideas?”


->CHOICES

== CHOICES ==

 * [Fight the Snake.] ->Fight
 * [Trap the Snake.] ->Trap
 //(10 Materials required)
 * [Send guards at night.] ->Guard
 //(2 Troops required)

== Fight ==
#speaker: Lorraine #portrait: Lorraine
“Good thing we were able to get rid of the beast kid, we collected more silk that it had yet to eat.”
* [Win] ->Win
* [Lose] ->Lose

== Trap ==
{material >= 10: ->Trap}
#speaker: Lorraine #portrait: Lorraine
“Good thing I’m an expert trap maker kid, we got the beast!”
~ Changematerials(-10)
~ Changefood(5)
~ Changesilk(10)
# +500 Gold
->END

== Guard ==
{troops >= 2: ->Guard}
#speaker: Lorraine #portrait: Lorraine
“Kid the chumps you sent last night were attacked and one was bitten by the beast before succumbing to its poison.”
~ Changetroops(-1)
~ Changesilk(-5)
#-1 troop, -5 Silk
->END

== Win ==
{troops >= 5: ->Win}
#speaker: Lorraine #portrait: Lorraine
“Good thing we were able to get rid of the beast kid, we collected more silk that it had yet to eat.”
~ Changesilk(10)
~ Changefood(5)
#+10 Silk, +5 Food
->END

== Lose ==
{troops < 5: ->Lose}
#speaker: Lorraine #portrait: Lorraine
“The beast got away and wrecked part of the worm farm in the process. Don’t be sad. These things happen.”
~ Changesilk(-5)
~ ChangeSilkProduction(-1)
#-5 Silk, -1 Silk Production
->END 