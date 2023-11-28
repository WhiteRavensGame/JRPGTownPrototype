EXTERNAL Changegold(value)
EXTERNAL Changematerials(value)
EXTERNAL Changefood(value)

->START

== START ==
Kobold Mafia (If Free Food event has been triggered)

Roe: “Heya Boss! I was going around town munching on my dirt pop when I saw a whole group of Kobolds looking around town. Since they’re fellow rock munchers too I had to go over and see what they were doing. And wouldn’t you know? They’re looking for more kobolds! I think the ones that came through town giving free food. What should we tell them boss?”

->CHOICES

== CHOICES ==

 * [They were in town before.] ->IN_TOWN_BEFORE
 * [They gave us free food.] ->FREE_FOOD
 * [I don’t know.] ->IDK

->DONE

==IN_TOWN_BEFORE==
The kobolds are happy that you’ve told them this important information and for that they give you gifts of gold and ores.
~ Changegold(250)
~ Changematerials(5)
->END

== FREE_FOOD ==
The kobolds are happy from the information but also unhappy as the food was stolen from them by the kobolds, but they don’t blame you.
~ Changegold(250)
~ Changematerials(10)
->END

== IDK ==
The kobolds are suspicious of you and ask around town before realizing that the kobolds were here before. They are unhappy with you and demand a portion of the food be returned to them since it was stolen.
~ Changefood(-10)
# -10 Food
->END

