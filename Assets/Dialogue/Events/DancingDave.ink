EXTERNAL Changemorale(value)
EXTERNAL Changegold(value)
EXTERNAL ChangeLorraineMorale(value)
EXTERNAL ChangeAdelaineMorale(value)
EXTERNAL ChangeOscarMorale(value)
EXTERNAL ChangeRoeMorale(value)
EXTERNAL ChangeWillMorale(value)
EXTERNAL Changesilk(value)

>START

== START ==
Dancing Dave

Will:
“Mayor, there's this guy named Dancing Dave who came to my Tavern.  He’s insisting I give him a chance to show off his dance skills to entertain my customers. I’m not sure if I should hire him or not, what should I do?”

->CHOICES

== CHOICES ==

 * [Hire Dancing Dave] ->Hire
 * [Don't hire Dancing Dave] ->NoHire
 * [Throw a dance party] ->Party

== Hire ==
“This Dancing Dave guy was much better than expected, he’ll bring a lot of customers in!”
~ Changegold(100)
~ Changemorale(2)
->END

== NoHire ==
“Hey Mayor, after we said no he showed off his dance skills in the town square and said that we didn’t hire him. Some of the citizens weren’t happy.”
~ Changemorale(-5)
~ ChangeLorraineMorale(5)
->END

== Party ==
“Mayor the party went amazingly! This Dancing Dave guy is really good. I guess it is in the name.”
~ Changemorale(5)
~ Changesilk(-25)
~ Changegold(-250)
~ ChangeLorraineMorale(2)
~ ChangeAdelaineMorale(2)
~ ChangeOscarMorale(2)
~ ChangeRoeMorale(2)
~ ChangeWillMorale(2)
->END